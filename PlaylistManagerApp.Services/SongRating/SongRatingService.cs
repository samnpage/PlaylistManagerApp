using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using PlaylistManagerApp.Data;
using PlaylistManagerApp.Data.Entities;
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
    public async Task<bool> CreateSongRatingAsync(SongRatingCreate model)
    {
        SongRatingEntity entity = new()
        {
            SongId = model.SongId,
            Rating = model.Rating
        };

        _context.Ratings.Add(entity);
        return await _context.SaveChangesAsync() == 1;
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

    //Helper methods
    // public bool SongRatingExists(int id)
    // {
    //     return _context.Ratings.Any(r => r.SongRatingId == id);
    // }
}