using PlaylistManagerApp.Models.User;
using PlaylistManagerApp.Services.User;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace PlaylistManagerApp.Mvc.Controllers;

public class AccountController : Controller
{
    private readonly IUserService _userService;
    private int _userId;

    public AccountController(IUserService userService, int userId)
    {
        _userService = userService;
        _userId = userId;
    }

    private void AssignUserId()
    {
        if (User.Identity.IsAuthenticated)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            string userId = claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            _userId = int.Parse(userId);
        }
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(UserRegister model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var registerResult = await _userService.RegisterUserAsync(model);
        if (registerResult == false)
            return View(model);

        UserLogin loginModel = new()
        {
            UserName = model.UserName,
            Password = model.Password
        };
        await _userService.LoginAsync(loginModel);
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(UserLogin model)
    {
        var loginResult = await _userService.LoginAsync(model);
        if (loginResult == false)
            return View(model);

        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> Logout()
    {
        await _userService.LogoutAsync();
        return RedirectToAction("Index", "Home");
    }
}