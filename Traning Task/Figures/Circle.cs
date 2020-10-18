using System;
using System.Drawing;
using FigureBuildExceptions;
using FigureValidator;

namespace Figures
{
    /// <summary>
    /// Describes Circle
    /// </summary>
    public class Circle : Figure
    {
        /// <summary>
        /// Property describes radius for a circle.
        /// </summary>
        public double Radius => Math.Sqrt(Math.Pow(Vertices[1].X - Vertices[0].X, 2) + Math.Pow(Vertices[1].Y - Vertices[0].Y, 2));

        /// <summary>
        /// Override property of perimeter for circle.
        /// </summary>
        public override double Perimeter => 2 * Math.PI * Radius;

        /// <summary>
        /// Override property of area fo circle.
        /// </summary>
        public override double Area => Math.PI * Math.Pow(Radius, 2);

        /// <summary>
        /// Circle validator.
        /// </summary>
        private static CircleValidator _validator { get; } = new CircleValidator();

        /// <summary>
        /// Constructor of circle.
        /// </summary>
        /// <param name="centerAndEdge">Center and edge point of expected circle.</param>
        public Circle(params Point[] centerAndEdge) : base(centerAndEdge)
        {
            if(!IsValid(centerAndEdge))
                throw new FigureBuildException("Can't create a circle.");
        }

        /// <summary>
        /// Checks valid of given vertices(opportunity to creates circle from it).
        /// </summary>
        /// <param name="vertices">Expected center and edge point of circle.</param>
        /// <returns>True if can creates a circle from given points, otherwise false.</returns>
        public new static bool IsValid(params Point[] vertices)
        {
            return _validator.IsCanCreateFigure(vertices);
        }

        /// <summary>
        /// Override ToString method.
        /// </summary>
        /// <returns>String "Circle".</returns>
        public override string ToString()
        {
            return "Circle";
        }
    }
}
