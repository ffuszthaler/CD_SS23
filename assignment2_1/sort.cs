using System;

class CRC_CD_Assignment2_1
{
  // bubble sort
  static IEnumerable<T> bubbleSort<T>(IEnumerable<T> arr) where T : IComparable
  {
    // convert list to array
    T[] sortedList = arr.ToArray();

    // size of array
    int n = sortedList.Length;

    // sort as long as needed
    while (true)
    {
      bool performedSwap = false;

      for (int i = 1; i < n; i++)
      {
        // get previous index
        int j = i - 1;

        // get current and previous value
        T previousItem = sortedList[j];
        T currentItem = sortedList[i];

        // compare them
        int comparison = previousItem.CompareTo(currentItem);

        if (comparison > 0)
        {
          sortedList[j] = currentItem;
          sortedList[i] = previousItem;

          performedSwap = true;
        }
      }

      if (!performedSwap)
      {
        break;
      }
    }

    return sortedList;
  }

  // merge sort
  static T[] mergeSort<T>(IEnumerable<T> list) where T : IComparable
    // static int[] mergeSort(int[] array)
  {
    // convert list to array
    T[] inputList = list.ToArray();

    // size of array
    int n = inputList.Length;

    T[] left;
    T[] right;
    T[] result = new T[inputList.Length];

    // prevent infinite loop
    if (n == 1)
    {
      return (T[])list;
    }

    // middle of array
    int midPoint = n / 2;

    // left "side" of array
    left = new T[midPoint];

    // if array is even, both side have the same amount of elements
    if (n % 2 == 0)
    {
      right = new T[midPoint];
    }
    // if not, right "side" is bigger by one element
    else
    {
      right = new T[midPoint + 1];
    }

    // populate left array
    for (int i = 0; i < midPoint; i++)
    {
      left[i] = inputList[i];
    }

    // populate right array
    int x = 0;

    // start index from the midpoint, as we have already populated the left array from 0 to midpont
    for (int i = midPoint; i < n; i++)
    {
      right[x] = inputList[i];
      x++;
    }

    // sort the left array
    left = mergeSort(left);

    // sort the right array
    right = mergeSort(right);

    // merge the sorted arrays into one
    result = merge(left, right);

    return result;
  }

  // method combines our two sorted arrays into one
  static T[] merge<T>(T[] left, T[] right) where T : IComparable
    // static int[] merge(T[] left, T[] right)
  {
    int resultLength = right.Length + left.Length;

    T[] result = new T[resultLength];

    int indexLeft = 0;
    int indexRight = 0;
    int indexResult = 0;

    // while either array still has an element
    for (int i = 0; i < resultLength; i++)
    {
      if (indexLeft >= left.Length)
      {
        result[indexResult] = right[indexRight];
        indexRight++;
        indexResult++;
      }
      else if (indexRight >= right.Length)
      {
        result[indexResult] = left[indexLeft];
        indexLeft++;
        indexResult++;
      }
      else if (left[indexLeft].CompareTo(right[indexRight]) < 0)
      {
        result[indexResult] = left[indexLeft];
        indexLeft++;
        indexResult++;
      }
      else
      {
        result[indexResult] = right[indexRight];
        indexRight++;
        indexResult++;
      }
    }
    return result;
  }

  // helper method for printing result
  static void printArray(int[] arr)
  {
    int n = arr.Length;
    for (int i = 0; i < n; ++i)
    {
      Console.Write(arr[i] + " ");
    }
  }

  private static void PrintList<T>(IEnumerable<T> list)
  {
    foreach (var item in list)
    {
      Console.Write(item + " ");
    }
  }

  // main application entry point
  public static void Main(string[] args)
  {
    // convert number args to a useable array
    string[] arr = args[1].Split(", ").Select(n => Convert.ToString(n)).ToArray();

    if (args[0] == "-Bubble")
    {
      Console.WriteLine("Bubble Sort Result:");
      PrintList(bubbleSort(arr));
    }
    else if (args[0] == "-Merge")
    {
      Console.WriteLine("Merge Sort Result:");
      PrintList(mergeSort(arr));
    }
  }
}