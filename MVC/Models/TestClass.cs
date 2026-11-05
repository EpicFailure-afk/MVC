namespace MVC.Models
{
  // Simulation for the principle in SOLID
  // Dependency Inversion 

  /*
   * Although this model or BL is open for extend 
   * but it is not closed for modification 
   * 
   * the problem here is that: the High level class (Stack) 
   *  depend on the low level class (BubbleSort)
   */ 
  public class BubbleSort
  {
    public void Sort(int[] arr)
    {
      //sort arr using bubble sort alg
    }
  }

  public class SelectionSort
  {
    public void Sort(int[] arr)
    {
      //sort arr using bubble sort alg
    }
  }

  class Stack // High level 
  {
    int[] arr;
    BubbleSort BubbleSort;   // low level class
    
    // ctor of Stack
    public Stack() 
    {
      BubbleSort = new BubbleSort(); // low level 
    }
    void SortStack()
    {
      BubbleSort.Sort(arr);
    }
  }
  
  public class TestClass
  {

  }
}
