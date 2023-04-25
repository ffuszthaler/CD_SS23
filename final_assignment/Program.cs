using System;
using System.Text.RegularExpressions;

using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;

class FloodFill
{
  static void Main(string[] args)
  {
    // provide an input file with the layout
    string inputFile = File.ReadAllText("./input.txt");

    // extract each row into an array
    string[] rows = inputFile.Split(Environment.NewLine);

    // create an appropriately sized array for the algorithm
    string[,] input = new string[rows.Length, rows[0].Split(' ').Length];

    // loop through each row and split it by spaces to get each column value
    for (int i = 0; i < rows.Length; i++)
    {
      string[] columns = rows[i].Split(' ');

      // loop through each column and assign its value to the corresponding array element
      for (int j = 0; j < columns.Length; j++)
      {
        // trim any white spaces around the value
        input[i, j] = columns[j].Trim();
      }
    }

    // introduction
    Console.WriteLine("Welcome to the Flood-Fill Algorithm!");
    Console.WriteLine("------------------------------------");
    Console.WriteLine("INPORTANT");
    Console.WriteLine("To change the layout, modify input.txt");
    Console.WriteLine("Coordinate values start at 0, not 1!");
    Console.WriteLine("------------------------------------");

    // require user input for coords
    Console.Write("Provide an X coordinate: ");
    int xCoords = Convert.ToInt32(Console.ReadLine());

    Console.Write("Provide an y coordinate: ");
    int yCoords = Convert.ToInt32(Console.ReadLine());

    // execute algorithm with provided coords
    Fill(input, xCoords, yCoords, "@", ".");
  }

  static void Fill(string[,] layout, int x, int y, string new_string, string old_string)
  {
    // check if (x, y) is within the layout and the current new_string is not equal to the target new_string
    if (x < 0 || x >= layout.GetLength(0) || y < 0 || y >= layout.GetLength(1) || layout[x, y] != old_string)
    {
      return;
    }

    // set the current cell to the target new_string
    layout[x, y] = new_string;
    Print(layout);

    // fill the neighboring cells recursively
    Fill(layout, x + 1, y, new_string, old_string);
    Fill(layout, x - 1, y, new_string, old_string);
    Fill(layout, x, y + 1, new_string, old_string);
    Fill(layout, x, y - 1, new_string, old_string);
  }

  static void Print(string[,] layout)
  {
    // wait for half a second and clear console to prepare next animation frame
    Thread.Sleep(500);
    Console.Clear();

    // create a new output text file
    string outputFile = Combine(CurrentDirectory, "output.txt");
    StreamWriter text = File.CreateText(outputFile);

    for (int x = 0; x < layout.GetLength(0); x++)
    {
      for (int y = 0; y < layout.GetLength(1); y++)
      {
        // output what happening to console
        Console.Write(layout[x, y] + " ");

        // write each line into the output file
        text.Write(layout[x, y]);

        // with spaces between each character
        text.Write(" ");
      }

      // add new lines
      Console.WriteLine();
      text.WriteLine();
    }

    // close access to output file
    text.Close();
  }
}