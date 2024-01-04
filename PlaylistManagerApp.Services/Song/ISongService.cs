using PlaylistManagerApp.Models.Song;

namespace PlaylistManagerApp.Services.Song;

public interface ISongService
{
    Task CreateSongFromSpotifySearchResultAsync(SongCreate model);
}