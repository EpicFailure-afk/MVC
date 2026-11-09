using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MVC.Controllers
{
  public class FilterController : Controller
  {
    [HandleError]
    public IActionResult Index()
    {
      throw new Exception("Exception from Filter Controller");
    }
  }
}
