using PlaylistManagerApp.Models.User;
using PlaylistManagerApp.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace PlaylistManagerApp.Mvc.Controllers;

public class AccountController : Controller
{
    private readonly IUserService _userService;

    public AccountController(IUserService userService)
    {
        _userService = userService;
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