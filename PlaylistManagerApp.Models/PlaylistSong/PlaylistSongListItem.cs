namespace PlaylistManagerApp.Models.PlaylistSong;

public class PlaylistSongListItem
{
    public int PlaylistSongId { get; set; }
    public int SongId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Artist { get; set; } = string.Empty;
    public DateTime DateAdded { get; set; }
}