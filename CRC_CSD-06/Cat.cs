using System;

public class Cat
{
  public object? food = default(object);

  public string CheckFood(object input)
  {
    if (food.Equals(input))
    {
      return "Expected food and input are the same.";
    }
    else
    {
      return "Expected food and input are NOT the same.";
    }
  }
}

public class GenericCat<T> where T : IComparable
{
  public T? food = default(T?);

  public string CheckFood(T input)
  {
    if (food == null)
    {
      return "Expected food is empty.";
    }
    else if (food.CompareTo(input) == 0)
    {
      return "Expected food and input are the same.";
    }
    else
    {
      return "Expected food and input are NOT the same.";
    }
  }
}

public class GenericMethodCat
{
  public static double DoubleMyFood<T>(T input) where T : IConvertible
  {
    double d = input.ToDouble(Thread.CurrentThread.CurrentCulture);
    // A system method to convert a string to a double.

    return 2 * d;
  }
}