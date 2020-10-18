using System;
using System.Drawing;
using Figures;

namespace FigureGenerators
{
    /// <summary>
    /// Describes circle generator.
    /// </summary>
    public class CircleGenerator
    {
        /// <summary>
        /// Gets random circle.
        /// </summary>
        /// <returns>Random circle.</returns>
        public static Circle GetRandomCircle()
        {
            Random random  = new Random();

            Point point1;
            Point point2;

            do
            {
                point1 = new Point(random.Next(-20, 20), random.Next(-20, 20));
                point2 = new Point(random.Next(-20, 20), random.Next(-20, 20));

            } while (point1.X == point2.X && point1.Y == point2.Y);

            return new Circle(point1, point2);
        }
    }
}
