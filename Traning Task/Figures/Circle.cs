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
    public class Circle : Figure
    {
        public double Radius => Math.Sqrt(Math.Pow(Vertices[1].X - Vertices[0].X, 2) + Math.Pow(Vertices[1].Y - Vertices[0].Y, 2));

        public override double Perimeter => 2 * Math.PI * Radius;

        public override double Area => Math.PI * Math.Pow(Radius, 2);

        private static CircleValidator _validator { get; } = new CircleValidator();

        public Circle(params Point[] centerAndEdge) : base(centerAndEdge)
        {
            if(!IsValid(centerAndEdge))
                throw new FigureBuildException("Can't create a circle.");
        }

        public new static bool IsValid(params Point[] vertices)
        {
            return _validator.IsCanCreateFigure(vertices);
        }

        public override string ToString()
        {
            return "Circle";
        }
    }
}
