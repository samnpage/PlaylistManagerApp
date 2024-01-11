using Microsoft.AspNetCore.Identity;
using PlaylistManagerApp.Models.Responses;
using PlaylistManagerApp.Models.User;

namespace PlaylistManagerApp.Services.User;

public interface IUserService
{
    // Create
    Task<bool> RegisterUserAsync(UserRegister model);

    // Read All
    Task<List<UserListItem>> GetAllUsersAsync();

    // Read by Id
    Task<UserDetail> GetUserByIdAsync(int userId);

    // Update
    Task<bool> EditUserByIdAsync(int userId, UserEdit model);

    // Delete
    Task<TextResponse> DeleteUserByIdAsync(int userId);

    // Login & Logout
    Task<bool> LoginAsync(UserLogin model);
    Task LogoutAsync();
}