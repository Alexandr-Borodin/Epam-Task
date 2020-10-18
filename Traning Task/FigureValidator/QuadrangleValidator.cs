using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureValidator
{
    /// <summary>
    /// Describes quadrangle validator.
    /// </summary>
    public class QuadrangleValidator : IFigureValidator
    {
        /// <summary>
        /// Polygon validator.
        /// </summary>
        private PolygonValidator _polygonValidator;

        /// <summary>
        /// Constructor of quadrangle validator.
        /// </summary>
        public QuadrangleValidator()
        {
            _polygonValidator = new PolygonValidator();
        }

        /// <summary>
        /// Checks if can create a quadrangle from given points.
        /// </summary>
        /// <param name="vertices">Expected vertices of quadrangle.</param>
        /// <returns>True if can create a quadrangle from given points, otherwise false.</returns>
        public bool IsCanCreateFigure(params Point[] vertices)
        {
            if (!_polygonValidator.IsCanCreateFigure(vertices) || vertices.Length != 4)
                return false;

            return true;
        }
    }
}
