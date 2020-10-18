using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Figures;
using FigureValidator;

namespace FigureGenerators
{
    /// <summary>
    /// Describes triangle generator.
    /// </summary>
    public static class TriangleGenerator
    {
        /// <summary>
        /// Gets random triangle.
        /// </summary>
        /// <returns>Random triangle.</returns>
        public static Triangle GetRandomTriangle()
        {
            Random random = new Random();

            Point point1;
            Point point2;
            Point point3;

            do
            {
                point1 = new Point(random.Next(-20, 20), random.Next(-20, 20));
                point2 = new Point(random.Next(-20, 20), random.Next(-20, 20));
                point3 = new Point(random.Next(-20, 20), random.Next(-20, 20));
            } while (PointsChecker.IsThreePointsLiedOnSameStraight(point1, point2, point3));

            return new Triangle(point1, point2, point3);
        }
    }
}
