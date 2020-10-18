using System.Drawing;
using Calculators;

namespace ComparatorsByPoints
{
    /// <summary>
    /// Describes polygon comparator.
    /// </summary>
    public static class PolygonComparator
    {
        /// <summary>
        /// Check if the sides are equal in expected polygon.
        /// </summary>
        /// <param name="vertices">Vertices of expected polygon.</param>
        /// <returns>True if sides are equal, otherwise false.</returns>
        public static bool AreTheSidesEqual(params Point[] vertices)
        {
            double[] sides = SidesCalculator.CalculateSides(vertices);

            bool result = true;

            for (int index = 0; index < vertices.Length - 1 && result; index++)
            {
                if (sides[index] != sides[index + 1])
                    result = false;
            }

            return result;
        }
    }
}