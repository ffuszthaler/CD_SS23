using System;

class CRC_CD_Assignment1
{
  // bubble sort
  static void bubbleSort(int[] arr)
  {
    // size of array
    int n = arr.Length;

    // loops through all values
    for (int i = 0; i < n - 1; i++)
    {
      for (int j = 0; j < n - i - 1; j++)
      {
        // compare adjacent values
        if (arr[j] > arr[j + 1])
        {
          // temporary value storage during swap
          int temp = arr[j];

          arr[j] = arr[j + 1];
          arr[j + 1] = temp;
        }
      }
    }
  }

  // merge sort
  static int[] mergeSort(int[] array)
  {
    int[] left;
    int[] right;
    int[] result = new int[array.Length];

    // prevent infinite loop
    if (array.Length <= 1)
    {
      return array;
    }

    // middle of array
    int midPoint = array.Length / 2;

    // left "side" of array
    left = new int[midPoint];

    // if array is even, both side have the same amount of elements
    if (array.Length % 2 == 0)
    {
      right = new int[midPoint];
    }
    // if not, right "side" is bigger by one element
    else
    {
      right = new int[midPoint + 1];
    }

    // populate left array
    for (int i = 0; i < midPoint; i++)
    {
      left[i] = array[i];
    }

    // populate right array
    int x = 0;

    // start index from the midpoint, as we have already populated the left array from 0 to midpont
    for (int i = midPoint; i < array.Length; i++)
    {
      right[x] = array[i];
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
  static int[] merge(int[] left, int[] right)
  {
    int resultLength = right.Length + left.Length;
    int[] result = new int[resultLength];

    int indexLeft = 0;
    int indexRight = 0;
    int indexResult = 0;

    // while either array still has an element
    while (indexLeft < left.Length || indexRight < right.Length)
    {
      //if both arrays have elements
      if (indexLeft < left.Length && indexRight < right.Length)
      {
        // if item on left array is less than item on right array,
        // add it to result array
        if (left[indexLeft] <= right[indexRight])
        {
          result[indexResult] = left[indexLeft];
          indexLeft++;
          indexResult++;
        }
        // else the item in the right array wll be added to the results array
        else
        {
          result[indexResult] = right[indexRight];
          indexRight++;
          indexResult++;
        }
      }
      // if only the left array still has elements,
      // add all its items to the results array
      else if (indexLeft < left.Length)
      {
        result[indexResult] = left[indexLeft];
        indexLeft++;
        indexResult++;
      }
      // if only the right array still has elements,
      // add all its items to the results array
      else if (indexRight < right.Length)
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

  // main application entry point
  public static void Main(string[] args)
  {
    // convert number args to useable integer array
    int[] arr = args[1].Split(',').Select(n => Convert.ToInt32(n)).ToArray();

    if (args[0] == "-Bubble")
    {
      Console.WriteLine("Bubble Sort Result:");

      bubbleSort(arr);
      printArray(arr);
    }
    else if (args[0] == "-Merge")
    {
      Console.WriteLine("Merge Sort Result:");

      int[] result = mergeSort(arr);
      printArray(result);
    }
  }
}