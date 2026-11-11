using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace MVC.ViewModel
{
  public class LoginUserViewModel
  {
    [Required(ErrorMessage = "*")]
    public string Name { get; set; }

    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name="Remember Me!!")]
    public bool RememberME { get; set; }
  }
}
