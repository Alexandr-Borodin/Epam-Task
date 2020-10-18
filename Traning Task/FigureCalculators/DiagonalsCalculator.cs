using System;
using System.Drawing;

namespace Calculators
{
    /// <summary>
    /// Describes calculator quadrangle diagonals.
    /// </summary>
    public static class QuadrangleDiagonalsCalculator
    {
        /// <summary>
        /// Gets calculated quadrangle diagonals.
        /// </summary>
        /// <param name="vertices">Vertices of expected figure.</param>
        /// <returns>Array which include calculated quadrangle diagonals.</returns>
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