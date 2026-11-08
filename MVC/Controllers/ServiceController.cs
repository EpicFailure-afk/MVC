using Microsoft.AspNetCore.Mvc;
using MVC.Repository;

namespace MVC.Controllers
{
  public class ServiceController : Controller
  {
    private readonly IDepartmentRepository deptRepo;

    public ServiceController(IDepartmentRepository deptRepo)  // ctor Injection
    {
      this.deptRepo = deptRepo;
    }

    // [FromServices] will not be bind, this is IOC Container job
    public IActionResult Index()// [FromServices]IDepartmentRepository deptRepo)  // Action Injection
    {
      ViewBag.Id = deptRepo.Id;
      return View("Index");
    }
  }
}
