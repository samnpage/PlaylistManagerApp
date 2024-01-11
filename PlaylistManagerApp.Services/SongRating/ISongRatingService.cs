using PlaylistManagerApp.Models.SongRating;

namespace PlaylistManagerApp.Services.SongRating;

public interface ISongRatingService
{
    // Create
    Task<bool> CreateSongRatingAsync(SongRatingCreate model);

    // Read
    Task<List<SongRatingListItem>> GetRatingsAsync();
    Task<List<SongRatingListItem>> GetSongRatingsAsync(int songId);
    Task<SongRatingDetail> GetRatingByIdAsync(int id);

    // Update

    // Delete
    Task<bool> DeleteSongRatingAsync(int id);
}