namespace PetLibrary;

public class Cat : IComparable<Cat>
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

  // Static method to "multiply"
  public static Cat ProduceKitty(Cat cat1, Cat cat2)
  {
    Cat kitty = new Cat()
    {
      Name = $"Baby of {cat1.Name} and {cat2.Name}"
    };

    cat1.Children.Add(kitty);
    cat2.Children.Add(kitty);

    return kitty;
  }


  // Use operators instead of the above methods
  public static Cat operator *(Cat cat1, Cat cat2)
  {
    return Cat.ProduceKitty(cat1, cat2);
  }

  // Instance method to "multiply"
  public Cat ProduceCatWith(Cat partner)
  {
    return ProduceKitty(this, partner);
  }


  // Implementation of the interface IRun
  public double Speed { get; set; }
  public int Distance { get; }
  public double SpeedUp(double velocity)
  {
    Speed += velocity;
    return Speed;
  }

  // Implementation of interface ICompare
  public int CompareTo(Cat? anotherCat)
  {
    if (anotherCat != null)
    {
      return Name.CompareTo(anotherCat.Name);
    }
    else
    {
      return 0;
    }
  }

}

// interface IRun
// {
//   // Getters & Setters
//   double Speed { get; set; }
//   int Distance { get; }

//   // Method
//   double SpeedUp(double velocity);
// }
