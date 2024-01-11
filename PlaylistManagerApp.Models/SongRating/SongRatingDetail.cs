using System.ComponentModel.DataAnnotations;

namespace PlaylistManagerApp.Models.SongRating;

public class SongRatingDetail
{
    public int UserId { get; set; }
    public int SongId {get; set;}

    [Display(Name = "Title")]
    public string Title { get; set; } = null!;

    [Display(Name = "Rating")]
    public double Rating {get; set;}
}