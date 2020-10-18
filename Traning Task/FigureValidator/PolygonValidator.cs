using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PointHandlers;

namespace FigureValidator
{
    /// <summary>
    /// Describes polygon validator.
    /// </summary>
    public class PolygonValidator : IFigureValidator
    {
        /// <summary>
        /// Checks if can create a polygon from given points.
        /// </summary>
        /// <param name="vertices">Expected vertices of polygon.</param>
        /// <returns>True if can create a polygon from given points, otherwise false.</returns>
        public bool IsCanCreateFigure(params Point[] vertices)
        {
            if (vertices.Length < 3) return false;

            PointSorter.CounterClockWiseSort(vertices);

            return true;
        }
    }
}
