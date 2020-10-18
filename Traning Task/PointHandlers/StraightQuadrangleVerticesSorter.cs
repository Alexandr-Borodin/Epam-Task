using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointHandlers
{
    public static class StraightQuadrangleVerticesSorter
    {
        public static void ClockWiseSort(params Point[] vertices)
        {
            int[] arrayOfX = new int[4] { vertices[0].X, vertices[1].X, vertices[2].X, vertices[3].X };
            int[] arrayOfY = new int[4] { vertices[0].Y, vertices[1].Y, vertices[2].Y, vertices[3].Y };

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
