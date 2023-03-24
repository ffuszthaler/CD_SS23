# Explanation of my Implementation

# What is the Tower of Hanoi?
The tower of hanoi is a mathematical puzzle. It consists of three rods and a number of disks of different sizes which can slide onto any rod. The puzzle starts with the disks in a neat stack in ascending order of size on one rod, the smallest at the top. We have to obtain the same stack on the third rod.

Rules:
* Only one disk can be moved at a time.
* A disk can only be moved if it is the uppermost disk on a tower.
* No disk is allowed to be placed on top of a smaller disk.

# Iterative Implementation
The iterative method was implemeted by first creating a custom datatype called a ```Stack``` and functions to interact with it, such as adding and removing data from it.

```csharp
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
```

* This function handles sending data between two stacks by comparing their top value and depending on the condition that applies do one or the other.
```csharp
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
```

* This is a helper function that prints the disk movements between the poles
```csharp
  // helper function to show disk movement
  public void moveDisk(char fromPeg, char toPeg, int disk)
  {
    Console.WriteLine("Move the disk " + disk + " from " + fromPeg + " to " + toPeg);
  }
```

* And lastly this function "does" the actual tower of hanoi problem according to its rules.
```csharp
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
```

* This is the visualization, as you can see I wasn't able to finish it in time, but it is better than nothing.
```csharp
  public void stepVisualization(int num_of_disks, Stack firstDisk, Stack secondDisk, Stack thirdDisk)
  {
    for (int i = num_of_disks - 1; i > -1; i--)
    {
      Console.WriteLine(firstDisk.array[i] + " " + secondDisk.array[i] + " " + thirdDisk.array[i]);
    }

    // addes nice steps to animation
    Thread.Sleep(500);
  }
```

# Recursive Implementation
The recursive method works by simply looping over the towers for the amount of ```count``` (imaginery disk) but at the same time slowly decreasing ```count``` and only for as long as it is bigger than zero.
```csharp
  if (count > 0)
  {
    solveTowers(count - 1, startPeg, tempPeg, endPeg);
    Console.WriteLine("Move disk from " + startPeg + ' ' + endPeg);
    solveTowers(count - 1, tempPeg, endPeg, startPeg);
  }
```