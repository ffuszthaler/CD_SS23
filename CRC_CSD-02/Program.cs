using System;

// FLOAT
Console.WriteLine("Using float:");
float a = 0.1f;
float b = 0.2f;

if (a + b == 0.3f)
{
  Console.WriteLine($"{a} + {b} equals 0.3");
}
else
{
  Console.WriteLine($"{a} + {b} does NOT equals 0.3");
}

// DOUBLE
Console.WriteLine("Using doubles:");
double c = 0.1;
double d = 0.2;

if (c + d == 0.3)
{
  Console.WriteLine($"{c} + {d} equals 0.3");
}
else

{
  Console.WriteLine($"{a} + {d} does NOT equals 0.3");
}

// DECIMAL
Console.WriteLine("Using decimals:");
decimal e = 0.1M;
decimal f = 0.2M;

if (e + f == 0.3M)
{
  Console.WriteLine($"{e} + {f} equals 0.3");
}
else
{
  Console.WriteLine($"{e} + {f} does NOT equals 0.3");
}
