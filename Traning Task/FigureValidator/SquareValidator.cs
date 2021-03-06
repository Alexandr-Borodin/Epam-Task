﻿using System.Drawing;
using ComparatorsByPoints;
using PointHandlers;

namespace FigureValidator
{
    /// <summary>
    /// Describes square validator.
    /// </summary>
    public class SquareValidator : IFigureValidator
    {
        /// <summary>
        /// Quadrangle validator.
        /// </summary>
        private QuadrangleValidator _quadrangleValidator;

        /// <summary>
        /// Constructor of square validator.
        /// </summary>
        public SquareValidator()
        {
            _quadrangleValidator = new QuadrangleValidator();
        }

        /// <summary>
        /// Checks if can create figure from given points.
        /// </summary>
        /// <param name="vertices">Expected vertices of figure.</param>
        /// <returns>True if can create a figure from given points, otherwise false.</returns>
        public bool IsCanCreateFigure(params Point[] vertices)
        {
            if (!WillItMakeASquare(vertices))
                return false;

            return true;
        }

        /// <summary>
        /// Checks if can create square from given points.
        /// </summary>
        /// <param name="vertices">Expected vertices of square.</param>
        /// <returns>True if can create a square from given points, otherwise false.</returns>
        private bool WillItMakeASquare(params Point[] vertices)
        {
            if (!_quadrangleValidator.IsCanCreateFigure(vertices))
                return false;

            Point[] reserveVertices = new Point[vertices.Length];

            for (int index = 0; index < vertices.Length; index++)
            {
                reserveVertices[index] = new Point(vertices[index].X, vertices[index].Y);
            }

            for (int index = 0; index < vertices.Length - 1; index++)
            {
                if (vertices[index].X == vertices[index + 1].X || vertices[index].Y == vertices[index + 1].Y)
                {
                    StraightQuadrangleVerticesSorter.ClockWiseSort(vertices);
                }
            }

            if (!IsItSameVertices(vertices, reserveVertices))
            {
                for (int index = 0; index < vertices.Length; index++)
                {
                    vertices[index] = new Point(reserveVertices[index].X, reserveVertices[index].Y);
                }
                return false;
            }

            bool result = PolygonComparator.AreTheSidesEqual(vertices) && QuadrangleComparator.AreTheDiagonalsEqual(vertices);

            return result;
        }

        /// <summary>
        /// Checks if two points array contains same points.
        /// </summary>
        /// <param name="vertices1">First point array.</param>
        /// <param name="vertices2">Second point array.</param>
        /// <returns>True if two points array contains same points, otherwise false.</returns>
        private bool IsItSameVertices(Point[] vertices1, Point[] vertices2)
        {
            bool result = true;

            for (int index1 = 0; index1 < vertices1.Length && result; index1++)
            {
                result = false;

                for (int index2 = 0; index2 < vertices2.Length; index2++)
                {
                    if (vertices1[index1].X == vertices2[index2].X && vertices1[index1].Y == vertices2[index2].Y)
                        result = true;
                }
            }

            return result;
        }
    }
}
