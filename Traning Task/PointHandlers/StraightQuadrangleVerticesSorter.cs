using System.Drawing;
using System.Linq;

namespace PointHandlers
{
    /// <summary>
    /// Describes straight quadrangle vertices sorter.
    /// </summary>
    public static class StraightQuadrangleVerticesSorter
    {
        /// <summary>
        /// Clock wise sorts vertices in straight quadrangle.
        /// </summary>
        /// <param name="vertices">Vertices of straight quadrangle.</param>
        public static void ClockWiseSort(params Point[] vertices)
        {
            int[] arrayOfX = new int[] { vertices[0].X, vertices[1].X, vertices[2].X, vertices[3].X };
            int[] arrayOfY = new int[] { vertices[0].Y, vertices[1].Y, vertices[2].Y, vertices[3].Y };

            //top-left
            vertices[0].X = arrayOfX.Min();
            vertices[0].Y = arrayOfY.Max();

            //top-right
            vertices[1].X = arrayOfX.Max();
            vertices[1].Y = arrayOfY.Max();

            //bottom-right
            vertices[2].X = arrayOfX.Max();
            vertices[2].Y = arrayOfY.Min();

            //bottom-left
            vertices[3].X = arrayOfX.Min();
            vertices[3].Y = arrayOfY.Min();
        }
    }
}
