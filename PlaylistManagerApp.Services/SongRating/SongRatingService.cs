using Microsoft.Identity.Client;
using PlaylistManagerApp.Data;
using PlaylistManagerApp.Models.SongRating;

namespace PlaylistManagerApp.Services.SongRating;

public class SongRatingService : ISongRatingService
{
    private readonly PlaylistManagerDbContext _context;

    public SongRatingService(PlaylistManagerDbContext context)
    {
        _context = context;
    }

    // Create
    public Task<bool> CreateSongRatingAsync(SongRatingCreate model)
    {
        throw new NotImplementedException();
    }

    // Get by Id
    public Task<SongRatingDetail> GetRatingByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    // Get all ratings
    public Task<List<SongRatingListItem>> GetRatingsAsync()
    {
        throw new NotImplementedException();
    }

    // Get all ratings for an idividual song
    public Task<List<SongRatingListItem>> GetSongRatingsAsync(int songId)
    {
        throw new NotImplementedException();
    }

    // Update

    // Delete
    public Task<bool> DeleteSongRatingAsync(int id)
    {
        throw new NotImplementedException();
    }
}