using System.Security.Cryptography.X509Certificates;

namespace MVC.Models
{
  public class StudentBL
  {
    // work on static data 
    List<Student> students;
    public StudentBL()
    {
      students = new List<Student>();
      students.Add(new Student() { ID = 1, Name = "Ahmed", ImageURL = "m.png" });
      students.Add(new Student() { ID = 2, Name = "Fatma", ImageURL = "2.jpg" });
      students.Add(new Student() { ID = 3, Name = "Youssef", ImageURL = "m.png" });
      students.Add(new Student() { ID = 4, Name = "Sara", ImageURL = "2.jpg" });
      students.Add(new Student() { ID = 5, Name = "Salah", ImageURL = "m.png" });
    }
    
    // return all studs
    public List<Student> GetAll()
    {
      return students;
    }
    
    // get stud by id 
    public Student? GetById(int id)
    {
      return students.FirstOrDefault(s => s.ID == id);
    }
  }
}
