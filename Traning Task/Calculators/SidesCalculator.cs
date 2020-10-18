using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculators
{
    public static class SidesCalculator
    {
        public static double[] CalculateSides(params Point[] vertices)
        {
            double[] sides = new double[vertices.Length];

            for (int index = 0; index < vertices.Length - 1; ++index)
            {
                sides[index] = Math.Sqrt(Math.Pow(vertices[index].X - vertices[index + 1].X, 2) +
                                         Math.Pow(vertices[index].Y - vertices[index + 1].Y, 2));
            }

            sides[vertices.Length - 1] = Math.Sqrt(Math.Pow(vertices[0].X - vertices[vertices.Length - 1].X, 2) +
                                                   Math.Pow(vertices[0].Y - vertices[vertices.Length - 1].Y, 2));

            return sides;
        }
    }
}
