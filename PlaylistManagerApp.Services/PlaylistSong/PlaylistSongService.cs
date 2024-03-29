using Microsoft.EntityFrameworkCore;
using PlaylistManagerApp.Data;
using PlaylistManagerApp.Data.Entities;
using PlaylistManagerApp.Models.Playlist;
using PlaylistManagerApp.Models.PlaylistSong;

namespace PlaylistManagerApp.Services.PlaylistSong;

public class PlaylistSongService : IPlaylistSongService
{
    private readonly PlaylistManagerDbContext _context;

    public PlaylistSongService(PlaylistManagerDbContext context)
    {
        _context = context;
    }

    // Create
    public async Task<bool> CreatePlaylistSongAsync(PlaylistSongCreate model)
    {
        // Finds song and playlist by their id's
        var playlist = await _context.Playlists.FindAsync(model.PlaylistId);
        var song = await _context.Songs.FindAsync(model.SongId);

        if (playlist != null && song != null)
        {
            // checks to see if it exists
            bool songExists = await _context.PlaylistSongs
                .AnyAsync(ps => ps.PlaylistId == model.PlaylistId && ps.SongId == model.SongId);

            // If it doen't exist it creates a new entity and saves it to the database
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
    public async Task<PlaylistDetailsViewModel> ViewPlaylistSongByPlaylistId(int id)
    {
        PlaylistDetailsViewModel details = new()
        {
            PlaylistId = id,
            Title = await GetPlaylistTitleByIdAsync(id),
            Description = await GetPlaylistDescriptionByIdAsync(id),
            Song = new List<PlaylistSongListItem>(),
        };

        // Creates a list that matches the playlistId
        var playlistSongs = await _context.PlaylistSongs
            .Include(ps => ps.Song)
            .Include(ps => ps.Playlist)
            .Where(ps => ps.PlaylistId == id && ps.Song != null)
            .ToListAsync();

        // adds each song's properties to a new model
        foreach (var song in playlistSongs)
        {
            details.Song.Add(new PlaylistSongListItem
            {
                PlaylistSongId = song.PlaylistSongId,
                SongId = song.SongId,
                Title = song.Song.Title,
                Artist = song.Song.Artist,
                DateAdded = song.Song.DateAdded
            });
        }

        return details;
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
    
    // Helper Methods
    // Method that gets a playlist title by Id return string
    private async Task<string> GetPlaylistTitleByIdAsync(int id)
    {
        return (await _context.Playlists.FirstOrDefaultAsync(r => r.PlaylistId == id)).Title;
    }

    // Method that get playlist description by Id retrun string 
    private async Task<string> GetPlaylistDescriptionByIdAsync(int id)
    {
        return (await _context.Playlists.FirstOrDefaultAsync(r => r.PlaylistId == id)).Description;
    }
}