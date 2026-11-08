using MVC.Models;

namespace MVC.Repository
{
  public interface IEmployeeRepository
  {
    void Add(Employee obj);
    void Update(Employee obj);
    void Delete(int id);
    List<Employee> GetAll();
    Employee FindByID(int id);
    void Save();
  }
}
