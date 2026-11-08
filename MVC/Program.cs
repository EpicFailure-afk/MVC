using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MVC.Models;
using MVC.Repository;

namespace MVC
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var builder = WebApplication.CreateBuilder(args);

      // Add services to the container.
      builder.Services.AddControllersWithViews();

      // how to use --> app.UseSession() <-- Middleware
      // // adding its configuration: 
      // // if you let AddSession() without parameters will use the default config
      builder.Services.AddSession(Options =>
      {
        Options.IdleTimeout = TimeSpan.FromMinutes(30);  // allow idle for 30 minutes using AddSession 
      });

      // Register BdContext
      builder.Services.AddDbContext<Context>(Options =>
      {
        Options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
      });

      // Custom Service: (Register)
      builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
      builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
      /*
       * Types of service lifetime:
       * - AddScoped --> once per req
       * - AddSingleton --> once per application
       * - AddTransient --> one for every single resolve even it comes from the same req
      */

      var app = builder.Build();

      /*
        Types of Middleware:
        1. app.Use() --> Execute, Invoke Next
        2. app.Run() --> Execute, Terminate 
        3. app.Map() --> (URL, Execute)
      */

      #region Built-in Middleware 
      // Configure the HTTP request pipeline.

      if (!app.Environment.IsDevelopment())
      {
        app.UseExceptionHandler("/Home/Error");
      }
      app.UseRouting();

      app.UseSession();

      app.UseAuthorization();

      app.MapStaticAssets();
      app.MapControllerRoute(
          name: "default",
          pattern: "{controller=Home}/{action=Index}/{id?}")
          .WithStaticAssets();
      #endregion

      #region Custom Middleware "Inline Middleware"
      /*
        
      app.Use(async (HttpContext, Next) =>
      {
        await HttpContext.Response.WriteAsync("1) Middleware-1\n");
        await Next.Invoke();
        await HttpContext.Response.WriteAsync("1) Middleware-1--- get back\n");
      });

      app.Use(async (HttpContext, Next) =>
      {
        await HttpContext.Response.WriteAsync("2) Middleware-2\n");
        await Next.Invoke();
        await HttpContext.Response.WriteAsync("2) Middleware-2--- get back\n");
      });

      app.Run(async (HttpContext) =>
      {
        await HttpContext.Response.WriteAsync("3) terminate\n");
      });

      // this one will not be executed bc the prev one (app.Run()) doesn't ref to it 
      app.Use(async (HttpContext, Next) =>
      {
        await HttpContext.Response.WriteAsync("4) Middleware-4\n");
        await Next.Invoke();
      });
      */
      /*
      output sequence:  
        1) Middleware-1
        2) Middleware-2
        3) terminate
        2) Middleware-2--- get back
        1) Middleware-1--- get back
      */
      #endregion

      // start the application 
      app.Run();
    }
  }
}
