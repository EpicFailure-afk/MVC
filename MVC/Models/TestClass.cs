namespace MVC.Models
{
  // Simulation for the principle in SOLID
  // Dependency Inversion 

  // create Interface 
  interface ISort
  {
    void Sort(int[] arr);
  }

  // Implement that Interface foreach type of sorting 
  public class BubbleSort: ISort
  {
    public void Sort(int[] arr)
    {
      //sort arr using bubble sort alg
    }
  }

  public class SelectionSort: ISort
  {
    public void Sort(int[] arr)
    {
      //sort arr using bubble sort alg
    }
  }


  // -------------------------------------------------
  class Stack // High level 
  {
    int[] arr;
    // BubbleSort BubbleSort;   // low level class
    ISort SortObj;  // create an obj from the interface

    // ctor of Stack
    public Stack(ISort _sortObj) // initialize an obj from the interface at the param of ctor
    {
      SortObj = _sortObj;
    }
    void SortStack()
    {
      SortObj.Sort(arr);
    }
  }
  
  public class TestClass
  {
    void Method1()
    {
      Stack S1 = new Stack(new BubbleSort());
      Stack S2 = new Stack(new SelectionSort());
    }
  }
}
