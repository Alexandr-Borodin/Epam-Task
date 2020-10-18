using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PointHandlers;

namespace FigureValidator
{
    public class PolygonValidator : IFigureValidator
    {
        public bool IsCanCreateFigure(params Point[] vertices)
        {
            if (vertices.Length < 3) return false;

            PointSorter.CounterClockWiseSort(vertices);

            return true;
        }
    }
}
