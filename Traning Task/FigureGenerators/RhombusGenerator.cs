using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Figures;

namespace FigureGenerators
{
    public class RhombusGenerator
    {
        public static Rhombus GetRandomRhombus()
        {
            Random random = new Random();

            // foothold point
            Point point1;

            Point point2;
            Point point3;
            Point point4;

            do
            {
                int sideX = random.Next(4, 14);
                int sideY = random.Next(4, 14);

                int elongationX = random.Next(0, 10);
                int elongationY = elongationX == 0 ? random.Next(10, 19): 0;

                // foothold point
                point1 = new Point(random.Next(-10, 10), random.Next(-10, 10));

                point2 = new Point(point1.X + sideX + elongationX, point1.Y + sideY + elongationY);
                point3 = new Point(point2.X + sideX + elongationX, point2.Y - sideY - elongationY);
                point4 = new Point(point3.X - sideX - elongationX, point3.Y - sideY - elongationY);


            } while (!Rhombus.IsValid(point1, point2, point3, point4));

            return new Rhombus(point1, point2, point3, point4);
        }
    }
}
