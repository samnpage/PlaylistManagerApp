using Microsoft.AspNetCore.Mvc;
using PlaylistManagerApp.Services.Spotify;

namespace PlaylistManagerApp.Mvc.Controllers;
public class SpotifyController : Controller
{
    private readonly ISpotifyService _spotifyService;

    public SpotifyController(ISpotifyService spotifyService)
    {
        _spotifyService = spotifyService;
    }

    public IActionResult SearchSong()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SearchSong(string query)
    {
        // Call the SpotifyService to search for a song
        var searchResults = await _spotifyService.SearchForSong(query);

        // Pass the search results to the view
        return View("SearchResults", searchResults);
    }
}