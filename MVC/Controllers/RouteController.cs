using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
  public class RouteController : Controller
  {
    //R1
    public IActionResult Method1(string name,int age)
    {
      return Content("M1");
    }
    //R2
    public IActionResult Method2()
    {
      return Content("M2");
    }
  }
}
