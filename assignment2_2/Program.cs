using System;

// tower of hanoi - iterative
public class HanoiIterative
{
  // a structure to represent a stack
  public class Stack
  {
    public int capacity;
    public int top;
    public int[] array;
  }

  // function to create a stack of given capacity.
  public Stack createStack(int capacity)
  {
    Stack stack = new Stack();
    stack.capacity = capacity;
    stack.top = -1;
    stack.array = new int[capacity];
    return stack;
  }

  // stack is full when top is equal to the last index
  Boolean isFull(Stack stack)
  {
    return (stack.top == stack.capacity - 1);
  }

  // stack is empty when top is equal to -1 (see createStack)
  Boolean isEmpty(Stack stack)
  {
    return (stack.top == -1);
  }

  // function to add an item to stack.
  public void push(Stack stack, int item)
  {
    // if stack is full, do nothing
    if (isFull(stack))
      return;

    // if not, increase top
    stack.array[++stack.top] = item;
  }

  // function to remove an item from stack.
  int pop(Stack stack)
  {
    // if stack is empty, return integer min value
    if (isEmpty(stack))
      return int.MinValue;

    // if not, decrease top by 1
    return stack.array[stack.top--];
  }

  // function to implement movement of "disks" between two poles
  public void moveDisksBetweenTwoPoles(Stack src, Stack dest, char s, char d)
  {
    // get/remove top item from both stacks
    int pole1TopDisk = pop(src);
    int pole2TopDisk = pop(dest);

    // when pole 1 is empty
    if (pole1TopDisk == int.MinValue)
    {
      // add top from src stack to top of dest stack
      push(src, pole2TopDisk);
      moveDisk(d, s, pole2TopDisk);
    }

    // when pole2 pole is empty
    else if (pole2TopDisk == int.MinValue)
    {
      // do same above but in reverse
      push(dest, pole1TopDisk);
      moveDisk(s, d, pole1TopDisk);
    }

    // when top disk of pole1 > top disk of pole2
    else if (pole1TopDisk > pole2TopDisk)
    {
      push(src, pole1TopDisk);
      push(src, pole2TopDisk);
      moveDisk(d, s, pole2TopDisk);
    }

    // when top disk of pole1 < top disk of pole2
    else
    {
      push(dest, pole2TopDisk);
      push(dest, pole1TopDisk);
      moveDisk(s, d, pole1TopDisk);
    }
  }

  // helper function to show disk movement
  public void moveDisk(char fromPeg, char toPeg, int disk)
  {
    Console.WriteLine("Move the disk " + disk + " from " + fromPeg + " to " + toPeg);
  }

  // actual tower of hanoi logic
  public void tohIterative(int num_of_disks, Stack firstDisk, Stack secondDisk, Stack thirdDisk)
  {
    int i;
    int totalMoves;

    char left = 'A';
    char midddle = 'B';
    char right = 'C';

    // if number of disks is even, then interchange
    // first and last pole
    if (num_of_disks % 2 == 0)
    {
      char temp = right;
      right = midddle;
      midddle = temp;
    }
    totalMoves = (int)(Math.Pow(2, num_of_disks) - 1);

    // larger disks will be pushed first
    for (i = num_of_disks; i >= 1; i--)
      push(firstDisk, i);

    for (i = 1; i <= totalMoves; i++)
    {
      if (i % 3 == 1)
      {

        moveDisksBetweenTwoPoles(firstDisk, thirdDisk, left, right);
      }

      else if (i % 3 == 2)
      {

        moveDisksBetweenTwoPoles(firstDisk, secondDisk, left, midddle);
      }

      else if (i % 3 == 0)
      {
        moveDisksBetweenTwoPoles(secondDisk, thirdDisk, midddle, right);
      }
    }
  }
}

public class HanoiRecursive
{
  public static void solveTowers(int n, char start, char end, char temp)
  {
    if (n > 0)
    {
      solveTowers(n - 1, start, temp, end);
      Console.WriteLine("Move disk from " + start + " to " + end);
      solveTowers(n - 1, temp, end, start);
    }
  }
}

class CRC_CD_Assignment2_2
{
  // main application entry point
  public static void Main(string[] args)
  {
    // convert number args to a useable array
    int count = Convert.ToInt32(args[1]);

    if (args[0] == "-Iterative")
    {
      Console.WriteLine("Tower of Hanoi - Iterative - Result:");

      HanoiIterative ob = new HanoiIterative();
      HanoiIterative.Stack left;
      HanoiIterative.Stack middle;
      HanoiIterative.Stack right;

      // create three stacks
      left = ob.createStack(count);
      middle = ob.createStack(count);
      right = ob.createStack(count);

      ob.tohIterative(count, left, right, middle);
      // ob.printTowers(count, left, middle, right);
    }
    else if (args[0] == "-Recursive")
    {
      //towers
      char firstTower = 'A';
      char secondTower = 'B';
      char thirdTower = 'C';

      Console.WriteLine("Tower of Hanoi - Recursive - Result:");
      HanoiRecursive.solveTowers(count, firstTower, thirdTower, secondTower);
    }
  }
}