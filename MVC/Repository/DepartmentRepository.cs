using MVC.Models;

namespace MVC.Repository
{
  public class DepartmentRepository : IDepartmentRepository
  {
    public string Id { get; set; } // to test the lifeTime of service

    Context context;
    public DepartmentRepository()
    {
      context = new Context();
      Id = Guid.NewGuid().ToString(); 
    }
    //CRUD
    public void Add(Department obj)
    {
      // instead of context.Department.Add() 
      context.Add(obj);
    }
    public void Update(Department obj)
    {
      context.Update(obj);
    }
    public void Delete(int id)
    {
      Department dept = FindByID(id);
      context.Remove(dept);
    }
    public List<Department> GetAll()
    {
      return context.Department.ToList();
    }
    public Department FindByID(int id)
    {
      return context.Department.FirstOrDefault(d => d.Id == id);
    }

    public void Save()
    {
      context.SaveChanges();
    }
  }
}
