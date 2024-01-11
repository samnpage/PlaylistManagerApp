using PlaylistManagerApp.Models.Playlist;
using PlaylistManagerApp.Models.Song;

namespace PlaylistManagerApp.Models.PlaylistSong;

public class PlaylistSongDetail
{
    public int PlaylistSongId { get; set; }
    public int PlaylistId { get; set; }
    public int SongId { get; set; }
}