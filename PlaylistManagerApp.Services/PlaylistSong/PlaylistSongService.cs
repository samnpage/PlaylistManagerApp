using Microsoft.EntityFrameworkCore;
using PlaylistManagerApp.Data;
using PlaylistManagerApp.Data.Entities;
using PlaylistManagerApp.Models.PlaylistSong;
using PlaylistManagerApp.Models.Song;
using PlaylistManagerApp.Services.Song;

namespace PlaylistManagerApp.Services.PlaylistSong;

public class PlaylistSongService : IPlaylistSongService
{
    private readonly PlaylistManagerDbContext _context;
    private readonly ISongService _songService;

    public PlaylistSongService(PlaylistManagerDbContext context, ISongService songService)
    {
        _context = context;
        _songService = songService;
    }

    // Create
    public async Task<bool> CreatePlaylistSongAsync(PlaylistSongCreate model)
    {
        var playlist = await _context.Playlists.FindAsync(model.PlaylistId);
        var song = await _context.Songs.FindAsync(model.SongId);

        if (playlist != null && song != null)
        {
            bool songExists = await _context.PlaylistSongs
                .AnyAsync(ps => ps.PlaylistId == model.PlaylistId && ps.SongId == model.SongId);

            if (!songExists)
            {
                PlaylistSongEntity entity = new()
                {
                    PlaylistId = model.PlaylistId,
                    SongId = model.SongId
                };

                await _context.PlaylistSongs.AddAsync(entity);

                return await _context.SaveChangesAsync() == 1;
            }

        }

        return false;
    }

    // Read
    public async Task<List<SongListItem>> ViewPlaylistSongByPlaylistId(int id)
    {
        var songDetails = await _context.PlaylistSongs
            .Where(ps => ps.PlaylistId == id && ps.Song != null)
            .Select(ps => new SongListItem
            {
                SongId = ps.Song.SongId,
                Title = ps.Song.Title,
                Artist = ps.Song.Artist
            })
            .ToListAsync();

        return songDetails;
    }

    // Update

    // Delete
    public async Task<bool> DeletePlaylistSongAsync(int Id)
    {
        var entity = await _context.PlaylistSongs.FirstOrDefaultAsync(ps => ps.PlaylistSongId == Id);

        if (entity is null)
        {
            return false;
        }

        _context.PlaylistSongs.Remove(entity);
        if (_context.SaveChanges() != 1)
        {
            return false;
        }

        return true;
    }
}