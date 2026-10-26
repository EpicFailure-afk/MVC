using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
  public class BindController : Controller
  {
    //bind/TestPrimitive?name=ahmed&age=25

    /*
     <form method="get" action="/Bind/TestPrimitive">
        <input type="text" name="name" />
        <input type="number" name="age" />
        <button type="submit">Submit</button>
     </ form>
    */
    public IActionResult TestPrimitive(string name, int age, int id, string[] Color)
    {
      return Content($"name: {name}\t age: {age} \t {id}");
    }

    //Bind Collection 
    //Bind/TestDic?Phones[Ahmed]=0106234&Phones[mo]=73482356,name=ahmed
    public IActionResult TestDic(Dictionary<string, string> Phones, string name)
    {
      return Content("OK");
    }

    //Bind Custom Types (classes)  Complex object
    //Bind/testObj?name=SD&managername=salah&emps[0].Name=ahmed&xyzName=moo
    public IActionResult testObj(Department deptObj, string xyzName)
    {
      return Content("Ok");
    }

  }
}
