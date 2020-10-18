using System;
using System.Drawing;
using FigureBuildExceptions;
using FigureGenerators;
using Figures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FiguresTests
{
    [TestClass]
    public class TestsOfSquare
    {
        [TestMethod]
        public void Square_IsValid_DontGivenPoints_ShouldReturnFalse()
        {
            bool result = Square.IsValid();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Square_IsValid_GivenLessNumberOfPointThenNeed_ShouldReturnFalse()
        {
            Random random = new Random();

            Point[] points = new Point[random.Next(1, 3)];

            for (int index = 0; index < points.Length; ++index)
            {
                points[index] = new Point(random.Next(-30, 30), random.Next(-30, 30));
            }

            bool result = Square.IsValid(points);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Square_IsValid_GivenRightPointsToCreateASquare_ShouldReturnTrue()
        {
            Random random = new Random();

            Point point1 = new Point(random.Next(-10, 10), random.Next(-10, 10));

            int elongation = random.Next(2, 20);

            Point point2 = new Point(point1.X - elongation, point1.Y);
            Point point3 = new Point(point2.X, point2.Y + elongation);
            Point point4 = new Point(point3.X + elongation, point3.Y);

            bool result = Square.IsValid(point1, point2, point3, point4);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Square_IsValid_GivenWrongPointsToCreateASquare_ShouldReturnFalse()
        {
            Random random = new Random();

            Point point1 = new Point(random.Next(-10, 10), random.Next(-10, 10));

            int elongation = random.Next(2, 20);

            Point point2 = new Point(point1.X - elongation + random.Next(-50, 50), point1.Y + random.Next(-50, 50));
            Point point3 = new Point(point2.X + random.Next(-50, 50), point2.Y + elongation + random.Next(-50, 50));
            Point point4 = new Point(point3.X + elongation + random.Next(-50, 50), point3.Y + random.Next(-50, 50));

            bool result = Square.IsValid(point1, point2, point3, point4);

            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(FigureBuildException))]
        public void Square_Constructor_CallsEmptyConstructor_ShouldPushException()
        {
            Square square = new Square();
        }

        [TestMethod]
        [ExpectedException(typeof(FigureBuildException))]
        public void Square_Constructor_GivenLessNumberOfPointThenNeed_ShouldPushException()
        {
            Random random = new Random();

            Point[] points = new Point[random.Next(1, 3)];

            for(int index = 0; index < points.Length; ++index)
            {
                points[index] = new Point(random.Next(-30, 30), random.Next(-30, 30));
            }

            Square square = new Square(points);
        }

        [TestMethod]
        [ExpectedException(typeof(FigureBuildException))]
        public void Square_Constructor_GivenWrongPointsToCreateASquare_ShouldPushExeption()
        {
            Random random = new Random();

            Point point1 = new Point(random.Next(-10, 10), random.Next(-10, 10));

            int elongation = random.Next(2, 20);

            Point point2 = new Point(point1.X - elongation + random.Next(1, 50), point1.Y + random.Next(1, 50));
            Point point3 = new Point(point2.X + random.Next(1, 50), point2.Y + elongation + random.Next(1, 50));
            Point point4 = new Point(point3.X + elongation + random.Next(1, 50), point3.Y + random.Next(1, 50));

            Square square = new Square(point1, point2, point3, point4);
        }

        [TestMethod]
        public void Square_Constructor_GivenRightPointsToCreateASquare_SuccesfulCreateASquare()
        {
            Random random = new Random();

            Point point1 = new Point(random.Next(-10, 10), random.Next(-10, 10));

            int elongation = random.Next(2, 20);

            Point point2 = new Point(point1.X - elongation, point1.Y);
            Point point3 = new Point(point2.X, point2.Y + elongation);
            Point point4 = new Point(point3.X + elongation, point3.Y);

            Square square = new Square(point1, point2, point3, point4);
        }

        [TestMethod]
        public void Square_Perimeter_SuccessfulCreateASquare_ShouldReturnActualPerimeterOfSquare()
        {
            Square square = SquareGenerator.GetRandomSquare();

            Point pointA = square.Vertices[0];
            Point pointB = square.Vertices[1];

            double expectedPerimeter = Math.Sqrt(Math.Pow(pointA.X - pointB.X, 2) + Math.Pow(pointA.Y - pointB.Y, 2)) * 4;
            double actualPerimeter = square.Perimeter;

            Assert.AreEqual(expectedPerimeter, actualPerimeter);
        }

        [TestMethod]
        public void Square_Area_SuccessfulCreateASquare_ShouldReturnActualAreaOfSquare()
        {
            Square square = SquareGenerator.GetRandomSquare();

            Point pointA = square.Vertices[0];
            Point pointB = square.Vertices[1];

            double expectedArea = Math.Pow(Math.Sqrt(Math.Pow(pointA.X - pointB.X, 2) + Math.Pow(pointA.Y - pointB.Y, 2)), 2);
            double actualArea = square.Area;

            Assert.AreEqual(expectedArea, actualArea);
        }
    }
}