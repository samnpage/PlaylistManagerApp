namespace PlaylistManagerApp.Models.Song;

public class SongCreate
{
    public string SpotifyTrackID { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Artist { get; set; } = string.Empty;
}