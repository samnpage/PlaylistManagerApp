using Newtonsoft.Json;

namespace PlaylistManagerApp.Models.Spotify;
public class TokenResponse
{
    [JsonProperty("access_token")]
    public string AccessToken { get; set; } = null!;

    // You can include other properties from the response if needed
}