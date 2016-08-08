using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
  class AreaCalculator
  {
    public static double FindArea(double x1, double x2, double resolution)
    {
      double area = 0;
      double v1, v2;
      if (x1 >= x2)
      {
        v1 = x2;
        v2 = x1;
      }
      else
      {
        v1 = x1;
        v2 = x2;
      }
      for (double i = v1; i < v2; i = i + resolution)
      {
        area = area + AreaCalculator.FindArea(i, i + resolution);
      }
      return area;
    }

    public static double FindArea(double x1, double x2)
    {
      double y1 = FindY(x1);
      double y2 = FindY(x2);
      double avg = (y1 + y2) / 2;
      return System.Math.Abs(x2 - x1) * avg;
    }

    private static double FindY(double x)
    {
      return 1 / x;
    }
  }
}
