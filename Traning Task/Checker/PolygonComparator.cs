using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculators;

namespace ComparatorsByPoints
{
    public static class PolygonComparator
    {
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