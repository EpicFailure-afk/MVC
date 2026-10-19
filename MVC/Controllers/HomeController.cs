using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Diagnostics;

namespace MVC.Controllers
{
  public class HomeController : Controller
  {
    //Home/ShowMsg
    public ContentResult ShowMsg()
    {
      ContentResult result = new ContentResult();  // declare
      result.Content = "Msg says: Ahmed Salah"; // initialize
      return result; // return
    }

    //Home/View1
    public ViewResult View1()
    {
      ViewResult result = new ViewResult();
      result.ViewName = "View1";
      return result;
    }

    //Home/ShowMix?id=1
    public IActionResult ShowMix(int id)
    {
      if (id % 2 == 0)
      {
        //ViewResult result = new ViewResult();
        //result.ViewName = "View1";
        //return result;

        return View("View1");
      }
      else
      {
        //ContentResult result = new ContentResult();
        //result.Content = "Content";
        //return result;

        return Content("Ahmed Salah");
      }
    }

    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
