using Microsoft.AspNetCore.Mvc;
using PlaylistManagerApp.Models.Song;
using PlaylistManagerApp.Services.Song;

namespace PlaylistManagerApp.Mvc.Controllers;

public class SongController : Controller
{
    private readonly ISongService _songService;

    public SongController(ISongService songService)
    {
        _songService = songService;
    }

    [HttpPost]
    public async Task<IActionResult> Add(SongCreate model)
    {
        await _songService.CreateSongFromSpotifySearchResultAsync(model);
        return RedirectToAction("Index");        
    }
}