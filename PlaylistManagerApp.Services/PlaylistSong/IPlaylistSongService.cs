using PlaylistManagerApp.Models.Playlist;
using PlaylistManagerApp.Models.PlaylistSong;
using PlaylistManagerApp.Models.Song;

namespace PlaylistManagerApp.Services.PlaylistSong;

public interface IPlaylistSongService
{
    //Create
    Task<bool> CreatePlaylistSongAsync(PlaylistSongCreate model);

    //Read
    Task<PlaylistDetailsViewModel> ViewPlaylistSongByPlaylistId(int id);
    
    //Update
    
    //Delete
    Task<bool> DeletePlaylistSongAsync(int Id);
}