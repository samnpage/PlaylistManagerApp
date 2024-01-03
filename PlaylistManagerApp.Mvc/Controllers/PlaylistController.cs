using Microsoft.AspNetCore.Mvc;
using PlaylistManagerApp.Models.Playlist;
using PlaylistManagerApp.Services.Playlist;

namespace PlaylistManagerApp.Mvc.Controllers;

public class PlaylistController : Controller
{
    private readonly IPlaylistService _playlistService; // Assume you have a PlaylistService

    public PlaylistController(IPlaylistService playlistService)
    {
        _playlistService = playlistService;
    }

    // GET: /Playlist/Index
    public async Task<IActionResult> Index()
    {
        var playlists = await _playlistService.GetAllPlaylistsAsync(); // Assume you have a method to get all playlists
        return View(playlists);
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        PlaylistDetail? model = await _playlistService.GetPlaylistByIdAsync(id);

        if (model is null)
            return NotFound();
        
        return View(model);
    }

    // GET: /Playlist/CreatePlaylist
    public IActionResult CreatePlaylist()
    {
        return View();
    }

    // POST: /Playlist/CreatePlaylist
    [HttpPost]
    public async Task<IActionResult> CreatePlaylist(PlaylistCreate playlist)
    {
        if (ModelState.IsValid)
        {
            await _playlistService.CreatePlaylistAsync(playlist);

            return RedirectToAction("Index", "Playlist"); // Redirect to the playlist index
        }

        return View(playlist); // Return to the view with validation errors
    }
}
