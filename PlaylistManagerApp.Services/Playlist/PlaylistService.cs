using Microsoft.EntityFrameworkCore;
using PlaylistManagerApp.Data;
using PlaylistManagerApp.Data.Entities;
using PlaylistManagerApp.Models.Playlist;
using PlaylistManagerApp.Models.Song;

namespace PlaylistManagerApp.Services.Playlist;

public class PlaylistService : IPlaylistService
{
    private readonly PlaylistManagerDbContext _context;

    public PlaylistService(PlaylistManagerDbContext context)
    {
        _context = context;
    }

    // Create
    public async Task CreatePlaylistAsync(PlaylistCreate playlist)
    {
        PlaylistEntity entity = new()
        {
            Title = playlist.Title,
            Description = playlist.Description
        };

        _context.Playlists.Add(entity);
        await _context.SaveChangesAsync();
    }

    // Read All
    public async Task<IEnumerable<PlaylistListItem>> GetAllPlaylistsAsync()
    {
        List<PlaylistListItem> playlists = await _context.Playlists
            .Select(l => new PlaylistListItem()
            {
                Id = l.PlaylistId,
                Title = l.Title
            })
            .ToListAsync();

        return playlists;
    }

    // Read by Id
    public async Task<PlaylistDetail?> GetPlaylistByIdAsync(int playlistId)
    {
        PlaylistEntity? playlist = await _context.Playlists.FirstOrDefaultAsync(r => r.PlaylistId == playlistId);

        return playlist is null ? null : new()
        {
            Id = playlist.PlaylistId,
            Title = playlist.Title,
            Description = playlist.Description,
        };
    }

    // Update
    public async Task<bool> EditPlaylistByIdAsync(int playlistId, PlaylistEdit model)
    {
        PlaylistEntity entity = _context.Playlists.Find(playlistId);

        if (entity is null)
        {
            return false;
        }

        entity.Title = model.Title;
        entity.Description = model.Description;

        return await _context.SaveChangesAsync() == 1;
    }

    // Delete
    public async Task<bool> DeletePlaylistByIdAsync(int playlistId)
    {
        var playlistEntity = await _context.Playlists.FirstOrDefaultAsync(p => p.PlaylistId == playlistId);

        if (playlistEntity is null)
        {
            return false;
        }

        _context.Playlists.Remove(playlistEntity);

        return await _context.SaveChangesAsync() == 1;
    }
}