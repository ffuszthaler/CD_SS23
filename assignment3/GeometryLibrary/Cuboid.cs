namespace GeometryLibrary;

public class Cuboid : Geometry
{
  public Vec3[] vertices;
  public Edge[] edges;

  public Cuboid(Vec3 v1, Vec3 v2, Vec3 v3, Vec3 v4, Vec3 v5, Vec3 v6, Vec3 v7, Vec3 v8)
  {
    vertices = new Vec3[] { v1, v2, v3, v4, v5, v6, v7, v8 };
    edges = new Edge[] {
      new Edge(v1, v2),
      new Edge(v1, v4),
      new Edge(v2, v3),
      new Edge(v3, v4),
      new Edge(v1, v5),
      new Edge(v2, v6),
      new Edge(v3, v7),
      new Edge(v4, v8),
      new Edge(v5, v6),
      new Edge(v5, v8),
      new Edge(v6, v7),
      new Edge(v7, v8),
    };
  }

  public static bool operator ==(Cuboid c1, Cuboid c2)
  {
    for (int i = 0; i <= c1.vertices.Length; i++)
    {
      if (c1.vertices[i].x == c2.vertices[i].x && c1.vertices[i].y == c2.vertices[i].y && c1.vertices[i].z == c2.vertices[i].z)
      {
        return true;
      }
    }
    return false;
  }

  public static bool operator !=(Cuboid c1, Cuboid c2)
  {
    for (int i = 0; i <= c1.vertices.Length; i++)
    {
      if (c1.vertices[i].x != c2.vertices[i].x && c1.vertices[i].y != c2.vertices[i].y && c1.vertices[i].z != c2.vertices[i].z)
      {
        return true;
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

  public float Volume()
  {
    return edges[0].getLength() * edges[1].getLength() * edges[2].getLength();
  }

  public float SurfaceArea()
  {
    Thread.Sleep(1000);

    // length (l), width (w), and height (h): surface area (SA) = 2*(l*w + l*h + h*w)
    return 2 * (edges[0].getLength() * edges[1].getLength() + edges[0].getLength() * edges[1].getLength() + edges[0].getLength() * edges[1].getLength());
  }
}