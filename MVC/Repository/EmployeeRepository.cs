using MVC.Models;

namespace MVC.Repository
{
  public class EmployeeRepository : IEmployeeRepository
  {
    Context context;
    public EmployeeRepository()
    {
      context = new Context();
    }

    //CRUD
    public void Add(Employee obj)
    {
      context.Add(obj);
    }
    public void Update(Employee obj)
    {
      context.Update(obj);
    }
    public void Delete(int id)
    {
      Employee emp = FindByID(id);
      context.Remove(emp);
    }
    public List<Employee> GetAll()
    {
      return context.employee.ToList();
    }
    public Employee FindByID(int id)
    {
      return context.employee.FirstOrDefault(e => e.Id == id);
    }

    public void Save()
    {
      context.SaveChanges();
    }
  }
}
