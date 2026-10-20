using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
  public class EmployeeController : Controller
  {
    Context context = new Context(); // 
    public IActionResult Details(int id)
    {
      //Additional information need to send with the Employee details 
      string msg = "Hello from Action"; //1
      int temp = 20; //2

      List<string> Branches = new List<string>(); //3
      Branches.Add("Cairo");
      Branches.Add("Alex");
      Branches.Add("Tanta");
      Branches.Add("Mansoura");

      // ViewData --> Dictionary ( key(string), value(obj))
      ViewData["Msg"] = msg;
      ViewData["Temp"] = temp;
      ViewData["Brchs"] = Branches;
      ViewBag.Color = "red";

      Employee empModel = context.employee.FirstOrDefault(e => e.Id == id); //4 (Model)
      // pass the model (Employee to the View)
      return View("Details", empModel);
    }
  }
}
