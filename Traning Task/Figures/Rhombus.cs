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
    public class Rhombus : Quadrangle
    {
        public override double Area => 0.5f * DiagonalA * DiagonalB;

        private static RhombusValidator _validator { get; } = new RhombusValidator();

        public Rhombus(params Point[] vertices) : base(vertices)
        {
            if (!IsValid(vertices))
            {
                for (int i = 0; i < vertices.Length; i++)
                {
                    Console.WriteLine(vertices[i]);
                }
                throw new FigureBuildException("Can't create a rhombus.");
            }
        }

        public new static bool IsValid(params Point[] vertices)
        {
            return _validator.IsCanCreateFigure(vertices);
        }

        public override string ToString()
        {
            return "Rhombus";
        }
    }
}