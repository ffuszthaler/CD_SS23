# Explanation of my Implementation

# Bubble Sort
The overall implementation of bubble sort was pretty straight forward as the algorithm itself isn't too complex.

The algorithm works by comparing a value with it's neighbor and swapping them if one is less than the other, this will repeat itself until all numbers are correctly organized.

* To program this behavior, one has to continuously loop through all values first:
```csharp
for (int i = 0; i < n - 1; i++)
```

* Then compare the current value of the loop iteration with its neighbor:
```csharp
if (arr[j] > arr[j] + 1)
```

* and swap their position in the array if necessary, this can be helped by using additional arrays for temporary storage.
```csharp
int temp = arr[j];

arr[j] = arr[j + 1];
arr[j + 1] = temp;
```

After this the alogrithm is done sorting.

# Merge Sort
MergeSort works by spliting the given array into two halves (sub arrays) and recursively sorts each sub array before merging them back into one giant, sorted array.

* To implement this one first has to split the given array onto two parts:
```csharp
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
```

* Afterwards each sub array get sorted, depending on which condition applies to the currently compared values:
```csharp
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
```

* After the sub arrays are sorted, they get merged into one and the result gets returned and the algorithm is done:
```csharp
// sort the left array
left = mergeSort(left);

// sort the right array
right = mergeSort(right);

// merge the sorted arrays into one
result = merge(left, right);

return result;
```

# Helper Functions
These are functions that help with various aspects of the program.

* Help with printing the algorith results:
```csharp
static void printArray(int[] arr)
{
  int n = arr.Length;
  for (int i = 0; i < n; ++i)
  {
    Console.Write(arr[i] + " ");
  }
}
```