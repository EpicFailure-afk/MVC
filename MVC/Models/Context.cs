using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace MVC.Models
{
  public class Context: DbContext
  {
    // DbSets
    public DbSet<Employee> employee { get; set; }
    public DbSet<Department> Department { get; set; }
    public Context(): base()
    {
      
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(
          @"Data source = localhost\SQLEXPRESS;
          initial catalog = DOT_NET_MVC;
          Integrated security = true;
          Encrypt = false;
          TrustServerCertificate=True"
        );
      base.OnConfiguring(optionsBuilder);
    }
  }
}
