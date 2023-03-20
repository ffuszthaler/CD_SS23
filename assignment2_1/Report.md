# Explanation of my Implementation

# Bubble Sort
Because of the way that I implemented the bubble sort algorithm for the previous assignment,
I wasn't able to transfer a lot of the old code so most of it is new.

The overall functionality remains the same as before (if you want a more detailed explanaiton for that, look inside the ```assignment1``` folder for a file called ```Report.md```) but now it can also sort data in the form of strings, floats, ... .

To achieve this I used something called Generics and template variables, which are essentially placeholder datatypes for whatever type of data the user chooses when executing the application.

Almost all the logic surround the functionality of the algorithms remains the same, the only big difference is that instead of working with integers, strings or floats, you instead write ```T``` which stands for Template.

* These can look something like this:
```csharp
T[] values = [1, 2, 3];
```

# Merge Sort
The same goes for my merge sort implementation which now also uses templates and therefore supports multiple datatypes.

Thankfully I was able to reuse most of my old code and only had to make slight adjustments for it to work.

Again for a more detailed explanation on how merge sort works, please look inside the ```assignment1``` folder for a file called ```Report.md```.

Same as with bubble sort, you use ```T``` instead of any other more specific type.

# Helper Functions
The helper functions also received an update to works with more than one datatype:

* Updated version:
```csharp
private static void PrintList<T>(IEnumerable<T> list)
{
  foreach (var item in list)
  {
    Console.Write(item + " ");
  }
}
```