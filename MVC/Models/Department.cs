namespace MVC.Models
{
  public class Department
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string ManagerName { get; set; }

    // nav-props
    public List<Employee>? Emps{ get; set; } 
  }
}
