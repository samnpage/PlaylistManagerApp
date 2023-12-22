using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PlaylistManagerApp.Data;
using PlaylistManagerApp.Data.Entities;
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

    public async Task LogoutAsync() => await _signInManager.SignOutAsync();

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