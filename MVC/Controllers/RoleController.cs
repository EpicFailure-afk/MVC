using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC.ViewModel;

namespace MVC.Controllers
{
  public class RoleController : Controller
  {
    // Injection 
    private readonly RoleManager<IdentityRole> roleManager;
    public RoleController(RoleManager<IdentityRole> _roleManager)
    {
      roleManager = _roleManager;
    }

    [HttpGet]
    public IActionResult AddRole()
    {
      return View("AddRole");
    }

    [HttpPost]
    public async Task<IActionResult> SaveRole(RoleViewModel roleViewModel)
    {
      if (ModelState.IsValid)
      {
        //Mapping 
        IdentityRole role = new IdentityRole();
        role.Name = roleViewModel.RoleName;
        // to save role we use --> RoleManager (do not create ASK), Inject it
        IdentityResult result = await roleManager.CreateAsync(role);
        if (result.Succeeded == true)
        {
          return View("AddRole");
        }
        foreach(var item in result.Errors)
        {
          ModelState.AddModelError("", item.Description);
        }
      }
      return View("AddRole", roleViewModel);
    }
  }
}
