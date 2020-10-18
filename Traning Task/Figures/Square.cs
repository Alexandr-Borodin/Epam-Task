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
    public class Square : Quadrangle
    {
        public override double Perimeter => Sides[0] * 4;

        public override double Area => Math.Pow(Sides[0], 2);

        private static SquareValidator _validator { get; } = new SquareValidator();

        public Square(params Point[] vertices) : base(vertices)
        {
            if (!IsValid(vertices))
                throw new FigureBuildException("Can't create a square.");
        }

        public new static bool IsValid(params Point[] verices)
        {
            return _validator.IsCanCreateFigure(verices);
        }

        public override string ToString()
        {
            return string.Join(" ", "Square");
        }
    }
}