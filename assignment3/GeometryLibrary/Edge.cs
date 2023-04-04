namespace GeometryLibrary;

public struct Edge
{
  // fields
  public Vec3 sourceV3;
  public Vec3 targetV3;

  // constructor
  public Edge(Vec3 source, Vec3 target)
  {
    sourceV3 = source;
    targetV3 = target;
  }

  // calculate length between two vertices
  public float getLength()
  {
    float lengthX = Math.Abs(targetV3.x - sourceV3.x);
    float lengthY = Math.Abs(targetV3.y - sourceV3.y);
    float lengthZ = Math.Abs(targetV3.z - sourceV3.z);

    return lengthX + lengthY + lengthZ;
  }
}