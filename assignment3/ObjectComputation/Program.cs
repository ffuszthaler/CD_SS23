using System.Diagnostics;

using GeometryLibrary;

namespace Assignment3
{
  class Program
  {
    // lists of shapes
    static List<Tetrahedron> tets = new List<Tetrahedron>();
    static List<Cuboid> cubes = new List<Cuboid>();
    static List<Cylinder> cyls = new List<Cylinder>();

    static void Main(string[] args)
    {

      int ObjectCount = 5;
      float randFactor = 1.0F;
      // ================================================== //

      var timer1 = new Stopwatch();
      timer1.Start();

      // Tetrahedrons
      Random randTet = new Random();

      for (int i = 0; i < ObjectCount; i++)
      {
        float[] randVal = new float[12];
        for (int j = 0; j < randVal.Length; j++)
        {
          randVal[j] = randFactor * (float)randTet.NextDouble();
        }

        tets.Add(
          new Tetrahedron(
            new Vec3(randVal[0], randVal[1], randVal[2]),
            new Vec3(randVal[3], randVal[4], randVal[5]),
            new Vec3(randVal[6], randVal[7], randVal[8]),
            new Vec3(randVal[9], randVal[10], randVal[11])
          )
        );
      }

      // print out results
      foreach (Tetrahedron tet in tets)
      {
        Console.WriteLine($"Tetrahedron: {tet.SurfaceArea():#,0.00}");
      }
      Console.WriteLine("---");
      // ================================================== //

      // Cuboid
      Random randCube = new Random();

      for (int i = 0; i < ObjectCount; i++)
      {
        float[] randVal = new float[8];

        float randValX = randFactor * (float)randCube.NextDouble();
        float randValY = randFactor * (float)randCube.NextDouble();
        float randValZ = randFactor * (float)randCube.NextDouble();

        float cubeLength = (float)randCube.NextDouble();
        float cubeWidth = (float)randCube.NextDouble();
        float cubeHeight = (float)randCube.NextDouble();

        cubes.Add(
          new Cuboid(
            new Vec3(randValX, randValY, randValZ),
            new Vec3(randValX + cubeWidth, randValY, randValZ),
            new Vec3(randValX + cubeWidth, randValY + cubeLength, randValZ),
            new Vec3(randValX, randValY + cubeLength, randValZ),
            new Vec3(randValX, randValY, randValZ + cubeHeight),
            new Vec3(randValX + cubeWidth, randValY, randValZ + cubeHeight),
            new Vec3(randValX + cubeWidth, randValY + cubeLength, randValZ + cubeHeight),
            new Vec3(randValX, randValY + cubeLength, randValZ + cubeHeight)
          )
        );
      }

      // print out results
      foreach (Cuboid cube in cubes)
      {
        Console.WriteLine($"Cuboid: {cube.SurfaceArea():#,0.00}");
      }
      Console.WriteLine("---");
      // ================================================== //

      // Cylinder
      Random randCyl = new Random();

      for (int i = 0; i < ObjectCount; i++)
      {
        float[] randVal = new float[6];
        float randRadius = randFactor * (float)randCyl.NextDouble();
        for (int j = 0; j < randVal.Length; j++)
        {
          randVal[j] = randFactor * (float)randTet.NextDouble();
        }

        cyls.Add(
          new Cylinder(
            new Vec3(randVal[0], randVal[1], randVal[2]),
            new Vec3(randVal[3], randVal[4], randVal[5]),
            randRadius
          )
        );
      }

      // print out results
      foreach (Cylinder cyl in cyls)
      {
        Console.WriteLine($"Cylinder: {cyl.SurfaceArea():#,0.00}");
      }
      // ================================================== //

      // stop timer
      timer1.Stop();

      // handle timer result
      TimeSpan timeTaken = timer1.Elapsed;
      string timer1Result = "Time taken: " + timeTaken.ToString(@"m\:ss\.fff");

      Console.WriteLine("---");
      Console.WriteLine(timer1Result);
      Console.WriteLine("---");
      // ================================================== //


      // do same as above but with tasks
      useTasks();
    }

    static object conch = new object();

    static void getTetArea()
    {
      lock (conch)
      {
        foreach (Tetrahedron tet in tets)
        {
          Console.WriteLine($"Tetrahedron: {tet.SurfaceArea():#,0.00}");
        }
      }
    }


    static void getCuboidArea()
    {
      foreach (Cuboid cube in cubes)
      {
        float result = cube.SurfaceArea();
        lock (conch)
        {
          Console.WriteLine($"Cuboid: {result:#,0.00}");
        }
      }
    }

    static void getCylinderArea()
    {
      foreach (Cylinder cyl in cyls)
      {
        float result = cyl.SurfaceArea();
        lock (conch)
        {
          Console.WriteLine($"Cylinder: {result:#,0.00}");
        }
      }
    }

    static void useTasks()
    {

      var timer2 = new Stopwatch();
      timer2.Start();

      Task taskTet = new Task(getTetArea);
      taskTet.Start();

      Task taskCuboid = new Task(getCuboidArea);
      taskCuboid.Start();

      Task taskCylinder = new Task(getCylinderArea);
      taskCylinder.Start();

      Task[] tasks = { taskTet, taskCuboid, taskCylinder };
      Task.WaitAll(tasks);

      // stop timer
      timer2.Stop();

      // handle timer result
      TimeSpan timeTaken = timer2.Elapsed;
      string timer2Result = "Time taken: " + timeTaken.ToString(@"m\:ss\.fff");

      Console.WriteLine("---");
      Console.WriteLine(timer2Result);
      Console.WriteLine("---");
    }
  }
}