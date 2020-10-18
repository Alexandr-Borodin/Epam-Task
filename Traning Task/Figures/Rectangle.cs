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
    /// <summary>
    /// Describes rectangle.
    /// </summary>
    public class Rectangle : Quadrangle
    {
        /// <summary>
        /// Override property of area for rectangle.
        /// </summary>
        public override double Area => Sides[0] * Sides[1];

        /// <summary>
        /// Rectangle validator.
        /// </summary>
        private static RectangleValidator _validator { get; } = new RectangleValidator();

        /// <summary>
        /// Constructor of rectangle.
        /// </summary>
        /// <param name="vertices">Expected vertices of rectangle.</param>
        public Rectangle(params Point[] vertices) : base(vertices)
        {
            if (!IsValid(vertices))
                throw new FigureBuildException("Can't create a rectangle.");
        }

        /// <summary>
        /// Checks valid of given vertices(opportunity to creates rectangle from it).
        /// </summary>
        /// <param name="vertices">Expected vertices of rectangle.</param>
        /// <returns>True if can create rectangle from given points, otherwise false.</returns>
        public new static bool IsValid(params Point[] vertices)
        {
            return _validator.IsCanCreateFigure(vertices);
        }

        /// <summary>
        /// Override ToString method.
        /// </summary>
        /// <returns>String "Rectangle".</returns>
        public override string ToString()
        {
            return "Rectangle";
        }
    }
}
