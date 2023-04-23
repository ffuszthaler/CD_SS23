using System;

class FloodFill
{
  static string[,] grid = new string[,]
  {
        {"#", "#", "#", "#", "#", "#", "#", "#", "#", "#"},
        {"#", ".", ".", ".", ".", ".", ".", ".", ".", "#"},
        {"#", ".", "#", ".", "#", "#", "#", ".", ".", "#"},
        {"#", ".", ".", ".", ".", ".", ".", ".", ".", "#"},
        {"#", "#", "#", "#", "#", "#", "#", "#", "#", "#"},
  };

  static string[,] input = new string[,]
  {
        {"#", "#", "#", "#", "#", "#", "#", "#", "#"},
        {"#", ".", ".", ".", "#", ".", ".", ".", "#"},
        {"#", ".", ".", ".", "#", ".", ".", ".", "#"},
        {"#", ".", ".", "#", ".", ".", ".", ".", "#"},
        {"#", "#", "#", ".", ".", ".", "#", "#", "#"},
        {"#", ".", ".", ".", ".", "#", ".", ".", "#"},
        {"#", ".", ".", ".", "#", ".", ".", ".", "#"},
        {"#", ".", ".", ".", "#", ".", ".", ".", "#"},
        {"#", "#", "#", "#", "#", "#", "#", "#", "#"},
  };

  static void Main()
  {
    // Fill the region starting at (5, 1) with color "@"
    Fill(input, 4, 4, "@", ".");

    // Print the grid
    Print(input);
  }

  static void Fill(string[,] layout, int x, int y, string new_string, string old_string)
  {
    // Check if (x, y) is within the layout and the current new_string is not equal to the target new_string
    if (x < 0 || x >= layout.GetLength(0) || y < 0 || y >= layout.GetLength(1) || layout[x, y] == new_string)
    {
      return;
    }

    // Set the current cell to the target new_string
    layout[x, y] = new_string;

    // Fill the neighboring cells recursively
    if (layout[x, y] == old_string)
    {
      Fill(layout, x + 1, y, new_string, old_string);
      Fill(layout, x - 1, y, new_string, old_string);
      Fill(layout, x, y + 1, new_string, old_string);
      Fill(layout, x, y - 1, new_string, old_string);
    }
  }

  static void Print(string[,] layout)
  {
    for (int x = 0; x < layout.GetLength(0); x++)
    {
      for (int y = 0; y < layout.GetLength(1); y++)
      {
        Console.Write(layout[x, y] + " ");
      }
      Console.WriteLine();
    }
  }
}