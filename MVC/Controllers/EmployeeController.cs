using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Models;
using MVC.ViewModel;

namespace MVC.Controllers
{
  public class EmployeeController : Controller
  {
    Context context = new Context(); // 

    #region using ViewData & ViewBag
    //Employee/Details?id=id
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
    #endregion

    #region using ViewModel

    //Employee/DetailsVM?id=1
    public IActionResult DetailsVM(int id)
    {
      Employee empModel = context.employee
        .Include(e => e.Department)
        .FirstOrDefault(e => e.Id == id);

      List<string> branches = new List<string>();
      branches.Add("Cairo");
      branches.Add("Alex");
      branches.Add("Tanta");
      branches.Add("Mansoura");

      // declare the ViewModel that contains the additional info
      EmpDeptColorTempMsgBrchViewModel EmpVM = new EmpDeptColorTempMsgBrchViewModel();

      // Mapping 
      EmpVM.EmpName = empModel.Name;
      EmpVM.DeptName = empModel.Department.Name;
      EmpVM.Color = "Red";
      EmpVM.Temp = 50;
      EmpVM.Msg = "Hello from Action";
      EmpVM.Branches = branches;

      return View("DetailsVM", EmpVM);
    }
    #endregion

    // Endpoint to view all Emps
    //Employee/Index
    public IActionResult Index()
    {
      return View("Index", context.employee.ToList());
    }

    // handle Link to edit view 
    //Employee/Edit?id=id
    public IActionResult Edit(int id)
    {
      Employee empModel = context.employee.FirstOrDefault(e => e.Id == id);
      List<Department> DepartmentList = context.Department.ToList();
      //------- create viewModel and mapping
      EmpWithDeptListViewModel EmpViewModel = new EmpWithDeptListViewModel();
      EmpViewModel.Id = empModel.Id;
      EmpViewModel.Name = empModel.Name;
      EmpViewModel.Address = empModel.Address;
      EmpViewModel.ImageUrl = empModel.ImageUrl;
      EmpViewModel.JobTitle = empModel.JobTitle;
      EmpViewModel.Salary = empModel.Salary;
      EmpViewModel.DeptList = DepartmentList;

      return View("Edit", EmpViewModel);  //Model type --> EmpWithDeptListViewModel
    }

    // Save Edit
    [HttpPost]
    public IActionResult SaveEdit(int id, EmpWithDeptListViewModel EmpFromRequest)
    {
      if (EmpFromRequest.Name != null)
      {
        // save in database
        Employee EmpFromDB = context.employee.FirstOrDefault(e => e.Id == id);
        EmpFromDB.Address = EmpFromRequest.Address;
        EmpFromDB.Name = EmpFromRequest.Name;
        EmpFromDB.Salary = EmpFromRequest.Salary;
        EmpFromDB.JobTitle = EmpFromRequest.JobTitle;
        EmpFromDB.ImageUrl = EmpFromRequest.ImageUrl;
        EmpFromDB.DeptID = EmpFromRequest.DeptID;
        context.SaveChanges();
        // after success
        return RedirectToAction("Index");
      }
      EmpFromRequest.DeptList = context.Department.ToList();  // ?? 
      return View("Edit", EmpFromRequest);
      // In that return we send the view of "Edit"
      // with EmpFromRequest (viewModel), which contains All Emp Data + list of depts
      // list of depts = null which will through an exception 
      // so we need to pass a list of depts also in the else statement
      // ViewData, ViewBag,ViewModel --> Scope: 1 Action for 1 View 
    }
  }
}
