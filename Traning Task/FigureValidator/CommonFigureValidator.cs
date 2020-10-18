using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureValidator
{
    public class CommonFigureValidator : IFigureValidator
    {
        public bool IsCanCreateFigure(params Point[] vertices)
        {
            if (vertices.Length < 2)
                return false;

            return true;
        }
    }
}