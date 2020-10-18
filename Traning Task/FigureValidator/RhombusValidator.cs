using System.Drawing;
using ComparatorsByPoints;

namespace FigureValidator
{
    /// <summary>
    /// Describes rhombus validator.
    /// </summary>
    public class RhombusValidator : IFigureValidator
    {
        /// <summary>
        /// Quadrangle validator.
        /// </summary>
        private QuadrangleValidator _quadrangleValidator;

        /// <summary>
        /// Constructor of rhombus validator.
        /// </summary>
        public RhombusValidator()
        {
            _quadrangleValidator = new QuadrangleValidator();
        }

        /// <summary>
        /// Checks if can create figure from given points.
        /// </summary>
        /// <param name="vertices">Expected vertices of figure.</param>
        /// <returns>True if can create a figure from given points, otherwise false.</returns>
        public bool IsCanCreateFigure(params Point[] vertices)
        {
            if (!WillItMakeARhombus(vertices))
                return false;

            return true;
        }

        /// <summary>
        /// Checks if can create rhombus from given points.
        /// </summary>
        /// <param name="vertices">Expected vertices of figure.</param>
        /// <returns>True if can create a rhombus from given points, otherwise false.</returns>
        private bool WillItMakeARhombus(params Point[] vertices)
        {
            if (!_quadrangleValidator.IsCanCreateFigure(vertices))
                return false;

            bool result = PolygonComparator.AreTheSidesEqual(vertices) && !QuadrangleComparator.AreTheDiagonalsEqual(vertices);

            return result;
        }
    }
}