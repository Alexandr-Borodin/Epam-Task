using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculators;
using FigureBuildExceptions;
using FigureValidator;

namespace Figures
{
    public abstract class Polygon: Figure
    {
        public double[] Sides;

        public override double Perimeter
        {
            get
            {
                double result = 0f;

                for (int index = 0; index < Sides.Length; index++)
                {
                    result += Sides[index];
                }

                return result;
            }
        }

        private static PolygonValidator _validator = new PolygonValidator();

        protected Polygon(params Point[] vertices) : base(vertices)
        {
            if(!IsValid(vertices))
                throw new FigureBuildException("Can't create a polygon.");

            Sides = SidesCalculator.CalculateSides(vertices);
        }

        public new static bool IsValid(params Point[] vertices)
        {
            return _validator.IsCanCreateFigure(vertices);
        }

        public override string ToString()
        {
            return "Polygon";
        }
    }
}
