﻿using System;
using System.Collections.Generic;

namespace GraphLibrary;

public class Graph<T1, T2>
where T1 : BasicVertexProperty, new()
where T2 : BasicEdgeProperty, new()
{
  // fields
  private LinkedList<Vertex<T1>> _vertices;
  private LinkedList<Edge<T2>> _edges;

  // number of vertices & edges
  private uint _nVertices;
  private uint _nEdges;

  // constructor
  public Graph()
  {
    _vertices = new LinkedList<Vertex<T1>>();
    _edges = new LinkedList<Edge<T2>>();
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
    Vertex<T1> v = new Vertex<T1>(_nVertices, name);
    _vertices.AddLast(v);

    _nVertices++;

    return _nVertices - 1;
  }

  // HasVertex
  public Vertex<T1>? HasVertex(string name)
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

  public Vertex<T1>? HasVertex(uint id)
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
    Vertex<T1>? v = HasVertex(name);

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
  public void AddEdge(uint sourceId, uint targetId)
  {
    Edge<T2>? e = HasEdge(sourceId, targetId);
    if (e == null)
    {
      Vertex<T1>? sourceV = HasVertex(sourceId);
      Vertex<T1>? targetV = HasVertex(targetId);

      if (sourceV == null || targetV == null)
      {
        Console.WriteLine("Source or target vertex could not be found. Please add vertices first!");
        return;
      }
      else
      {
        Edge<T2> newE = new Edge<T2>(_nEdges, sourceId, targetId);
        _edges.AddLast(newE);
        _nEdges++;
      }
    }
  }

  // HasEdge
  public Edge<T2>? HasEdge(uint sourceId, uint targetId)
  {
    for (int i = 0; i < _edges.Count; i++)
    {
      if ((_edges.ElementAt(i).Property.SourceId == sourceId) && (_edges.ElementAt(i).Property.TargetId == targetId))
      {
        return _edges.ElementAt(i);
      }
    }

    return null;
  }

  // RemoveEdge
  public void RemoveEdge(uint sourceId, uint targetId)
  {
    Edge<T2>? e = HasEdge(sourceId, targetId);

    if (e != null)
    {
      _edges.Remove(e);
      _nEdges--;
    }
  }

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
