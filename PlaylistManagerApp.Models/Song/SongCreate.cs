namespace PlaylistManagerApp.Models.Song;

public class SongCreate
{
    public int SpotifyTrackID { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Artist { get; set; } = string.Empty;
}