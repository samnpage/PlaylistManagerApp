using Microsoft.EntityFrameworkCore;
using PlaylistManagerApp.Data;
using PlaylistManagerApp.Data.Entities;
using PlaylistManagerApp.Models.Song;

namespace PlaylistManagerApp.Services.Song;

public class SongService : ISongService
{
    private readonly PlaylistManagerDbContext _context;
    public SongService(PlaylistManagerDbContext context)
    {
        _context = context;
    }

    // Create
    public async Task<bool> CreateSongFromSpotifySearchResultAsync(SongCreate model)
    {
        if (!SongExists(model.SpotifyTrackID))
        {
            SongEntity entity = new()
            {
                SpotifyTrackID = model.SpotifyTrackID,
                Title = model.Title,
                Artist = model.Artist,
                DateAdded = DateTime.Now
            };

            _context.Songs.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }  

        return false;    
    }

    // Read
    public async Task<IEnumerable<SongEntity>> GetAllSongs()
    {
        return await _context.Songs.ToListAsync();
    }

    // Helper Methods
    private bool SongExists(string spotifyTrackId)
    {
        return _context.Songs.Any(s => s.SpotifyTrackID == spotifyTrackId);
    }
}