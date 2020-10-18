using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Figures;

namespace FigureGenerators
{
    /// <summary>
    /// Describes square generator.
    /// </summary>
    public class SquareGenerator
    {
        /// <summary>
        /// Gets random square.
        /// </summary>
        /// <returns>Random square.</returns>
        public static Square GetRandomSquare()
        {
            Random random = new Random();

            int elongation = random.Next(2, 20);
            Point point1 = new Point(random.Next(-10, 10), random.Next(-10, 10));

            Point point2 = new Point(point1.X - elongation, point1.Y);
            Point point3 = new Point(point2.X, point2.Y + elongation);
            Point point4 = new Point(point3.X + elongation, point3.Y);

            return new Square(point1, point2, point3, point4);
        }
    }
}