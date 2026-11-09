using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


// Or put the attr in Program.cs ( before Builder build)
namespace MVC.Controllers
{
  // [HandleError] // or put the attr on a class (Controller) level
  [Authorize]
  public class FilterController : Controller
  {
    //[HandleError]  // i can put the attr on a single action level
    [AllowAnonymous]  // for Login case guest user --> override on [Authorize]
    public IActionResult Index()
    {
      throw new Exception("Exception from Filter Controller");
    }

    //[HandleError]
    public IActionResult Index_2()
    {
      throw new Exception("Exception from Filter Controller");
    }

  }
}
