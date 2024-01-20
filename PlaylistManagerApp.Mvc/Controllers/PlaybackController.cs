using Microsoft.AspNetCore.Mvc;
using PlaylistManagerApp.Services.Playback;

namespace PlaylistManagerApp.Mvc.Controllers;

public class PlaybackController : Controller
{
    private readonly IPlaybackService _playbackService;

    public PlaybackController(IPlaybackService playbackService)
    {
        _playbackService = playbackService;
    }

    [HttpPost]
    public async Task<IActionResult> Start(string trackId)
    {
        try
        {
            await _playbackService.StartPlaybackAsync(trackId);
            return Ok("Playback started successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error starting playback: {ex.Message}");
            return StatusCode(500, "Internal Server Error");
        }
    }
}