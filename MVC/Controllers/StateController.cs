using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
  public class StateController : Controller
  {

    #region save info in session (server side)
    // By Default the MVC project does not support writing on session (server side)
    // to make mvc deal with Sessions you need to call the app.UseSession() in Main()
    // after adding this line you must put its configuration before the builder build the application 

    //State/SetSession?name=  
    public IActionResult SetSession(string name)
    {
      //Save at session
      HttpContext.Session.SetString("Name", name);
      HttpContext.Session.SetInt32("Age", 25);
      return Content("Data Session Save Success");
    }

    public IActionResult GetSession()
    {
      string n = HttpContext.Session.GetString("Name");
      int? a = HttpContext.Session.GetInt32("Age");   // GetInt32 --> return int? so must store in int? 

      return Content($"Name: {n}\t Age: {a}");
    }
    #endregion

    #region save info (per browser per user)
    // by default mvc project supports cookie 
    // Does not need a middleware 
    // server which writes the cookie 

    // Set Cookie
    public IActionResult SetCookie()
    {
      CookieOptions options = new CookieOptions();
      options.Expires = DateTime.Now.AddDays(1);

      // Session Cookie --> ends with session timeout
      HttpContext.Response.Cookies.Append("Name", "Salah");
      // persistent Cookie --> change the default options
      HttpContext.Response.Cookies.Append("Age", "58", options);
      return Content("Cookie Saved Successfully!!");
    } 
    //Get Cookie
    public IActionResult GetCookie()
    {
      string name = HttpContext.Request.Cookies["Name"];
      string age = HttpContext.Request.Cookies["Age"];
      return Content($"Name: {name}\t Age: {age}");
    }

    #endregion
  }
}
