using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureValidator
{
    public static class  PointsChecker
    {
        public static bool IsThreePointsLiedOnSameStraight(params Point[] points)
        {
            bool result = (points[2].X * (points[1].Y - points[0].Y) - points[2].Y * (points[1].X - points[0].X) ==
                           points[0].X * points[1].Y - points[1].X * points[0].Y);

            return result;
        }
    }
}
