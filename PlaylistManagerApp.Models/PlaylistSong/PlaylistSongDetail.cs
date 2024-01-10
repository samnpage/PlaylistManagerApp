using PlaylistManagerApp.Models.Playlist;
using PlaylistManagerApp.Models.Song;

namespace PlaylistManagerApp.Models.PlaylistSong;

public class PlaylistSongDetail
{
    public int SongId { get; set; }
    public List<SongListItem> Songs { get; set; }
    public int PlaylistId { get; set; }
    public List<PlaylistDetail> Playlist { get; set; }
}