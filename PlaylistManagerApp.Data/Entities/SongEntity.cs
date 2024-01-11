using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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