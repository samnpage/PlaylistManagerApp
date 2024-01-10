using Microsoft.AspNetCore.Mvc;
using PlaylistManagerApp.Models.Playlist;
using PlaylistManagerApp.Models.PlaylistSong;
using PlaylistManagerApp.Models.Song;
using PlaylistManagerApp.Services.Playlist;
using PlaylistManagerApp.Services.PlaylistSong;
using PlaylistManagerApp.Services.Song;

namespace PlaylistManagerApp.Mvc.Controllers;

public class PlaylistController : Controller
{
    private readonly IPlaylistService _playlistService;
    private readonly ISongService _songService;
    private readonly IPlaylistSongService _playlistSongService;

    public PlaylistController(IPlaylistService playlistService, ISongService songService, IPlaylistSongService playlistSongService)
    {
        _playlistService = playlistService;
        _songService = songService;
        _playlistSongService = playlistSongService;
    }

    // GET: /Playlist
    public async Task<IActionResult> Index()
    {
        var playlists = await _playlistService.GetAllPlaylistsAsync();
        return View(playlists);
    }

    // GET: /Playlist/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: /Playlist/Create
    [HttpPost]
    public async Task<IActionResult> Create(PlaylistCreate playlist)
    {
        if (ModelState.IsValid)
        {
            await _playlistService.CreatePlaylistAsync(playlist);

            return RedirectToAction("Index", "Playlist"); // Redirect to the playlist index
        }

        return View(playlist); // Return to the view with validation errors
    }

    // GET: /Playlist/Details/#
    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var playlist = await _playlistService.GetPlaylistByIdAsync(id);
        var songDetails = await _playlistSongService.ViewPlaylistSongByPlaylistId(id);

        if (playlist is null)
            return RedirectToAction(nameof(Index));

        var model = new PlaylistDetailWithSongs
        {
            Id = playlist.Id,
            Title = playlist.Title,
            Description = playlist.Description,
            Songs = songDetails
        };
        return View(model);
    }

    // GET: /Playlist/Edit/#
    [HttpGet]
    public IActionResult Edit()
    {
        return View();
    }

    //POST: /Playlist/Edit/#
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit([FromRoute] int id, PlaylistEdit model)
    {
        if (ModelState.IsValid)
        {
            var playlist = _playlistService.EditPlaylistByIdAsync(id, model);
            if (playlist == null)
            {
                return NotFound();
            }
            if (playlist != null)
            {
                return RedirectToAction(nameof(Details)); // Redirect to the playlist index
            }
        }

        TempData["ErrorMsg"] = "Unable to save to the database. Please try again later.";
        return View(model);
    }

    // GET: customer/delete/{id}
    public async Task<IActionResult> Delete(int id)
    {
        var entity = await _playlistService.DeletePlaylistByIdAsync(id);

        if (entity == false)
        {
            TempData["ErrorMsg"] = $"Playlist #{id} does not exist";
            return RedirectToAction(nameof(Index));
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Add(int playlistId, int songId)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction("Select");
        }

        PlaylistSongCreate model = new()
        {
            PlaylistId = playlistId,
            SongId = songId
        };


        var success = await _playlistSongService.CreatePlaylistSongAsync(model);

        if (success)
        {
            return RedirectToAction("Index", "Search");
        }
        else
        {
            TempData["ErrorMsg"] = "Song already exists in the playlist";
            return RedirectToAction("Select");
        }
    }


    // POST: /Playlist/Select
    public async Task<IActionResult> Select(SongCreate song)
    {
        int songId = await _songService.CreateSongAsync(song);

        var playlists = await _playlistService.GetAllPlaylistsAsync();

        var model = new PlaylistSelect
        {
            SongId = songId,
            Playlists = playlists.Select(p => new PlaylistListItem
            {
                Id = p.Id,
                Title = p.Title
            }).ToList()
        };

        return View(model);
    }

    public async Task<IActionResult> RemoveSong(int id)
    {
        await _playlistSongService.DeletePlaylistSongAsync(id);

        return View();
    }

}
