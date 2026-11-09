using Microsoft.AspNetCore.Mvc.Filters;

namespace MVC.Filters
{
  public class MyCustomAttribute : Attribute, IActionFilter
  {
    // before the action executes
    public void OnActionExecuted(ActionExecutedContext context)
    { }
    
    // after action executed and before the action result 
    public void OnActionExecuting(ActionExecutingContext context)
    { }
  }
}
