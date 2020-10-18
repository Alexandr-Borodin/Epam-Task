using System.Drawing;

namespace FigureValidator
{
    /// <summary>
    /// Interface describes figure validator.
    /// </summary>
    public interface IFigureValidator
    {
        /// <summary>
        /// Checks if can create figure from given points.
        /// </summary>
        /// <param name="vertices">Expected vertices of figure.</param>
        /// <returns>True if can create figure from given points, else false.</returns>
        bool IsCanCreateFigure(params Point[] vertices);
    }
}