namespace PlaylistManagerApp.Models.User;

public class UserDetail
{
    public int Id { get; set; }
    public string Email { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Name { get; set; } = string.Empty;
    public DateTimeOffset RegistrationDate { get; set; }
}