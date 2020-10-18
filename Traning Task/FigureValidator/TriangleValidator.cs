using System.Drawing;

namespace FigureValidator
{
    /// <summary>
    /// Describes triangle validator.
    /// </summary>
    public class TriangleValidator : IFigureValidator
    {
        /// <summary>
        /// Polygon validator.
        /// </summary>
        private PolygonValidator _polygonValidator;

        /// <summary>
        /// Constructor of triangle validator.
        /// </summary>
        public TriangleValidator()
        {
            _polygonValidator = new PolygonValidator();
        }

        /// <summary>
        /// Checks if can create figure from given points.
        /// </summary>
        /// <param name="vertices">Expected vertices of figure.</param>
        /// <returns>True if can create a figure from given points, otherwise false.</returns>
        public bool IsCanCreateFigure(params Point[] vertices)
        {
            if (!WillItMakeATriangle(vertices))
                return false;

            return true;
        }

        /// <summary>
        /// Checks if can create triangle from given points.
        /// </summary>
        /// <param name="vertices">Expected vertices of triangle.</param>
        /// <returns>True if can create a triangle from given points, otherwise false.</returns>
        private bool WillItMakeATriangle(params Point[] vertices)
        {
            if (!_polygonValidator.IsCanCreateFigure(vertices))
                return false;

            bool result = !(vertices.Length > 3) && !PointsChecker.IsThreePointsLiedOnSameStraight(vertices);

            return result;
        }
    }
}