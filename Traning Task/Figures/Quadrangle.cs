using System;
using System.Drawing;
using FigureBuildExceptions;
using FigureValidator;

namespace Figures
{
    /// <summary>
    /// Describes abstract essence quadrangle.
    /// </summary>
    public abstract class Quadrangle : Polygon
    {
        /// <summary>
        /// Stores first diagonal of quadrangle.
        /// </summary>
        public double DiagonalA => Math.Sqrt(Math.Pow(Vertices[0].X - Vertices[2].X, 2) + Math.Pow(Vertices[0].Y - Vertices[2].Y, 2));

        /// <summary>
        /// Stores second diagonal of quadrangle.
        /// </summary>
        public double DiagonalB => Math.Sqrt(Math.Pow(Vertices[1].X - Vertices[3].X, 2) + Math.Pow(Vertices[1].Y - Vertices[3].Y, 2));

        /// <summary>
        /// Quadrangle validator.
        /// </summary>
        private static QuadrangleValidator _validator { get; } = new QuadrangleValidator();

        /// <summary>
        /// Constructor of Quadrangle.
        /// </summary>
        /// <param name="verices">Expected vertices of quadrangle.</param>
        protected Quadrangle(params Point[] vertices) : base(vertices)
        {
            if (!IsValid(vertices))
                throw new FigureBuildException("Can't create a quadrangle.");
        }

        /// <summary>
        /// Checks valid of given vertices(opportunity to creates quadrangle from it).
        /// </summary>
        /// <param name="vertices">Expected vertices of quadrangle.</param>
        /// <returns>True if can create quadrangle from given vertices, otherwise false.</returns>
        public new static bool IsValid(params Point[] vertices)
        {
            return _validator.IsCanCreateFigure(vertices);
        }
    }
}
