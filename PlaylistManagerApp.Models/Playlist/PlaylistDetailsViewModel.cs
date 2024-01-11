using PlaylistManagerApp.Models.PlaylistSong;
using PlaylistManagerApp.Models.Song;

namespace PlaylistManagerApp.Models.Playlist;

public class PlaylistDetailsViewModel
{
    public int PlaylistId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    // public int PlaylistSongId { get; set; }
    public List<PlaylistSongListItem> Song { get; set; } = null!;
}