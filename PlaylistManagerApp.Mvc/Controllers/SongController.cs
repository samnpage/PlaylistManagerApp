using Microsoft.AspNetCore.Mvc;
using PlaylistManagerApp.Data.Entities;
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

    public async Task<IActionResult> CreateSong([FromBody] SongCreate model)
    {
        await _songService.CreateSongFromSpotifySearchResultAsync(model);
        return Json(new { success = true });        
    }
}