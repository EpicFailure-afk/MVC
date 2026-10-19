using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
  public class DepartmentController : Controller
  {
    Context context = new Context();
    public IActionResult Index()
    {
      List<Department> departmentList = context.Department.ToList();
      return View("Index", departmentList); // Model List<Department>
    }
  }
}
