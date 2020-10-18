using System.Drawing;
using FigureBuildExceptions;
using FigureValidator;

namespace Figures
{
    /// <summary>
    /// Describes rhombus.
    /// </summary>
    public class Rhombus : Quadrangle
    {
        /// <summary>
        /// Override property of area for rhombus.
        /// </summary>
        public override double Area => 0.5f * DiagonalA * DiagonalB;

        /// <summary>
        /// Rhombus validator.
        /// </summary>
        private static RhombusValidator _validator { get; } = new RhombusValidator();

        /// <summary>
        /// Constructor of rhombus.
        /// </summary>
        /// <param name="vertices">Expected vertices of rhombus.</param>
        public Rhombus(params Point[] vertices) : base(vertices)
        {
            if (!IsValid(vertices))
                throw new FigureBuildException("Can't create a rhombus.");
        }

        /// <summary>
        /// Checks valid of given vertices(opportunity to creates rectangle from it).
        /// </summary>
        /// <param name="vertices">Expected vertices of rhombus.</param>
        /// <returns>True if can create a rhombus from given vertices, otherwise false.</returns>
        public new static bool IsValid(params Point[] vertices)
        {
            return _validator.IsCanCreateFigure(vertices);
        }

        /// <summary>
        /// Override ToString method.
        /// </summary>
        /// <returns>String "Rhombus".</returns>
        public override string ToString()
        {
            return "Rhombus";
        }
    }
}