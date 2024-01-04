using PlaylistManagerApp.Models.Search;

namespace PlaylistManagerApp.Services.Search;

public interface ISearchService
{
    Task<string?> GetAccessToken(string clientId, string clientSecret);
    // Task<string> GetTrackInfo(string trackId, string accessToken);
    Task<List<SearchResult>> SearchForSong(string query);
}