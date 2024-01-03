using System.ComponentModel.DataAnnotations;

namespace PlaylistManagerApp.Models.Playlist;

public class PlaylistEdit
{
    [Required, MaxLength(50)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(100)]
    public string Description { get; set; } = string.Empty;
}