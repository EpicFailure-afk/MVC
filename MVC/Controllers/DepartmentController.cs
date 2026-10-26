using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
  public class DepartmentController : Controller
  {
    Context context = new Context();

    //Department/Index
    public IActionResult Index()
    {
      List<Department> departmentList = context.Department.ToList();
      return View("Index", departmentList); // Model List<Department>
    }

    [HttpGet] // only get req are allowed 
    public IActionResult Add()
    {
      return View("Add");
    }

    [HttpPost] //filter
    public IActionResult SaveAdd(Department newDeptFromReq)
    {
      if (newDeptFromReq.Name != null)
      {
        context.Add(newDeptFromReq);
        context.SaveChanges();
        //return View("Index");
        RedirectToAction("Index");
      }
      return View("Add", newDeptFromReq); // why we put newDeptFromReq
    }
  }
}
