using System.Drawing;

namespace FigureValidator
{
    /// <summary>
    /// Describes circle validator.
    /// </summary>
    public class CircleValidator : IFigureValidator
    {
        /// <summary>
        /// Figure validator.
        /// </summary>
        private CommonFigureValidator _figureValidator;

        /// <summary>
        /// Constructor of circle validator.
        /// </summary>
        public CircleValidator()
        {
            _figureValidator = new CommonFigureValidator();
        }

        /// <summary>
        /// Checks if can crate a figure from given points.
        /// </summary>
        /// <param name="vertices">Expected vertices of figure.</param>
        /// <returns>True if can create figure from given points, otherwise false.</returns>
        public bool IsCanCreateFigure(params Point[] vertices)
        {
            if (!WillItMakeACircle(vertices))
                return false;

            return true;
        }

        /// <summary>
        /// Checks if can crate a circle from given points.
        /// </summary>
        /// <param name="vertices">Expected center and edge points of circle.</param>
        /// <returns>True if can create circle from given points, otherwise false.</returns>
        private bool WillItMakeACircle(params Point[] vertices)
        {
            if (!_figureValidator.IsCanCreateFigure(vertices) || vertices.Length > 2)
            {
                return false;
            }

            return !(vertices[0].X == vertices[1].X && vertices[0].Y == vertices[1].Y);
        }
    }
}