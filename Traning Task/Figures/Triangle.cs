using System;
using System.Drawing;
using FigureBuildExceptions;
using FigureValidator;

namespace Figures
{
    /// <summary>
    /// Describes triangle.
    /// </summary>
    public class Triangle : Polygon
    {
        /// <summary>
        /// Override property of perimeter for triangle.
        /// </summary>
        public override double Perimeter => Sides[0] + Sides[1] + Sides[2];

        /// <summary>
        /// Property of semi-perimeter for triangle.
        /// </summary>
        public double SemiPerimeter => Perimeter / 2;

        /// <summary>
        /// Triangle validator.
        /// </summary>
        private static TriangleValidator _validator { get; } = new TriangleValidator();

        /// <summary>
        /// Override property of area for triangle.
        /// </summary>
        public override double Area => Math.Sqrt(SemiPerimeter * 
                                                 (SemiPerimeter - Sides[0]) * 
                                                 (SemiPerimeter - Sides[1]) *
                                                 (SemiPerimeter - Sides[2]));

        /// <summary>
        /// Constructor of triangle.
        /// </summary>
        /// <param name="vertices"></param>
        public Triangle(params Point[] vertices) : base(vertices)
        {
            if (!IsValid(vertices))
                throw  new FigureBuildException("Can't create a triangle");
        }

        /// <summary>
        /// Checks valid of given vertices(opportunity to creates triangle from it).
        /// </summary>
        /// <param name="vertices">Expected vertices of triangle.</param>
        /// <returns>True if can create a triangle from given vertices, otherwise false.</returns>
        public new static bool IsValid(params Point[] vertices)
        {
            return _validator.IsCanCreateFigure(vertices);
        }

        /// <summary>
        /// Override ToStringM method.
        /// </summary>
        /// <returns>String "Triangle".</returns>
        public override string ToString()
        {
            return "Triangle";
        }
    }
}