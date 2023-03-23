using System;
using System.Collections.Generic;

namespace GraphLibrary;

public class Graph
{
  // fields
  private LinkedList<Vertex> _vertices;
  private LinkedList<Edge> _edges;

  // number of vertices & edges
  private uint _nVertices;
  private uint _nEdges;

  // constructor
  public Graph()
  {
    _vertices = new LinkedList<Vertex>();
    _edges = new LinkedList<Edge>();
    _nVertices = 0;
    _nEdges = 0;
  }

  // getters & setters

  // finalizer
  ~Graph() { }

  // methods

  // vertex
  // AddVertex
  public uint AddVertex(string name)
  {
    Vertex v = new Vertex(_nVertices, name);
    _vertices.AddLast(v);

    _nVertices++;

    return _nVertices - 1;
  }

  // HasVertex
  public Vertex? HasVertex(string name)
  {
    for (int i = 0; i < _vertices.Count; i++)
    {
      if (_vertices.ElementAt(i).Property.Name == name)
      {
        return _vertices.ElementAt(i);
      }
    }

    return null;
  }

  public Vertex? HasVertex(uint id)
  {
    for (int i = 0; i < _vertices.Count; i++)
    {
      if (_vertices.ElementAt(i).Property.Id == id)
      {
        return _vertices.ElementAt(i);
      }
    }

    return null;
  }

  // RemoveVertex
  public void RemoveVertex(string name)
  {
    Vertex? v = HasVertex(name);

    if (v != null)
    {
      // remove all adjacent edges
      bool allChecked = false;
      while (!allChecked)
      {
        allChecked = true;
        for (int i = 0; i < _edges.Count; i++)
        {
          // equal to source id
          if (_edges.ElementAt(i).Property.SourceId == v.Property.Id)
          {
            _edges.Remove(_edges.ElementAt(i));
            _nEdges--;

            allChecked = false;
            break;
          }

          // equal to target id
          if (_edges.ElementAt(i).Property.TargetId == v.Property.Id)
          {
            _edges.Remove(_edges.ElementAt(i));
            _nEdges--;

            allChecked = false;
            break;
          }
        }
      }

      // remove vertex
      _vertices.Remove(v);
      _nVertices--;
    }
  }

  // edge
  // AddEdge
  // HasEdge
  // RemoveEdge

  // graph
  public void PrintGraph()
  {
    Console.WriteLine("The total number of vertices is " + _nVertices);
    Console.WriteLine("The total number of edges is " + _nEdges);
    Console.WriteLine("========================");

    // vertex list
    for (int i = 0; i < _vertices.Count; i++)
    {
      Console.WriteLine($"V({_vertices.ElementAt(i).Property.Id}) = {_vertices.ElementAt(i).Property.Name}");
    }

    // edge list
    for (int i = 0; i < _edges.Count; i++)
    {
      Console.WriteLine($"E({_edges.ElementAt(i).Property.Id}) = V({_edges.ElementAt(i).Property.SourceId}) - V({_edges.ElementAt(i).Property.TargetId})");
    }
  }
}
