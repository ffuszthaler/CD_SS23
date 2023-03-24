using System;

class Program
{
  static void Main(string[] args)
  {
    // local function
    bool CompareMethod(int a, int b)
    {
      return a == b;
    }
    Console.WriteLine(CompareMethod(3, 4));

    // expression lambda
    bool CompareLambda(int a, int b) => (a == b);
    Console.WriteLine(CompareLambda(3, 4));

    // print fibonacci sequence
    for (int i = 0; i < 10; i++)
    {
      Console.WriteLine("The {0} term of the fibonacci sequence is {1:N0}",
      arg0: i + 1, arg1: FibLambda(i));
    }
  }

  // classic method
  static int FibMethod(int term)
  {
    switch (term)
    {
      case 0:
        return 0;
      case 1:
        return 1;
      default:
        return FibMethod(term - 1) + FibMethod(term - 2);
    }
  }

  // statement lambda
  static int FibLambda(int term) => term switch
  {
    0 => 0,
    1 => 1,
    _ => FibLambda(term - 1) + FibLambda(term - 2)
  };
}