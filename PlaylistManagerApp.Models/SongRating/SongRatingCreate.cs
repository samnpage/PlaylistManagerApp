using System.ComponentModel.DataAnnotations;

namespace PlaylistManagerApp.Models.SongRating;

public class SongRatingCreate
{
    [Required]
    [Display(Name = "Restaurant")]
    public int SongId { get; set; }

    [Required, Range(1, 5)]
    [Display(Name = "Rating")]
    public double Score { get; set; }
}