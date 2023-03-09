using System;

namespace CSD_01_01
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hi there!");
      Console.WriteLine("The length of the arguments: " + args.Length);

      // print out parameters
      for (int i = 0; i < args.Length; i++)
      {
        Console.WriteLine(args[i]);
      }
    }
  }
}