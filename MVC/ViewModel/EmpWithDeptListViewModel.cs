using MVC.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.ViewModel
{
  public class EmpWithDeptListViewModel
  {
    [Key]
    public int Id { get; set; }

    [Display(Name = "Full Name")]
    [Required]
    [MaxLength(25)]
    [MinLength(2)]
    public string Name { get; set; }
    //[RegularExpression(@"^[0-9] {6000, }$")]


    public int Salary { get; set; }

    [Display(Name = "Job Title")]
    public string JobTitle { get; set; }
    public string ImageUrl { get; set; }

    //[RegularExpression(@"(Alex|Cairo)")]  // case sensitive
    public string Address { get; set; }

    // FK
    [ForeignKey("Department")]
    [Display(Name = "Department")]
    public int DeptID { get; set; }

    public List<Department> DeptList { get; set; }
  }
}
