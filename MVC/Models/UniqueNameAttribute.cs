using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
  public class UniqueNameAttribute : ValidationAttribute
  {
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
      if (value == null)
        return null;
      string newName = value.ToString();
      Context context = new Context();
      Employee emp = context.employee.FirstOrDefault(e=>e.Name==newName);
      if (emp.Name != null)
      {
        return new ValidationResult("Name Must be Unique"); 
      }
      return ValidationResult.Success;
    }
  }
}
