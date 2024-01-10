using PlaylistManagerApp.Models.Song;

namespace PlaylistManagerApp.Models.Playlist;

public class PlaylistDetail
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<SongListItem> Songs { get; set; } = null!;
}