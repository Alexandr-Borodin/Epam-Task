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
    public abstract class Quadrangle : Polygon
    {
        public double DiagonalA => Math.Sqrt(Math.Pow(Vertices[0].X - Vertices[2].X, 2) + Math.Pow(Vertices[0].Y - Vertices[2].Y, 2));

        public double DiagonalB => Math.Sqrt(Math.Pow(Vertices[1].X - Vertices[3].X, 2) + Math.Pow(Vertices[1].Y - Vertices[3].Y, 2));

        private static QuadrangleValidator _validator { get; } = new QuadrangleValidator();

        protected Quadrangle(params Point[] verices) : base(verices)
        {
            if (!IsValid(verices))
                throw new FigureBuildException("Can't create a quadrangle.");
        }

        public new static bool IsValid(params Point[] vertices)
        {
            return _validator.IsCanCreateFigure(vertices);
        }
    }
}
