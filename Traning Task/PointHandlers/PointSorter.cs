using System;
using System.Drawing;
namespace PointHandlers
{
    /// <summary>
    /// Describes point sorter.
    /// </summary>
    public static class PointSorter
    {
        /// <summary>
        /// Does counter-clock wise sort of given points.
        /// </summary>
        /// <param name="points">Expected points of figure.</param>
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
                points[index].X += Math.Abs(maxX) + 1;
                points[index].Y += Math.Abs(maxY) + 1;
            }

            Array.Sort(points, Compare);

            for (int index = 0; index < points.Length; index++)
            {
                points[index].X -= Math.Abs(maxX) + 1;
                points[index].Y -= Math.Abs(maxY) + 1;
            }
        }

        /// <summary>
        /// Compare method.
        /// </summary>
        /// <param name="point1">First point to compare.</param>
        /// <param name="point2">Second point to compare</param>
        /// <returns>Integer result of compare of tangent value of two points.</returns>
        private static int Compare(Point point1, Point point2)
        {
            return Math.Atan2(-point1.Y, -point1.X).CompareTo(Math.Atan2(-point2.Y, -point2.X));
        }
    }
}
