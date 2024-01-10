namespace PlaylistManagerApp.Models.Song;

public class SongDetail
{
    public int SongId { get; set; }
    public string SpotifyTrackID { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Artist { get; set; } = string.Empty;
    public DateTimeOffset DateAdded { get; set; }
}