using System.ComponentModel.DataAnnotations;

namespace PlaylistManagerApp.Models.User;

public class UserRegister
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(10, ErrorMessage = "Must be between 4 and 10 characters", MinimumLength = 3)]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Username is required")]
    [StringLength(10, ErrorMessage = "Must be between 4 and 10 characters", MinimumLength = 3)]
    public string UserName { get; set; } = null!;

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Password is required")]
    [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Required(ErrorMessage = "Confirm password is required")]
    [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
    [DataType(DataType.Password)]
    [Compare("Password")]
    public string ConfirmPassword { get; set; } = null!;
}