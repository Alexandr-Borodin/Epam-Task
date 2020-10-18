using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Figures;
using Rectangle = Figures.Rectangle;

namespace FigureGenerators
{
    public static class RectangleGenerator
    {
        public static Rectangle GetRandomRectangle()
        {
            Random random = new Random();

            // foothold point

            int elongationX = random.Next(1, 20);
            int elongationY = random.Next(1, 20);

            Point point1 = new Point(random.Next(-10, 10), random.Next(-10, 10));

            Point point2 = new Point(point1.X - elongationX, point1.Y);
            Point point3 = new Point(point2.X, point2.Y + elongationY);
            Point point4 = new Point(point3.X + elongationX, point3.Y);


            return new Rectangle(point1, point2, point3, point4);
        }
    }
}
