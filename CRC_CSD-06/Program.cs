using System;

namespace CRC_CSD_06;
class Program
{
  // public static int DoubleMyResource(int resource)
  // {
  //   return 2 * resource;
  // }

  // // Function overloading
  // public static float DoubleMyResource(float resource)
  // {
  //   return 2.0F * resource;
  // }

  // // Generic function
  // public static T DoubleMyResource<T>(T resource)
  // {
  //   decimal r = (decimal)Convert.ChangeType(resource, typeof(decimal));
  //   r *= 2.0M;

  //   return (T)Convert.ChangeType(r, typeof(T));
  // }

  static void Main(string[] args)
  {
    // // Function overloading
    // int r = 2;
    // int newR = DoubleMyResource(r);
    // Console.WriteLine($"My old resource is {r} and the new one is {newR}");

    // float f = 2.5F;
    // float newF = DoubleMyResource(f);
    // Console.WriteLine($"My old resource is {f} and the new one is {newF}");

    // // Generic function
    // int gr = 2;
    // int newGR = DoubleMyResource<int>(gr);
    // Console.WriteLine($"My old resource is {gr} and the new one is {newGR}");

    // float gf = 2.5F;
    // float newGF = DoubleMyResource<float>(gf);
    // Console.WriteLine($"My old resource is {gf} and the new one is {newGF}");

    Cat cat1 = new Cat();
    cat1.food = 5;
    Console.WriteLine($"Cat food with an integer: {cat1.CheckFood(5)}");

    Cat cat2 = new Cat();
    cat2.food = "fish";
    Console.WriteLine($"Cat food with an integer: {cat2.CheckFood("fish")}");

    GenericCat<int> gCat1 = new GenericCat<int>();
    gCat1.food = 5;
    Console.WriteLine($"Cat food with an integer: {gCat1.CheckFood(5)}");

    GenericCat<string> gCat2 = new GenericCat<string>();
    gCat2.food = "fish";
    Console.WriteLine($"Cat food with an integer: {gCat2.CheckFood("fish")}");

    // Generic method
    string food1 = "4";
    Console.WriteLine("Double cat food {0} to {1}",
      arg0: food1,
      arg1: GenericMethodCat.DoubleMyFood<string>(food1)
    );


    byte food2 = 3;
    Console.WriteLine("Double cat food {0} to {1}",
      arg0: food2,
      arg1: GenericMethodCat.DoubleMyFood<byte>(food2)
    );
  }
}