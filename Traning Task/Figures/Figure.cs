using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using FigureBuildExceptions;
using FigureValidator;
using FigureValidator = FigureValidator.CommonFigureValidator;

namespace Figures
{
    /// <summary>
    /// Describes abstract essence figure.
    /// </summary>
    public abstract class Figure
    {
        public Point[] Vertices;

        public abstract double Perimeter { get; }

        public abstract double Area { get; }

        private static CommonFigureValidator _validator { get; } = new CommonFigureValidator();

        protected Figure(params Point[] vertices)
        {
            if(!IsValid(vertices))
                throw new FigureBuildException("Can't create a figure.");

            Vertices = vertices;
        }

        public static bool IsValid(params Point[] vertices)
        {
            return _validator.IsCanCreateFigure(vertices);
        }

        public override string ToString()
        {
            return "Figure";
        }
    }
}