using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
  public class Employee
  {
    [Key]
    public int Id { get; set; }

    [Display(Name = "Full Name")]
    [Required(ErrorMessage ="You must type a name")]
    [MaxLength(25, ErrorMessage = "write a human name !!")]
    [MinLength(2, ErrorMessage = "Name must be more than 2 letters")]
    public string Name { get; set; }
    //[RegularExpression(@"^[0-9] {6000, }$")]

    [Range(1000, 1000000,ErrorMessage ="Salary Must be more than {1}")]
    public int Salary { get; set; }

    [Display(Name="Job Title")]
    public string JobTitle { get; set; }
    public string ImageUrl { get; set; }

    //[RegularExpression(@"(Alex|Cairo)")]  // case sensitive
    public string Address { get; set; }

    // FK
    [ForeignKey("Department")]
    [Display(Name="Department")]
    public int DeptID { get; set; }

    //nav-props
    public Department Department { get; set; }
  }
}
