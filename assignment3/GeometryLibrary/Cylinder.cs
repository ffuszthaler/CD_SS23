namespace GeometryLibrary;

// cylinder inherits from the geometry interface
public class Cylinder : Geometry
{
  public Vec3[] vertices;
  public Edge[] edges;
  public float r;

  // constructor
  public Cylinder(Vec3 v1, Vec3 v2, float radius)
  {
    vertices = new Vec3[] { v1, v2 };
    edges = new Edge[] {
      new Edge(v1, v2),
    };
    r = radius;
  }

  // overridden comparison operator
  public static bool operator ==(Cylinder c1, Cylinder c2)
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

  public static bool operator !=(Cylinder c1, Cylinder c2)
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

  // function that returns the height of the cylinder
  public float Height()
  {
    return edges[0].getLength();
  }

  // top & botton area caluation (technically the same but having both functions could be more convenient)
  public float TopArea()
  {
    return (float)Math.PI * (float)Math.Pow(2, Convert.ToDouble(r));
  }

  public float BottomArea()
  {
    return (float)Math.PI * (float)Math.Pow(2, Convert.ToDouble(r));
  }

  // volume calucation
  public float Volume()
  {
    return (float)Math.PI * (float)Math.Pow(2, Convert.ToDouble(r)) * Height();
  }

  // surface area calculation
  public float SurfaceArea()
  {
    // have the thread wait 1 sec.
    Thread.Sleep(1000);

    return 2 * (float)Math.PI * r * Height() + 2 * (float)Math.PI * (float)Math.Pow(2, Convert.ToDouble(r));
  }

  // centroid calculation
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
}