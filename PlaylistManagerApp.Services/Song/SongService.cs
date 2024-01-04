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
    public async Task CreateSongFromSpotifySearchResultAsync(SongCreate model)
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
    }

    public async Task<IEnumerable<SongEntity>> GetAllSongs()
    {
        return _context.Songs.ToList();
    }
}