using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComparatorsByPoints;

namespace FigureValidator
{
    public class RhombusValidator : IFigureValidator
    {
        private QuadrangleValidator _quadrangleValidator;

        public RhombusValidator()
        {
            _quadrangleValidator = new QuadrangleValidator();
        }

        public bool IsCanCreateFigure(params Point[] vertices)
        {
            if (!WillItMakeARhombus(vertices))
                return false;

            return true;
        }

        private bool WillItMakeARhombus(params Point[] vertices)
        {
            if (!_quadrangleValidator.IsCanCreateFigure(vertices))
                return false;

            bool result = PolygonComparator.AreTheSidesEqual(vertices) && !QuadrangleComparator.AreTheDiagonalsEqual(vertices);

            return result;
        }
    }
}