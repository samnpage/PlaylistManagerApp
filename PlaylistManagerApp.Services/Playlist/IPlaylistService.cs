using PlaylistManagerApp.Models.Playlist;

namespace PlaylistManagerApp.Services.Playlist;

public interface IPlaylistService
{
    // Create
    Task CreatePlaylistAsync(PlaylistCreate playlist);

    // Read
    Task<IEnumerable<PlaylistListItem>> GetAllPlaylistsAsync();
    Task<PlaylistDetail?> GetPlaylistByIdAsync(int playlistId);

    // Update
    Task<bool> EditPlaylistByIdAsync(int playlistId, PlaylistEdit model);

    // Delete
    Task<bool> DeletePlaylistByIdAsync(int playlistId);
}