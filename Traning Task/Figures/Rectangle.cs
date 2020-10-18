using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FigureBuildExceptions;
using FigureValidator;

namespace Figures
{
    public class Rectangle : Quadrangle
    {
        public override double Area => Sides[0] * Sides[1];

        private static RectangleValidator _validator { get; } = new RectangleValidator();

        public Rectangle(params Point[] vertices) : base(vertices)
        {
            if (!IsValid(vertices))
                throw new FigureBuildException("Can't create a rectangle.");
            /*for (int i = 0; i < vertices.Length; i++)
            {
                Console.WriteLine(vertices[i]);
            }*/
        }

        public new static bool IsValid(params Point[] vertices)
        {
            return _validator.IsCanCreateFigure(vertices);
        }

        public override string ToString()
        {
            return "Rectangle";
        }
    }
}
