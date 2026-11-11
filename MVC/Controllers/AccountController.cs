using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.ViewModel;

namespace MVC.Controllers
{
  public class AccountController : Controller
  {
    // ASK IOC
    private readonly UserManager<ApplicationUser> userManager;
    private readonly SignInManager<ApplicationUser> signInManager;
    public AccountController
      (UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager)
    {
      userManager = _userManager;
      signInManager = _signInManager;
    }

    [HttpGet] //Account/Register
    public IActionResult Register()
    {
      return View("Register");
    }

    [HttpPost]
    public async Task<IActionResult> SaveRegister(RegisterViewModel UserViewModel)
    {
      if(ModelState.IsValid)
      {
        // mapping
        ApplicationUser appUser = new ApplicationUser();
        appUser.Address = UserViewModel.Address;
        appUser.UserName = UserViewModel.UserName;
        appUser.PasswordHash = UserViewModel.Password;

        // save at database
        //UserManager<ApplicationUser> manager = new UserManager<ApplicationUser>();
        IdentityResult result = await userManager.CreateAsync(appUser, UserViewModel.Password);
        if (result.Succeeded)
        {
          // create cookie
          //SignInManager<ApplicationUser> signIn = new SignInManager<ApplicationUser>() // ask do not create
          await signInManager.SignInAsync(appUser, isPersistent: false); // false means the cookie will be per session 
          return RedirectToAction("Index", "Department");
        }
        foreach (var item in result.Errors)
        {
          ModelState.AddModelError("", item.Description);
        }
        // where is mapping 
      }
      return View("Register", UserViewModel);
    }

    public IActionResult SignOut()
    {
      signInManager.SignOutAsync();
      return View("Register");
    }
  }
}
