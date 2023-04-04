using System;

namespace GeometryLibrary;

public interface Geometry
{
  public Vec3 Centroid();

  public float SurfaceArea();
}