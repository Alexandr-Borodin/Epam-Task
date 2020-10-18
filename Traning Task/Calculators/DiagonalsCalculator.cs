using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculators
{
    public static class QuadrangleDiagonalsCalculator
    {
        public static double[] CalculateDiagonals(params Point[] vertices)
        {
            const int numberOfDiagonalsInQuadrangle = 2;

            double[] diagonals = new double[numberOfDiagonalsInQuadrangle];

            diagonals[0] = Math.Sqrt(Math.Pow(vertices[0].X - vertices[2].X, 2) +
                                     Math.Pow(vertices[0].Y - vertices[2].Y, 2));

            diagonals[1] = Math.Sqrt(Math.Pow(vertices[1].X - vertices[3].X, 2) +
                                     Math.Pow(vertices[1].Y - vertices[3].Y, 2));

            return diagonals;
        }
    }
}