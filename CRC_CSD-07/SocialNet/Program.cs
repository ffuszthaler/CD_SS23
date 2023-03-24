using System;
using GraphLibrary;

public class VertexProperty : BasicVertexProperty
{
  public uint Age;
}

public class EdgeProperty : BasicEdgeProperty
{
  public float distance;
}

public class Program
{
  static void Main(string[] args)
  {
    Graph<VertexProperty, EdgeProperty> graph = new Graph<VertexProperty, EdgeProperty>();
    uint v1 = graph.AddVertex("Helen");
    uint v2 = graph.AddVertex("Tony");
    uint v3 = graph.AddVertex("Yun");
    uint v4 = graph.AddVertex("Tim");

    graph.AddEdge(v1, v2);
    graph.AddEdge(v1, v3);
    graph.AddEdge(v2, v3);
    graph.PrintGraph();

    graph.RemoveVertex("Helen");
    graph.PrintGraph();
  }
}