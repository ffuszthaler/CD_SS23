using System;

class CRC_CSD_03
{
  static string collatz(int num)
  {
    // n is even
    if (num % 2 == 0)
    {
      num = num / 2;
      return "Even";
    }
    // n is odd
    else
    {
      num = num * 3 + 1;
      return "Odd";
    }
  }

  static void fibonacci_iteration(int count)
  {
    int a = 0;
    int b = 1;
    int sum = 0;

    Console.Write("{0} {1}", a, b);

    for (int i = 2; i < count; i++)
    {
      sum = a + b;
      Console.Write(" {0}", sum);

      a = b;
      b = sum;
    }
  }

  static int fibonacci_recursion(int count)
  {
    if (count == 0) return 0;
    if (count == 1) return 1;

    return fibonacci_recursion(count - 1) + fibonacci_recursion(count - 2);
  }

  public static void Main(string[] args)
  {
    // for (int i = 0; i <= 1000; i++) {
    //   Console.WriteLine(collatz(i));
    // }

    Console.Write("Enter the length of the Fibonacci Series: ");
    int length = Convert.ToInt32(Console.ReadLine());

    fibonacci_iteration(length);
    Console.Write("\n---\n");

    for (int i = 0; i < length; i++)
    {
      Console.Write("{0} ", fibonacci_recursion(i));
    }
  }
}