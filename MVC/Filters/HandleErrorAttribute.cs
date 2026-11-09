using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MVC.Filters
{
  public class HandleErrorAttribute : Attribute, IExceptionFilter  
  {
    public void OnException(ExceptionContext context)
    {
      // Code that written in catch 
      // context of th thrown Exception not the database Exception 

      //ContentResult contentResult = new ContentResult();
      //contentResult.Content = "Some Exception Throw";

      ViewResult viewResult = new ViewResult();
      viewResult.ViewName = "Error"; // which controller will throw the error?, so we will put this View in Shared 
      context.Result = viewResult;
    }
  }
}
