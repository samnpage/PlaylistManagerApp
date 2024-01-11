using Microsoft.AspNetCore.Mvc;
using PlaylistManagerApp.Services.Search;

namespace PlaylistManagerApp.Mvc.Controllers;
public class SearchController : Controller
{
    private readonly ISearchService _spotifyService;

    public SearchController(ISearchService spotifyService)
    {
        _spotifyService = spotifyService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Results(string query)
    {
        // Call the SpotifyService to search for a song
        var searchResults = await _spotifyService.SearchForSong(query);

        // Pass the search results to the view
        return View("Results", searchResults);
    }
}