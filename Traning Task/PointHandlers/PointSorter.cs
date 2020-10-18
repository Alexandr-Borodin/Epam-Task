using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointHandlers
{
    public static class PointSorter
    {
        public static void CounterClockWiseSort(params Point[] points)
        {
            int maxX = 0;
            int maxY = 0;

            for (int index = 0; index < points.Length; ++index)
            {
                if (maxX > points[index].X)
                    maxX = points[index].X;

                if (maxY > points[index].Y)
                    maxY = points[index].Y;
            }

            for (int index = 0; index < points.Length; index++)
            {
                //if(maxX != 0)
                    points[index].X += Math.Abs(maxX) + 1;

                //if(maxY != 0)
                    points[index].Y += Math.Abs(maxY) + 1;
            }

            Array.Sort(points, Compare);

            for (int index = 0; index < points.Length; index++)
            {
                //if (maxX != 0)
                    points[index].X -= Math.Abs(maxX) + 1;
                //if (maxY != 0)
                    points[index].Y -= Math.Abs(maxY) + 1;
            }
        }

        private static int Compare(Point point1, Point point2)
        {
            /*double t1 = Math.Atan2(point1.Y, point1.X);
            double t2 = Math.Atan2(point2.Y, point2.X);

            if (t1 < 0)
                t1 += 2 * Math.PI;
            if (t2 < 0)
                t2 += 2 * Math.PI;

            return t1.CompareTo(t2);*/

            return Math.Atan2(-point1.Y, -point1.X).CompareTo(Math.Atan2(-point2.Y, -point2.X));
        }
    }
}
