using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Models;
using MVC.Repository;
using MVC.ViewModel;

namespace MVC.Controllers
{
  public class EmployeeController : Controller
  {
    //Context context = new Context();
    DepartmentRepository departmentRepository;
    EmployeeRepository employeeRepository;

    public EmployeeController()
    {
      departmentRepository = new DepartmentRepository();
      employeeRepository = new EmployeeRepository();
    }
    #region using ViewData & ViewBag
    // View Details about Emp
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

      Employee empModel = employeeRepository.FindByID(id); 
      // pass the model (Employee to the View)
      return View("Details", empModel);
    }
    #endregion

    #region using ViewModel

    //Employee/DetailsVM?id=1
    public IActionResult DetailsVM(int id)
    {
      Employee empModel = employeeRepository.FindByID(id);

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
      return View("Index", employeeRepository.GetAll());
    }

    // handle Link to edit view 
    //Employee/Edit?id=id
    [HttpPost]
    public IActionResult Edit(int id)
    {
      Employee empModel = employeeRepository.FindByID(id);
      List<Department> DepartmentList = departmentRepository.GetAll();
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
      //if (EmpFromRequest.Name != null)
      if(ModelState.IsValid)  // check what is ModelState and how it works 
      {
        // save in database
        Employee EmpFromDB = employeeRepository.FindByID(id);
        // mapping
        EmpFromDB.Address = EmpFromRequest.Address;
        EmpFromDB.Name = EmpFromRequest.Name;
        EmpFromDB.Salary = EmpFromRequest.Salary;
        EmpFromDB.JobTitle = EmpFromRequest.JobTitle;
        EmpFromDB.ImageUrl = EmpFromRequest.ImageUrl;
        EmpFromDB.DeptID = EmpFromRequest.DeptID;
        EmpFromDB.Id = EmpFromRequest.Id; //why??
        employeeRepository.Update(EmpFromDB);
        employeeRepository.Save();
        // after success
        return RedirectToAction("Index");
      }
      EmpFromRequest.DeptList = departmentRepository.GetAll();   
      return View("Edit", EmpFromRequest);
      // In that return we send the view of "Edit"
      // with EmpFromRequest (viewModel), which contains All Emp Data + list of depts
      // list of depts = null which will through an exception 
      // so we need to pass a list of depts also in the else statement
      // ViewData, ViewBag,ViewModel --> Scope: 1 Action for 1 View 
    }

    // Add new Emp
    //Employee/New
    [HttpGet]
    public IActionResult New()
    {
      ViewData["DeptList"] = departmentRepository.GetAll(); 
      return View("New"); // open "New" View 
    }

    [HttpPost]
    public IActionResult SaveNew(Employee EmpFromReq)
    {
      // Validation 
      if(ModelState.IsValid) // && EmpFromReq.Salary>=6000)  // performance ??
      {
        // custom validation Dept_ID != 0
        if (EmpFromReq.DeptID != 0) {
          try
          {
            // if valid --> save to database 
            //context.employee.Add(EmpFromReq);
            employeeRepository.Add(EmpFromReq);
            //context.SaveChanges();
            employeeRepository.Save();
            return RedirectToAction("Index");
          }
          catch (Exception ex) // general exception
          {
            ModelState.AddModelError("", ex.Message);
          }
        }
        else
        {
          // error message send to view 
          ModelState.AddModelError("DeptID", "Must choose a department");
          // if the key is not found 
          // the error message will pass to the div errors --> asp-validation-summary
        }
      }
      // if not valid back to the action that req came from with the req itself
      ViewData["DeptList"] = departmentRepository.GetAll();
      return View("New", EmpFromReq);  
    }

    // Remote Attribute using Ajax Call
    [HttpGet]
    public IActionResult CheckName(string Name)
    {
      if (Name.Contains("dev"))
        return Json(true);
      return Json(false);
    }
  }
}
