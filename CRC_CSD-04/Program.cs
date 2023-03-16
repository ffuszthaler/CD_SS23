using System;

namespace CRC_CSD_04
{
  public class Node
  {
    // Fields
    private int _data;
    private Node? _next;

    // Constructors
    public Node(int d)
    {
      _data = d;
      _next = null;
    }

    // Getters & Setters
    public int Data
    {
      get => _data;
      set => _data = value;
    }

    public Node? Next
    {
      get => _next;
      set => _next = value;
    }

    // Finalizers
    ~Node() { }
  }

  public class SingleLinkedList
  {
    // Fields
    private Node? _head;

    // Contructors
    public SingleLinkedList()
    {
      _head = null;
    }

    // Getters & Setters
    public Node? head
    {
      get => _head;
      set => _head = value;
    }

    // Finalizers
    ~SingleLinkedList() { }

    // Methods
    // InsertFront
    public void InsertFront(int newData)
    {
      Node newNode = new Node(newData);
      newNode.Next = _head;
      _head = newNode;
    }

    // InsertLast
    public void InsertLast(int newData)
    {
      Node newNode = new Node(newData);

      if (_head == null)
      {
        _head = newNode;
      }
      else
      {
        Node? lastNode = GetLastNode();

        if (lastNode != null)
        {
          lastNode.Next = newNode;
        }
      }
    }

    // GetLastNode
    public Node? GetLastNode()
    {
      Node? temp = _head;

      while ((temp != null) && (temp.Next != null))
      {
        temp = temp.Next;
      }

      return temp;
    }

    // InsertAfter
    public void InsertAfter(Node? preNode, int newData)
    {
      if (preNode == null)
      {
        Console.WriteLine("The given previous node cannot be null!");
      }
      else
      {
        Node newNode = new Node(newData);
        newNode.Next = preNode.Next;
        preNode.Next = newNode;
      }
    }

    // FindByKey
    public Node? FindByKey(int data)
    {
      Node? temp = _head;

      while (temp != null)
      {
        if (temp.Data == data)
        {
          return temp;
        }

        temp = temp.Next;
      }

      return null;
    }

    // DeleteNodeByKey
    public void DeleteNodeByKey(int key)
    {
      Node? temp = _head;
      Node? prev = null;

      // Key is equal
      if ((temp != null) && temp.Data == key)
      {
        _head = temp.Next;
        return;
      }

      while ((temp != null) && (temp.Data != key))
      {
        prev = temp;
        temp = temp.Next;
      }

      // Cannot find key in list
      if (temp == null) return;

      if (prev != null) prev.Next = temp.Next;
    }

    // PrintList
    public void PrintList()
    {
      Node? temp = _head;
      Console.Write("The SingleLinkedList: ");

      while (temp != null)
      {
        Console.Write(temp.Data + " ");
        temp = temp.Next;
      }

      Console.WriteLine();
    }
  }

  // /////////////////////////////////////////////////////////////////

  // public class DoubleNode
  // {
  //   // Fields
  //   private int _data;
  //   private DoubleNode? _next;
  //   private DoubleNode? _previous;

  //   // Constructors
  //   public DoubleNode(int d)
  //   {
  //     _data = d;
  //     _next = null;
  //   }

  //   // Getters & Setters
  //   public int Data
  //   {
  //     get => _data;
  //     set => _data = value;
  //   }

  //   public DoubleNode? Next
  //   {
  //     get => _next;
  //     set => _next = value;
  //   }

  //   public DoubleNode? Previous
  //   {
  //     get => _previous;
  //     set => _previous = value;
  //   }

  //   // Finalizers
  //   ~DoubleNode() { }
  // }

  // public class DoubleLinkedList
  // {
  //   // Fields
  //   private DoubleNode? _head;
  //   private DoubleNode? _tail;

  //   // Contructors
  //   public DoubleLinkedList()
  //   {
  //     _head = null;
  //     _tail = null;
  //   }

  //   // Getters & Setters
  //   public DoubleNode? head
  //   {
  //     get => _head;
  //     set => _head = value;
  //   }

  //   public DoubleNode? tail
  //   {
  //     get => _tail;
  //     set => _tail = value;
  //   }

  //   // Finalizers
  //   ~DoubleLinkedList() { }

  //   // Methods
  //   // InsertFront
  //   public void InsertFront(int newData)
  //   {
  //     DoubleNode newNode = new DoubleNode(newData);
  //     newNode.Next = _head;
  //     _head = newNode;
  //     _head = null;

  //     newNode.Previous = _tail;

  //     if (newNode.Next == null && newNode.Previous == null)
  //     {
  //       _head = _tail;
  //     }
  //   }

  //   // InsertLast
  //   public void InsertLast(int newData)
  //   {
  //     DoubleNode newNode = new DoubleNode(newData);

  //     if (_head == null)
  //     {
  //       _head = newNode;
  //     }
  //     else
  //     {
  //       DoubleNode? lastNode = GetLastNode();

  //       if (lastNode != null)
  //       {
  //         lastNode.Next = newNode;
  //       }
  //     }
  //   }

  //   // GetLastNode
  //   public DoubleNode? GetLastNode()
  //   {
  //     DoubleNode? temp = _head;

  //     while ((temp != null) && (temp.Next != null))
  //     {
  //       temp = temp.Next;
  //     }

  //     return temp;
  //   }

  //   // InsertAfter
  //   public void InsertAfter(DoubleNode? preNode, int newData)
  //   {
  //     if (preNode == null)
  //     {
  //       Console.WriteLine("The given previous node cannot be null!");
  //     }
  //     else
  //     {
  //       DoubleNode newNode = new DoubleNode(newData);
  //       newNode.Next = preNode.Next;
  //       preNode.Next = newNode;
  //     }
  //   }

  //   // FindByKey
  //   public DoubleNode? FindByKey(int data)
  //   {
  //     DoubleNode? temp = _head;

  //     while (temp != null)
  //     {
  //       if (temp.Data == data)
  //       {
  //         return temp;
  //       }

  //       temp = temp.Next;
  //     }

  //     return null;
  //   }

  //   // DeleteNodeByKey
  //   public void DeleteNodeByKey(int key)
  //   {
  //     DoubleNode? temp = _head;
  //     DoubleNode? prev = null;

  //     // Key is equal
  //     if ((temp != null) && temp.Data == key)
  //     {
  //       _head = temp.Next;
  //       return;
  //     }

  //     while ((temp != null) && (temp.Data != key))
  //     {
  //       prev = temp;
  //       temp = temp.Next;
  //     }

  //     // Cannot find key in list
  //     if (temp == null) return;

  //     if (prev != null) prev.Next = temp.Next;
  //   }

  //   // PrintList
  //   public void PrintList()
  //   {
  //     DoubleNode? temp = _head;
  //     Console.Write("The SingleLinkedList: ");

  //     while (temp != null)
  //     {
  //       Console.Write(temp.Data + " ");
  //       temp = temp.Next;
  //     }

  //     Console.WriteLine();
  //   }
  // }

  // /////////////////////////////////////////////////////////////////

  class Program
  {
    static void Main(string[] args)
    {
      SingleLinkedList singleList = new SingleLinkedList();
      singleList.InsertLast(4);
      singleList.InsertLast(6);
      singleList.InsertFront(2);
      singleList.PrintList();

      singleList.DeleteNodeByKey(2);
      singleList.PrintList();

      singleList.InsertAfter(singleList.FindByKey(4), 5);
      singleList.PrintList();
    }
  }
}