using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public class FigureCreator
    {
        public static Square CreateASquare(params Point[] vertices)
        {
            return new Square(vertices);
        }

        public static Rectangle CreateARectangle(params Point[] vertices)
        {
            return new Rectangle(vertices);
        }

        public static Circle CreateACircle(params Point[] centerAndEdge)
        {
            return new Circle(centerAndEdge);
        }

        public static Rhombus CreateARhombus(params Point[] vertices)
        {
            return  new Rhombus(vertices);
        }

        public static Triangle CreateAtTriangle(params Point[] vertices)
        {
            return new Triangle(vertices);
        }
    }
}
