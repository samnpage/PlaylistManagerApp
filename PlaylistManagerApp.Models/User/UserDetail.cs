namespace PlaylistManagerApp.Models.User;

public class UserDetail
{
    public int UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTimeOffset RegistrationDate { get; set; }
}