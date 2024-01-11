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

    public Task<bool> CreateSongRatingAsync(SongRatingCreate model)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteSongRatingAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<SongRatingDetail> GetRatingByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<SongRatingListItem>> GetRatingsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<SongRatingListItem>> GetSongRatingsAsync(int songId)
    {
        throw new NotImplementedException();
    }
}