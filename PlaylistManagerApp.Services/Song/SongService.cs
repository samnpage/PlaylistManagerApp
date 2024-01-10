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
    public async Task<int> CreateSongAsync(SongCreate model)
    {
        // Check if the song already exists
        var existingSong = await _context.Songs
            .FirstOrDefaultAsync(s => s.SpotifyTrackID == model.SpotifyTrackID);

        if (existingSong != null)
        {
            // Return the existing song's ID
            return existingSong.SongId;
        }

        // Song doesn't exist, create a new one
        SongEntity entity = new()
        {
            SpotifyTrackID = model.SpotifyTrackID,
            Title = model.Title,
            Artist = model.Artist,
            DateAdded = DateTime.Now
        };

        _context.Songs.Add(entity);
        await _context.SaveChangesAsync();

        // Return the newly created song's ID
        return entity.SongId;
    }


    // Get all songs
    public async Task<List<SongListItem>> GetAllSongs()
    {
        List<SongListItem> songs = await _context.Songs
            .Select(song => new SongListItem
            {
                Title = song.Title,
                Artist = song.Artist,
                DateAdded = song.DateAdded
            })
            .ToListAsync();

        return songs;
    }

    // Get song by Id
    public async Task<SongDetail> GetSongByIdAsync(int songId)
    {
        var song = await _context.Songs.FirstOrDefaultAsync(s => s.SongId == songId);

        SongDetail detail = new()
        {
            SongId = song.SongId,
            SpotifyTrackID = song.SpotifyTrackID,
            Title = song.Title,
            Artist = song.Artist,
            DateAdded = song.DateAdded
        };

        return detail;

    }

    // Helper Methods
    // private bool SongExists(string spotifyTrackId)
    // {
    //     return _context.Songs.Any(s => s.SpotifyTrackID == spotifyTrackId);
    // }
}