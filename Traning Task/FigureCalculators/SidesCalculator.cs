using System;
using System.Drawing;

namespace Calculators
{
    /// <summary>
    /// Describes figure sides calculator.
    /// </summary>
    public static class SidesCalculator
    {

        /// <summary>
        /// Gets array of calculated sides.
        /// </summary>
        /// <param name="vertices">Vertices of expected figure.</param>
        /// <returns>Array of calculated sides.</returns>
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
