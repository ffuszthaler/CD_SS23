using System;

namespace CRC_CSD_04
{
  class Program
  {
    static void Main(string[] args)
    {

    }
  }

  public class Node
  {
    // fields
    private int _data;
    private Node? _next;

    // constructors
    public Node(int d)
    {
      _data = d;
      _next = null;
    }

    // getters & setters
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

    // finalizers
    ~Node() { }
  }

  public class SingleLinkedList
  {
    // fields
    private Node? _head;

    // contructors
    public SingleLinkedList()
    {
      _head = null;
    }

    // getters & setters
    public Node? head
    {
      get => _head;
      set => _head = value;
    }

    // finalizers
    ~SingleLinkedList() { }

    // methods
    // InsertFront
    // InsertLast
    // GetLastNode
    // InsertAfter
    // FindByKey
    // DeleteNodeByKey
    // PrintList
  }
}