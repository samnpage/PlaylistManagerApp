using Newtonsoft.Json;

namespace PlaylistManagerApp.Models.Search;
public class TokenResponse
{
    [JsonProperty("access_token")]
    public string AccessToken { get; set; } = null!;
}