using System;
using System.Text.RegularExpressions;

using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;

class FloodFill
{
  // static string[,] grid = new string[,]
  // {
  //       {"#", "#", "#", "#", "#", "#", "#", "#", "#", "#"},
  //       {"#", ".", ".", ".", ".", ".", ".", ".", ".", "#"},
  //       {"#", ".", "#", ".", "#", "#", "#", ".", ".", "#"},
  //       {"#", ".", ".", ".", ".", ".", ".", ".", ".", "#"},
  //       {"#", "#", "#", "#", "#", "#", "#", "#", "#", "#"},
  // };

  // static string[,] input = new string[,]
  // {
  //       {"#", "#", "#", "#", "#", "#", "#", "#", "#"},
  //       {"#", ".", ".", ".", "#", ".", ".", ".", "#"},
  //       {"#", ".", ".", ".", "#", ".", ".", ".", "#"},
  //       {"#", ".", ".", "#", ".", ".", ".", ".", "#"},
  //       {"#", "#", "#", ".", ".", ".", "#", "#", "#"},
  //       {"#", ".", ".", ".", ".", "#", ".", ".", "#"},
  //       {"#", ".", ".", ".", "#", ".", ".", ".", "#"},
  //       {"#", ".", ".", ".", "#", ".", ".", ".", "#"},
  //       {"#", "#", "#", "#", "#", "#", "#", "#", "#"},
  // };



  // private static int getColumnLength(string[][] jaggedArray, int columnIndex)
  // {
  //   int count = 0;
  //   foreach (string[] row in jaggedArray)
  //   {
  //     if (columnIndex < row.Length) count++;
  //   }
  //   return count;
  // }

  static void Main()
  {

    // x: column - up, down
    // y: row - left, right

    string inputFile = File.ReadAllText("./input.txt");
    // static string[,] inputTxt = inputTxtFile.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
    // static string[][] inputTxt = inputFile.Split(new string[] { "", "], [", "]]" }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Split(',').ToArray()).ToArray();

    // string[][] temp = inputFile.Split(',').Select(p => Regex.Split(p, "(?<=\\G.{2})")).ToArray();

    // string[,] input = new String[temp.Length, temp[0].Length];
    // string[,] input = inputFile.Split(new String[,] { { "\n" } }, StringSplitOptions.None);

    // // convert string[][] to string[,]
    // for (int i = 0; i != temp.Length; i++)
    //   for (int j = 0; j != temp[0].Length; j++)
    //     input[i, j] = temp[i][j];

    // Split the content by line breaks to get each row

    string[] rows = inputFile.Split(Environment.NewLine);
    Console.WriteLine(rows);

    // Loop through each row and split it by comma to get each column value
    for (int i = 0; i < rows.Length; i++)
    {
      string[] columns = rows[i].Split(',');

      // Loop through each column and assign its value to the corresponding array element
      for (int j = 0; j < columns.Length; j++)
      {
        string[,] input = new string[columns.Length, rows.Length];

        input[i, j] = columns[j].Trim(); // Trim any white spaces around the value
      }
    }


    // Fill the region starting at (5, 1) with color "@"
    // Fill(input, 4, 4, "@", ".");
    // Fill(grid, 3, 1, "@", ".");

    // for (int x = 0; x < getColumnLength(inputTxt, 0); x++)
    // {
    //   for (int y = 0; y < getColumnLength(inputTxt, 1); y++)
    //   {
    //     Console.Write(inputTxt[x][y] + " ");
    //   }
    //   Console.WriteLine();
    // }
  }

  static void Fill(string[,] layout, int x, int y, string new_string, string old_string)
  {
    // Check if (x, y) is within the layout and the current new_string is not equal to the target new_string
    if (x < 0 || x >= layout.GetLength(0) || y < 0 || y >= layout.GetLength(1) || layout[x, y] != old_string)
    {
      return;
    }

    // Set the current cell to the target new_string
    layout[x, y] = new_string;
    Print(layout);

    // Fill the neighboring cells recursively
    Fill(layout, x + 1, y, new_string, old_string);
    Fill(layout, x - 1, y, new_string, old_string);
    Fill(layout, x, y + 1, new_string, old_string);
    Fill(layout, x, y - 1, new_string, old_string);
  }

  static void Print(string[,] layout)
  {
    Thread.Sleep(500);
    Console.Clear();

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