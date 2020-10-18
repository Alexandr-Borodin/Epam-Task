using System;
using System.Drawing;

namespace FigureValidator
{
    /// <summary>
    /// Describes point checker.
    /// </summary>
    public static class  PointsChecker
    {
        /// <summary>
        /// Checks if three points lied on same straight.
        /// </summary>
        /// <param name="points">Points for check.</param>
        /// <returns>True if points lied on same straight, otherwise false.</returns>
        public static bool IsThreePointsLiedOnSameStraight(params Point[] points)
        {
            if(points.Length < 3)
                throw new Exception("Need more points to check.");

            bool result = (points[2].X * (points[1].Y - points[0].Y) - points[2].Y * (points[1].X - points[0].X) ==
                           points[0].X * points[1].Y - points[1].X * points[0].Y);

            return result;
        }
    }
}
