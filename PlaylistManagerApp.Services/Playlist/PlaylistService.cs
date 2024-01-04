using Microsoft.EntityFrameworkCore;
using PlaylistManagerApp.Data;
using PlaylistManagerApp.Data.Entities;
using PlaylistManagerApp.Models.Playlist;

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

    // Get all playlists
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

    public async Task<PlaylistDetail?> GetPlaylistByIdAsync(int id)
    {
        PlaylistEntity? playlist = await _context.Playlists.FirstOrDefaultAsync(r => r.PlaylistId == id);

            return playlist is null ? null : new()
            {
                Id = playlist.PlaylistId,
                Title = playlist.Title,
                Description = playlist.Description,
            };
    }

    // public async Task AddSongToPlaylist(int playlistId, SearchResult song)
    // {
    //     var playlist = await _context.Playlists.FindAsync(playlistId);

    //     if (playlist != null)
    //     {
    //         playlist.Songs.Add(song);

    //         await _context.SaveChangesAsync();
    //     }
    // }
}