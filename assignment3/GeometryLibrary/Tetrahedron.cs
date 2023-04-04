namespace GeometryLibrary;

public class Tetrahedron : Geometry
{
  public Vec3[] vertices;
  public Edge[] edges;

  Tetrahedron(Vec3 v1, Vec3 v2, Vec3 v3, Vec3 v4)
  {
    vertices = new Vec3[] { v1, v2, v3, v4 };
    edges = new Edge[] {
      new Edge(v2, v1),
      new Edge(v2, v3),
      new Edge(v1, v3),
      new Edge(v4, v1),
      new Edge(v4, v2),
      new Edge(v4, v3)
    };
  }

  public static bool operator ==(Tetrahedron t1, Tetrahedron t2)
  {
    foreach (Vec3 v1 in t1.vertices)
    {
      foreach (Vec3 v2 in t2.vertices)
      {
        if (v1.x == v2.x && v1.y == v2.y && v1.z == v2.z)
        {
          return true;
        }
      }
    }
    return false;
  }

  public static bool operator !=(Tetrahedron t1, Tetrahedron t2)
  {
    foreach (Vec3 v1 in t1.vertices)
    {
      foreach (Vec3 v2 in t2.vertices)
      {
        if (v1.x != v2.x && v1.y != v2.y && v1.z != v2.z)
        {
          return true;
        }
      }
    }
    return false;
  }

  public Vec3 Centroid()
  {
    float x = 0.0F;
    float y = 0.0F;
    float z = 0.0F;

    foreach (Vec3 v in vertices)
    {
      x += v.x / vertices.Length;
      y += v.y / vertices.Length;
      z += v.z / vertices.Length;
    }

    return new Vec3(x, y, z);
  }

  public float SurfaceArea()
  {
    // get length for each edge and calculate s for heron's formula
    float s = 1.0F / 2.0F * (edges[0].getLength() + edges[1].getLength() + edges[2].getLength());

    foreach (Edge e in edges)
    {
      float length = e.getLength();
      return (float)Convert.ToDouble(Math.Sqrt(s - length));
    }

    return 0.0F;
  }
}