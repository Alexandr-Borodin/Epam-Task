using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureValidator
{
    public class CircleValidator : IFigureValidator
    {
        private CommonFigureValidator _figureValidator;

        public CircleValidator()
        {
            _figureValidator = new CommonFigureValidator();
        }

        public bool IsCanCreateFigure(params Point[] vertices)
        {
            if (!WillItMakeACircle(vertices))
                return false;

            return true;
        }

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