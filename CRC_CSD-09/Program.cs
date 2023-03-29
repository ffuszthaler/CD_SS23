using System;
using System.Diagnostics;

namespace CRC_CSD_09;

public class Program
{
  // // declare a delegate
  // public delegate int[] GenerateMyNumber(int x, int y);

  // // create an array with size amount and assign a random value in it
  // public static int[] GetRandomNumber(int maxNum, int amount)
  // {
  //   Random random = new Random();
  //   int[] nums = new int[amount];

  //   for (int i = 0; i < amount; i++)
  //   {
  //     nums[i] = random.Next(0, maxNum);
  //   }

  //   return nums;
  // }

  // public static int[] GetOrderedNumber(int max, int min)
  // {
  //   // avoid when max is smaller than the min
  //   if (max < min)
  //   {
  //     int[] noNum = { 0 };
  //   }

  //   // create an ordered sequence
  //   int[] nums = new int[max - min + 1];

  //   for (int i = 0; i <= max - min; i++)
  //   {
  //     nums[i] = min + i;
  //   }

  //   return nums;
  // }

  // // ake out each element & add 1
  // public static int[] AddOne(int[] _array)
  // {
  //   int[] array = new int[_array.Length];

  //   for (int i = 0; i < _array.Length; i++)
  //   {
  //     array[i] = _array[i] + 1;
  //   }

  //   return array;
  // }

  // // take out each element & multiply by 2
  // public static int[] MulitplyTwo(int[] _array)
  // {
  //   int[] array = new int[_array.Length];

  //   for (int i = 0; i < _array.Length; i++)
  //   {
  //     array[i] = _array[i] * 2;
  //   }

  //   return array;
  // }

  // // take out each element & square it
  // public static int[] Square(int[] _array)
  // {
  //   int[] array = new int[_array.Length];

  //   for (int i = 0; i < _array.Length; i++)
  //   {
  //     array[i] = _array[i] * _array[i];
  //   }

  //   return array;
  // }

  // public delegate int ChangeValueDelegate(int x);
  // // public delegate T ChangeValueDelegate<T>(T x);

  // public static int AddOneShort(int number)
  // {
  //   return number + 1;
  // }

  // public static int MuliplyTwoShort(int number)
  // {
  //   return number * 2;
  // }

  // public static int SquareShort(int number)
  // {
  //   return number * number;
  // }
  // // as a lambda expression -> public static int SquareShort(int number) => number * number;

  // public static int[] Change(int[] _array, ChangeValueDelegate changeValue)
  // {
  //   int[] array = new int[_array.Length];

  //   for (int i = 0; i < _array.Length; i++)
  //   {
  //     array[i] = changeValue(_array[i]);
  //   }

  //   return array;
  // }

  // add param1 & param2
  // public static void AddNumbers(int param1, int param2)
  // {
  //   int result = param1 + param2;
  //   Console.WriteLine($"Addition result = {result}");
  // }

  static void MethodA()
  {
    Console.WriteLine("Starting Method A...");
    Thread.Sleep(3000); // wait for 3 sec.
    Console.WriteLine("Finished Method A...");
  }

  static void MethodB()
  {
    Console.WriteLine("Starting Method B...");
    Thread.Sleep(2000); // wait for 2 sec.
    Console.WriteLine("Finished Method B...");
  }

  static void MethodC()
  {
    Console.WriteLine("Starting Method C...");
    Thread.Sleep(1000); // wait for 1 sec.
    Console.WriteLine("Finished Method C...");
  }

  // shared resource
  static string Message = "";

  static void Main(string[] args)
  {
    Stopwatch timer = Stopwatch.StartNew();

    // Console.WriteLine("Running methods synchronously on one thread...");
    // MethodA();
    // MethodB();
    // MethodC();

    Console.WriteLine("Running methods asynchronously on multiple thread...");

    // 1st way
    Task taskA = new Task(MethodA);
    taskA.Start();

    // 2nd way
    Task taskB = Task.Factory.StartNew(MethodB);

    // 3rd way
    Task taskC = Task.Run(new Action(MethodC));

    Task[] tasks = { taskA, taskB, taskC };
    Task.WaitAll(tasks);

    Console.WriteLine($"{timer.ElapsedMilliseconds:#,##0}ms elapsed.");

    // // create delegate object/instance, where you put the corresponding methods as input
    // GenerateMyNumber generateRandom = new GenerateMyNumber(GetRandomNumber);
    // GenerateMyNumber generateOrdered = new GenerateMyNumber(GetOrderedNumber);

    // int[] numbers = generateOrdered(10, 3);

    // foreach (int n in numbers)
    // {
    //   Console.Write(n + " ");
    // }

    // Console.WriteLine();

    // int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    // ChangeValueDelegate myDelegate1 = new ChangeValueDelegate(AddOneShort);
    // ChangeValueDelegate myDelegate2 = new ChangeValueDelegate(MuliplyTwoShort);
    // ChangeValueDelegate myDelegate3 = new ChangeValueDelegate(SquareShort);

    // Console.WriteLine(String.Join(",", AddOne(array)));
    // Console.WriteLine(String.Join(",", MulitplyTwo(array)));
    // Console.WriteLine(String.Join(",", Square(array)));

    // Console.WriteLine(String.Join(",", Change(array, myDelegate1)));
    // Console.WriteLine(String.Join(",", Change(array, myDelegate2)));
    // Console.WriteLine(String.Join(",", Change(array, myDelegate3)));

    // Action<int, int> Addition = new Action<int, int>(AddNumbers);
    // Addition(10, 20);
  }
}