using MVC.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.ViewModel
{
  public class EmpWithDeptListViewModel
  {
    public int Id { get; set; }
    [Display(Name = "Full Name")]
    //[DataType(DataType.Password)]
    public string Name { get; set; }
    public int Salary { get; set; }
    public string JobTitle { get; set; }
    public string ImageUrl { get; set; }
    public string Address { get; set; }
    public int DeptID { get; set; }

    public List<Department> DeptList { get; set; }
  }
}
