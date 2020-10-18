using System.Drawing;
using Calculators;
using FigureBuildExceptions;
using FigureValidator;

namespace Figures
{
    /// <summary>
    /// Describes abstract essence polygon.
    /// </summary>
    public abstract class Polygon: Figure
    {
        /// <summary>
        /// Stores sides of polygon.
        /// </summary>
        public double[] Sides;

        /// <summary>
        /// Override perimeter property which stores perimeter of polygon.
        /// </summary>
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

        /// <summary>
        /// Validator of polygon.
        /// </summary>
        private static PolygonValidator _validator = new PolygonValidator();

        /// <summary>
        /// Constructor of polygon.
        /// </summary>
        /// <param name="vertices">Expected vertices of polygon.</param>
        protected Polygon(params Point[] vertices) : base(vertices)
        {
            if(!IsValid(vertices))
                throw new FigureBuildException("Can't create a polygon.");

            Sides = SidesCalculator.CalculateSides(vertices);
        }

        /// <summary>
        /// Hidden method to check if valid expected figure from vertices.
        /// </summary>
        /// <param name="vertices">Expected vertices of polygon.</param>
        /// <returns>True if can create polygon from this point, otherwise false.</returns>
        public new static bool IsValid(params Point[] vertices)
        {
            return _validator.IsCanCreateFigure(vertices);
        }

        /// <summary>
        /// Override ToString method.
        /// </summary>
        /// <returns>String "Polygon".</returns>
        public override string ToString()
        {
            return "Polygon";
        }
    }
}
