using PlaylistManagerApp.Models.Song;

namespace PlaylistManagerApp.Services.Song;

public interface ISongService
{
    // Create
    Task<int> CreateSongAsync(SongCreate model);

    // Read
    Task<List<SongListItem>> GetAllSongs();
    Task<SongDetail> GetSongByIdAsync(int songId);
}