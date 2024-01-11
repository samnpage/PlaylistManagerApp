using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PlaylistManagerApp.Data;
using PlaylistManagerApp.Data.Entities;
using PlaylistManagerApp.Models.Responses;
using PlaylistManagerApp.Models.User;

namespace PlaylistManagerApp.Services.User;

public class UserService : IUserService
{
    private readonly PlaylistManagerDbContext _context;
    private readonly UserManager<UserEntity> _userManager;
    private readonly SignInManager<UserEntity> _signInManager;

    public UserService(PlaylistManagerDbContext context, UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager)
    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    // Register
    public async Task<bool> RegisterUserAsync(UserRegister model)
    {
        if (await UserExistsAsync(model.Email, model.UserName))
            return false;

        UserEntity user = new()
        {
            Name = model.Name,
            UserName = model.UserName,
            Email = model.Email
        };

        var createResult = await _userManager.CreateAsync(user, model.Password);
        return createResult.Succeeded;
    }

    // Login
    public async Task<bool> LoginAsync(UserLogin model)
    {
        var user = await _userManager.FindByNameAsync(model.UserName);
        if (user is null)
            return false;

        var isValidPassword = await _userManager.CheckPasswordAsync(user, model.Password);
        if (isValidPassword == false)
            return false;

        await _signInManager.SignInAsync(user, true);
        return true;
    }

    // Logout
    public async Task LogoutAsync() => await _signInManager.SignOutAsync();

    // Read All
    public async Task<List<UserListItem>> GetAllUsersAsync()
    {
        List<UserListItem> users = await _context.Users.Select(user => new UserListItem
        {
            UserId = user.Id,
            Name = user.Name,
            RegistrationDate = user.RegistrationDate
        })
        .ToListAsync();

        return users;
    }
    // Read by Id
    public async Task<UserDetail> GetUserByIdAsync(int userId)
    {
        var user = await _context.Users.FindAsync(userId);

        UserDetail detail = new()
        {
            UserId = user.Id,
            Name = user.Name,
            RegistrationDate = user.RegistrationDate
        };

        return detail;
    }

    // Update
    public async Task<bool> EditUserByIdAsync(int userId, UserEdit model)
    {
        var userEntity = await _context.Users.FindAsync(userId);
        if (userEntity is null)
        {
            return false;
        }

        userEntity.Name = model.Name;

        _context.Users.Update(userEntity);
        await _context.SaveChangesAsync();

        return true;
    }

    // Delete
    public async Task<TextResponse> DeleteUserByIdAsync(int userId)
    {
        var userEntity = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

        if (userEntity is null)
        {
            return new TextResponse($"User #{userId} does not exist");
        }

        _context.Users.Remove(userEntity);
        await _context.SaveChangesAsync();

        return new TextResponse("User deleted successfully");
    }

    // Helper Methods
    private async Task<bool> UserExistsAsync(string email, string userName)
    {
        var normalizedEmail = _userManager.NormalizeEmail(email);
        var normalizedUserName = _userManager.NormalizeName(userName);

        return await _context.Users.AnyAsync(u => 
            u.NormalizedEmail == normalizedEmail ||
            u.NormalizedUserName == normalizedUserName
        );
    }
}