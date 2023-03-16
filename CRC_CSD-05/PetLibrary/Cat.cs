namespace PetLibrary;

public class Cat
{
  // Fields
  public string Name;
  public DateTime DateOfBirth;
  public List<Cat> Children = new List<Cat>();

  // Constructor
  public Cat()
  {
    Name = "Unknown";
    DateOfBirth = DateTime.Today;
  }

  public Cat(string name, DateTime date)
  {
    Name = name;
    DateOfBirth = date;
  }

  // Getters & Setters

  // Finalizer

  // Methods
  public void WriteToConsole()
  {
    Console.WriteLine($"{Name} was born on a {DateOfBirth:dddd}.");
  }
}
