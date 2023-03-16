namespace PetLibrary;

public class OwnPets
{
  Cat houseCat;
  Dog houseDog;

  public OwnPets()
  {
    houseCat = new Cat();
    houseDog = new Dog();
  }

  public void WriteToConsole()
  {
    Console.WriteLine($"{houseCat}'s name is {houseCat.Name}");
    Console.WriteLine($"{houseDog}'s name is {houseDog.Name}");
  }

}
