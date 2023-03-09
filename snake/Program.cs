using System;
using System.Collections.Generic;

namespace ConsoleGame
{
  // position class: handle 2d coords
  public class Position
  {
    public int left;
    public int top;
  }

  // snake class
  public class Snake
  {
    // fields
    private int _length = 6;

    // snake body position
    private List<Position> _points = new List<Position>();

    // getters and setters
    public int Length
    {
      get
      {
        return _length;
      }

      set
      {
        _length = value;
      }
    }

    public List<Position> Points
    {
      get
      {
        return _points;
      }

      //   set => _points = value; <- can also be written like this!
      set
      {
        _points = value;
      }
    }

    // methods
    // check if the snake overlaps with itself
    public bool IfOverlapped(Position currentPos)
    {
      for (int i = 0; i < _points.Count; i++)
      {
        if ((_points[i].left == currentPos.left) && (_points[i].top == currentPos.top))
        {
          return true;
        }
      }
      return false;
    }

    public Position SetInitialPosition()
    {
      return new Position()
      {
        left = 0,
        top = 0
      };
    }

    // clean up the snake
    public void CleanUp()
    {
      while (_points.Count() > _length)
      {
        _points.Remove(_points.First());
      }
    }
  }

  // food class
  public class Food
  {
    private Position? _position = null;
    private Random _rnd = new Random();

    public Position? Position
    {
      get => _position;
      set => _position = value;
    }


    public Random Rnd
    {
      get => _rnd;
      set => _rnd = value;
    }
  }

  class Program
  {
    private static bool _inPlay = true;
    private static int _score = 0;

    private static Snake _snake = new Snake();
    private static Food _food = new Food();

    // check of valid key input
    static ConsoleKeyInfo? _lastKey;
    private static bool AcceptInput()
    {
      if (!Console.KeyAvailable)
        return false;

      _lastKey = Console.ReadKey();

      return true;
    }

    // draw game objects
    private static void DrawScreen()
    {
      Console.Clear();
      Console.SetCursorPosition(Console.WindowWidth - 3, Console.WindowHeight - 1);
      Console.Write(_score);

      // draw snake
      for (int i = 0; i < _snake.Points.Count; i++)
      {
        Console.SetCursorPosition(_snake.Points[i].left, _snake.Points[i].top);
        Console.Write('*');
      }

      // draw food
      if (_food.Position != null)
      {
        Console.SetCursorPosition(_food.Position.left, _food.Position.top);
        Console.Write('X');
      }
    }

    // update game
    private static DateTime nextUpdate = DateTime.MinValue;
    private static bool UpdateGame()
    {
      if (DateTime.Now < nextUpdate) return false;

      if (_food.Position == null)
      {
        _food.Position = new Position()
        {
          left = _food.Rnd.Next(Console.WindowHeight),
          top = _food.Rnd.Next(Console.WindowHeight)
        };
      }

      if (_lastKey.HasValue)
      {
        Move(_lastKey.Value);
      }

      nextUpdate = DateTime.Now.AddMilliseconds(500 / (_score + 1));
      return true;
    }

    private static void Move(ConsoleKeyInfo key)
    {
      Position currentPos;
      if (_snake.Points.Count != 0)
        currentPos = new Position()
        {
          left = _snake.Points.Last().left,
          top = _snake.Points.Last().top
        };
      else
        currentPos = _snake.SetInitialPosition();

      switch (key.Key)
      {
        case ConsoleKey.LeftArrow:
          currentPos.left--;
          break;
        case ConsoleKey.RightArrow:
          currentPos.left++;
          break;
        case ConsoleKey.UpArrow:
          currentPos.top--;
          break;
        case ConsoleKey.DownArrow:
          currentPos.top++;
          break;
        default:
          break;
      }

      // check for collisions
      if (DetectCollision(currentPos) == false)
      {
        _snake.Points.Add(currentPos);
        _snake.CleanUp();
      }
    }

    private static bool DetectCollision(Position currentPos)
    {
      // check if we are off screen
      if (currentPos.top < 0 || currentPos.top > Console.WindowHeight - 1
      || currentPos.left < 0 || currentPos.left > Console.WindowWidth - 1)
      {
        GameOver();
        return true;
      }

      // check if we crashed into the snake
      if (_snake.IfOverlapped(currentPos) == true)
      {
        GameOver();
        return true;
      }

      // check if we ate the food
      if ((_food.Position != null) && (_food.Position.left == currentPos.left) && (_food.Position.top == currentPos.top))
      {
        _snake.Length++;
        _score++;
        _food.Position = null;
      }

      return false;
    }

    private static void GameOver()
    {
      _inPlay = false;
      Console.Clear();
      Console.WriteLine("Game Over");
      Console.ReadLine();
    }

    static void Main(string[] args)
    {
      Console.CursorVisible = false;

      while (_inPlay)
      {
        if (AcceptInput() || UpdateGame())
        {
          DrawScreen();
        }
      }
    }
  }
}
