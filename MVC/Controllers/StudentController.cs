using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
  public class StudentController : Controller
  {
    //Student/ShowAll
    public IActionResult ShowAll()
    {
      StudentBL studentBL = new StudentBL();  // object from StudentBL 
      List<Student> StudentListModel = studentBL.GetAll(); // list of studs = calling the function 
      //return View("ShowAll"); // will not pass any data to the view page

      return View("ShowAll", StudentListModel);  // send data to View  
    }

    //Student/ShowDetails?id=1
    public IActionResult ShowDetails(int id)
    {
      StudentBL studentBL = new StudentBL(); // object from StudentBL so i can use its functions 
      Student studentModel = studentBL.GetById(id); // use StudentBL function on the model (object)
      return View("ShowDetails", studentModel); // pass data to the view 
    }
  }
}
