using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculators;

namespace ComparatorsByPoints
{
    public static class QuadrangleComparator
    {
        public static bool AreTheDiagonalsEqual(params Point[] vertices)
        {
            double[] diagonals = QuadrangleDiagonalsCalculator.CalculateDiagonals(vertices);

            bool result = diagonals[0] == diagonals[1];

            return result;
        }

        public static bool AreTheSidesPairwiseEqual(params Point[] vertices)
        {
            double[] sides = SidesCalculator.CalculateSides(vertices);

            bool result = sides[0] == sides[2] && sides[1] == sides[3];

            return result;
        }
    }
}