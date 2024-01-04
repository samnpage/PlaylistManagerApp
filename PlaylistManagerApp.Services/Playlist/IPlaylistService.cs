using PlaylistManagerApp.Models.Playlist;

namespace PlaylistManagerApp.Services.Playlist;

public interface IPlaylistService
{
    // Task AddSongToPlaylist(int playlistId, SearchResult song);

    // Create
    Task CreatePlaylistAsync(PlaylistCreate playlist);

    // Read
    Task<IEnumerable<PlaylistListItem>> GetAllPlaylistsAsync();
    Task<PlaylistDetail?> GetPlaylistByIdAsync(int id);
}