using System.Drawing;
using Calculators;

namespace ComparatorsByPoints
{
    /// <summary>
    /// Describes quadrangle comparator.
    /// </summary>
    public static class QuadrangleComparator
    {
        /// <summary>
        /// Checks if the diagonals are equal in expected quadrangle.
        /// </summary>
        /// <param name="vertices">Expected vertices of quadrangle.</param>
        /// <returns>True if diagonals are equal, otherwise false.</returns>
        public static bool AreTheDiagonalsEqual(params Point[] vertices)
        {
            double[] diagonals = QuadrangleDiagonalsCalculator.CalculateDiagonals(vertices);

            bool result = diagonals[0] == diagonals[1];

            return result;
        }

        /// <summary>
        /// Checks if the sides are equal in expected quadrangle.
        /// </summary>
        /// <param name="vertices">Expected vertices of quadrangle.</param>
        /// <returns>True if diagonals are equal, otherwise false.</returns>
        public static bool AreTheSidesPairwiseEqual(params Point[] vertices)
        {
            double[] sides = SidesCalculator.CalculateSides(vertices);

            bool result = sides[0] == sides[2] && sides[1] == sides[3];

            return result;
        }
    }
}