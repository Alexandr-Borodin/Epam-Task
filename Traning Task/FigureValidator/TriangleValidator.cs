using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureValidator
{
    public class TriangleValidator : IFigureValidator
    {
        private PolygonValidator _polygonValidator;

        public TriangleValidator()
        {
            _polygonValidator = new PolygonValidator();
        }

        public bool IsCanCreateFigure(params Point[] vertices)
        {
            if (!WillItMakeATriangle(vertices))
                return false;

            return true;
        }

        private bool WillItMakeATriangle(params Point[] vertices)
        {
            if (!_polygonValidator.IsCanCreateFigure(vertices))
                return false;

            bool result = !(vertices.Length > 3) && !PointsChecker.IsThreePointsLiedOnSameStraight(vertices);

            return result;
        }
    }
}