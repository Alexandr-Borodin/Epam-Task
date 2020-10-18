using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureValidator
{
    public class QuadrangleValidator : IFigureValidator
    {
        private PolygonValidator _polygonValidator;

        public QuadrangleValidator()
        {
            _polygonValidator = new PolygonValidator();
        }

        public bool IsCanCreateFigure(params Point[] vertices)
        {
            if (!_polygonValidator.IsCanCreateFigure(vertices) || vertices.Length != 4)
                return false;

            return true;
        }
    }
}
