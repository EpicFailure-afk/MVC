using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
  public class Employee
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public int Salary { get; set; }

    [Display(Name="Job Title")]
    public string JobTitle { get; set; }
    public string ImageUrl { get; set; }
    public string Address { get; set; }

    // FK
    [ForeignKey("Department")]
    [Display(Name="Department")]
    public int DeptID { get; set; }

    //nav-props
    public Department Department { get; set; }
  }
}
