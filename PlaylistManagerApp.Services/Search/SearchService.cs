using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using PlaylistManagerApp.Models.Search;

namespace PlaylistManagerApp.Services.Search;
public class SearchService : ISearchService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public SearchService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<List<SearchResult>> SearchForSong(string query)
    {
        var clientId = _configuration["Spotify:ClientId"];
        var clientSecret = _configuration["Spotify:ClientSecret"];

        if (clientId != null && clientSecret != null)
        {
            // Obtain an access token
            var accessToken = await GetAccessToken(clientId, clientSecret);

            // Uses the access token to make a request to the Spotify API search endpoint
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
            var response = await _httpClient.GetAsync($"https://api.spotify.com/v1/search?q={Uri.EscapeDataString(query)}&type=track");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            // Deserializes the JSON response into a list of SearchResult objects
            var searchResult = JsonConvert.DeserializeObject<SpotifySearchResult>(content)!;

            return searchResult.Tracks.Items;
        }
        else 
        {
            return new List<SearchResult>();
        }   
    }

    // Helper methods
    public async Task<string?> GetAccessToken(string clientId, string clientSecret)
    {
        var parameters = new Dictionary<string, string>
        {
            { "grant_type", "client_credentials" },
            { "client_id", clientId },
            { "client_secret", clientSecret }
        };

        var response = await _httpClient.PostAsync("https://accounts.spotify.com/api/token", new FormUrlEncodedContent(parameters));
        response.EnsureSuccessStatusCode();

        var tokenContent = await response.Content.ReadAsStringAsync();
        var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(tokenContent)!;

        return tokenResponse.AccessToken;
    }
}