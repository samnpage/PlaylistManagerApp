using PlaylistManagerApp.Models.Spotify;

namespace PlaylistManagerApp.Services.Spotify;

public interface ISpotifyService
{
    Task<string> GetAccessToken(string clientId, string clientSecret);
    // Task<string> GetTrackInfo(string trackId, string accessToken);
    Task<List<SearchResult>> SearchForSong(string query);
}