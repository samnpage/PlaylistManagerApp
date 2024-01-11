namespace PlaylistManagerApp.Models.Song;

public class SongListItem
{
    public int SongId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Artist { get; set; } = string.Empty;
    public DateTime DateAdded { get; set; }
}