namespace PlaylistManagerApp.Services.Playback;

public interface IPlaybackService
{
    Task StartPlaybackAsync(string trackId);
}