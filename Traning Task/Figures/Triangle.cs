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
    public class Triangle : Polygon
    {
        public override double Perimeter => Sides[0] + Sides[1] + Sides[2];

        public double SemiPerimeter => Perimeter / 2;

        private static TriangleValidator _validator { get; } = new TriangleValidator();

        public override double Area => Math.Sqrt(SemiPerimeter * 
                                                 (SemiPerimeter - Sides[0]) * 
                                                 (SemiPerimeter - Sides[1]) *
                                                 (SemiPerimeter - Sides[2]));

        public Triangle(params Point[] vertices) : base(vertices)
        {
            if (!IsValid(vertices))
                throw  new FigureBuildException("Can't create a triangle");
        }

        public new static bool IsValid(params Point[] vertices)
        {
            return _validator.IsCanCreateFigure(vertices);
        }

        public override string ToString()
        {
            return "Triangle";
        }
    }
}