using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Repository;

namespace MVC.Controllers
{
  public class DepartmentController : Controller
  {
    //Context context = new Context();
    IDepartmentRepository departmentRepository;
    IEmployeeRepository empRepo;
    public DepartmentController(IDepartmentRepository deptRepo, IEmployeeRepository _empRepo)
    {
      departmentRepository = deptRepo;
      empRepo = _empRepo;
    }

    #region view all depts
    //Department/Index
    [Authorize]
    public IActionResult Index()
    {
      List<Department> departmentList = departmentRepository.GetAll(); //context.Department.ToList();
      return View("Index", departmentList); // Model List<Department>
    }
    #endregion

    #region add department
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
        //context.Add(newDeptFromReq);
        departmentRepository.Add(newDeptFromReq);
        //context.SaveChanges();
        departmentRepository.Save();
        //return View("Index");
        RedirectToAction("Index");
      }
      return View("Add", newDeptFromReq); // why we put newDeptFromReq
    }
    #endregion

    //department/DeptEmps
    public IActionResult DeptEmps()
    {
      return View("DeptEmps", departmentRepository.GetAll());
    }

    //department/GetEmpsByDeptId?deptID=1
    public IActionResult GetEmpsByDeptId(int deptID)
    {
      List<Employee> EmpList = empRepo.GetByDeptID(deptID);
      return Json(EmpList);
    }

  }
}
