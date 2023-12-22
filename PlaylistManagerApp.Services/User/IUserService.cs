using Microsoft.AspNetCore.Identity;
using PlaylistManagerApp.Models.User;

namespace PlaylistManagerApp.Services.User;

public interface IUserService
{
    Task<bool> RegisterUserAsync(UserRegister model);
    Task<bool> LoginAsync(UserLogin model);
    Task LogoutAsync();
}