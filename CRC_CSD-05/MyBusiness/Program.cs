using System;
using PetLibrary;

namespace MyBusiness
{
  class MyBusiness
  {
    static void Main(string[] args)
    {
      // Create a cat
      Cat nana = new Cat("Nana", new DateTime(2019, 12, 9));
      nana.WriteToConsole();

      OwnPets myPets = new OwnPets();
      myPets.WriteToConsole();
    }
  }
}
