namespace PlaylistManagerApp.Models.Spotify;

public class SearchResult
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public List<SearchArtist> Artists { get; set; } = null!;
    public string Uri { get; set; } = string.Empty;
}