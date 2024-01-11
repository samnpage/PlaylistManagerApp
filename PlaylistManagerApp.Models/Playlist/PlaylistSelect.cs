namespace PlaylistManagerApp.Models.Playlist;

public class PlaylistSelect
{
    public int SongId { get; set; }
    public List<PlaylistListItem> Playlists { get; set; } = new();
}