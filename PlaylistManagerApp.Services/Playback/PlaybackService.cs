using System.Text;
using Microsoft.Extensions.Configuration;
using PlaylistManagerApp.Services.Search;

namespace PlaylistManagerApp.Services.Playback;

public class PlaybackService : IPlaybackService
{
    private readonly HttpClient _httpClient;
    private readonly ISearchService _searchService;
    private readonly IConfiguration _configuration;

    public PlaybackService(HttpClient httpClient, ISearchService searchService, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _searchService = searchService;
        _configuration = configuration;
    }

    public async Task StartPlaybackAsync(string trackId)
    {
        var clientId = _configuration["Spotify:ClientId"];
        var clientSecret = _configuration["Spotify:ClientSecret"];

        if (clientId != null && clientSecret != null)
        {
            string accessToken = await _searchService.GetAccessToken(clientId, clientSecret);
            string endpoint = "https://api.spotify.com/v1/me/player/play";
            string jsonBody = "{\"uris\": [\"spotify:track:" + trackId + "\"]}";

            var request = new HttpRequestMessage(HttpMethod.Put, endpoint)
            {
                Content = new StringContent(jsonBody, Encoding.UTF8, "application/json")
            };

            request.Headers.Add("Authorization", $"Bearer {accessToken}");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Playback started successfully.");
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
            }
        }
    }
}