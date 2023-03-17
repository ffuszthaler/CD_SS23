using System;
using PetLibrary;

namespace MyBusiness
{
  class MyBusiness
  {
    static void Main(string[] args)
    {
      // Create a cat
      Cat[] cats = {
        new Cat("Nana", new DateTime(2019, 12, 9)),
        new Cat("Coffee", new DateTime(2018, 10, 19)),
        new Cat("Kiwi", new DateTime(2018, 6, 20)),
      };

      // Print the array
      for (int i = 0; i < cats.Length; i++)
      {
        Console.WriteLine($"{cats[i].Name}");
      }

      Array.Sort(cats);

      // Print out the array again
      Console.WriteLine("Use Cat's IComparible Implementation to sort cats.");

      for (int i = 0; i < cats.Length; i++)
      {
        Console.WriteLine($"{cats[i].Name}");
      }

      // // Print cat info
      // nana.WriteToConsole();
      // coffee.WriteToConsole();
      // kiwi.WriteToConsole();

      // // Call instance method
      // Cat kitty1 = nana.ProduceCatWith(coffee);
      // kitty1.Name = "Naffe";

      // // Call static method
      // // Cat kitty2 = Cat.ProduceKitty(kiwi, coffee);
      // Cat kitty2 = kiwi * coffee;
      // kitty2.Name = "Kiffee";

      // // Print out kitty name
      // Console.WriteLine($"{nana.Name} has {nana.Children.Count} kitty.");
      // Console.WriteLine($"{coffee.Name} has {coffee.Children.Count} kitty");
      // Console.WriteLine($"{kiwi.Name} has {kiwi.Children.Count} kitty.");

      // double speed = nana.SpeedUp(2);
      // Console.WriteLine($"{nana.Name} is running at the speed {speed} km/h.");

      // OwnPets myPets = new OwnPets();
      // myPets.WriteToConsole();
    }
  }
}
