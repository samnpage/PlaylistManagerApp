using System.ComponentModel.DataAnnotations;

namespace PlaylistManagerApp.Data.Entities;

public class SongEntity
{
    [Key]
    public int SongId { get; set; }
    public string SpotifyTrackID { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Artist { get; set; } = string.Empty;
    public DateTime DateAdded { get; set; }
}