using PlaylistManagerApp.Models.Song;

namespace PlaylistManagerApp.Services.Song;

public interface ISongService
{
    Task<bool> CreateSongFromSpotifySearchResultAsync(SongCreate model);
}