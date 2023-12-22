using System.ComponentModel.DataAnnotations;

namespace PlaylistManagerApp.Data.Entities;

public class PlaylistEntity
{
    [Key]
    public int PlaylistId { get; set; }
    public int UserId { get; set; }

    [Required, MaxLength(50)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(100)]
    public string Description { get; set; } = string.Empty;
}