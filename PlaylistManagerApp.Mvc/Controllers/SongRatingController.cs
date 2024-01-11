using Microsoft.AspNetCore.Mvc;
using PlaylistManagerApp.Models.SongRating;
using PlaylistManagerApp.Services.SongRating;

namespace PlaylistManagerApp.Mvc.Controllers;

public class SongRatingController : Controller
{
    private readonly ISongRatingService _service;

    public SongRatingController(ISongRatingService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Create(int id)
    {
        SongRatingCreate model = new()
        {
            SongId = id
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Create(SongRatingCreate model)
    {
        if (!ModelState.IsValid)
            return View(model);

        await _service.CreateSongRatingAsync(model);

        return RedirectToAction("Index");
    }
}