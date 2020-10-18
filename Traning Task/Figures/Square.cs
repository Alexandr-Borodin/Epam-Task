using System;
using System.Drawing;
using FigureBuildExceptions;
using FigureValidator;

namespace Figures
{
    /// <summary>
    /// Describes square.
    /// </summary>
    public class Square : Quadrangle
    {
        /// <summary>
        /// Override property pf perimeter for square.
        /// </summary>
        public override double Perimeter => Sides[0] * 4;

        /// <summary>
        /// Override property of area for square,
        /// </summary>
        public override double Area => Math.Pow(Sides[0], 2);

        /// <summary>
        /// Square validator.
        /// </summary>
        private static SquareValidator _validator { get; } = new SquareValidator();

        /// <summary>
        /// Constructor of square.
        /// </summary>
        /// <param name="vertices">Expected vertices of square.</param>
        public Square(params Point[] vertices) : base(vertices)
        {
            if (!IsValid(vertices))
                throw new FigureBuildException("Can't create a square.");
        }

        /// <summary>
        /// Checks valid of given vertices(opportunity to creates rectangle from it).
        /// </summary>
        /// <param name="verices">Expected vertices of square.</param>
        /// <returns>True if can create square from given points, otherwise false.</returns>
        public new static bool IsValid(params Point[] verices)
        {
            return _validator.IsCanCreateFigure(verices);
        }

        /// <summary>
        /// Override ToString method.
        /// </summary>
        /// <returns>String "square".</returns>
        public override string ToString()
        {
            return "Square";
        }
    }
}