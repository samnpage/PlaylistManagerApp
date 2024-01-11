using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PlaylistManagerApp.Data.Entities;

[PrimaryKey(nameof(UserId), nameof(SongId))]
public class SongRatingEntity
{
    public int SongRatingId { get; set; }
    
    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    public virtual UserEntity User { get; set; } = null!;

    [ForeignKey(nameof(Song))]
    public int SongId { get; set; }
    public virtual SongEntity Song { get; set; } = null!;

    public bool IsFavorite { get; set; }

    [Required, Range(0,5)]
    public double Rating { get; set; }
}