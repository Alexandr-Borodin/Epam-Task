using System.Drawing;

namespace FigureValidator
{
    /// <summary>
    /// Describes figure validator.
    /// </summary>
    public class CommonFigureValidator : IFigureValidator
    {
        /// <summary>
        /// Checks if can crate a figure from given points.
        /// </summary>
        /// <param name="vertices">Expected vertices of figure.</param>
        /// <returns>True if can create a figure from given points, otherwise false.</returns>
        public bool IsCanCreateFigure(params Point[] vertices)
        {
            if (vertices.Length < 2)
                return false;

            return true;
        }
    }
}