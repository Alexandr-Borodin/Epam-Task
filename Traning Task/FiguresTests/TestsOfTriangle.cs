using System;
using System.Drawing;
using FigureBuildExceptions;
using FigureGenerators;
using Figures;
using FigureValidator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FiguresTests
{
    [TestClass]
    public class TestsOfTriangle
    {

        [TestMethod]
        public void Triangle_IsValid_DontGivenPoints_ShouldReturnFalse()
        {
            bool result = Triangle.IsValid();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Triangle_IsValid_GivenLessNumberOfPointThenNeed_ShouldPushException()
        {
            Random random = new Random();

            Point[] points = new Point[random.Next(1, 2)];

            for (int index = 0; index < points.Length; ++index)
            {
                points[index] = new Point(random.Next(-30, 30), random.Next(-30, 30));
            }

            bool result = Triangle.IsValid(points);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Triangle_IsValid_GivenThreePointsOnTheSameStraight_ShouldReturnFalse()
        {
            Random random = new Random();

            Point[] points = new Point[3];

            int elongationX = random.Next(-30, 30);
            int elongationY = random.Next(-30, 30);

            points[0] = new Point(random.Next(-30, 30), random.Next(-30, 30));

            for (int index = 1; index < points.Length; index++) 
            { 
                points[index] = new Point(points[index - 1].X + elongationX, points[index - 1].Y + elongationY);
            }

            bool result = Triangle.IsValid(points);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Triangle_IsValid_GivenThreeSamePoints_ShouldReturnFalse()
        {
            Random random = new Random();

            Point point1 = new Point(random.Next(-30, 30), random.Next(-30, 30));
            Point point2 = new Point(point1.X, point1.Y);
            Point point3 = new Point(point1.X, point1.Y);

            bool result = Triangle.IsValid(point1, point2, point3);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Triangle_IsValid_GivenThreeDifferentPoints_ShouldReturnTrue()
        {
            Random random = new Random();

            Point[] points = new Point[3];

            do
            {

                for (int index = 0; index < points.Length; ++index)
                {
                    points[index] = new Point(random.Next(-30, 30), random.Next(-30, 30));
                }

            } while (PointsChecker.IsThreePointsLiedOnSameStraight(points));

            bool result = Triangle.IsValid(points);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(FigureBuildException))]
        public void Triangle_Constructor_DontGivenPoints_ShouldPushException()
        {
            Triangle triangle = new Triangle(); 
        }

        [TestMethod]
        [ExpectedException(typeof(FigureBuildException))]
        public void Triangle_Constructor_GivenLessNumberOfPointThenNeed_ShouldPushException()
        {
            Random random = new Random();

            Point[] points = new Point[random.Next(1, 2)];

            for (int index = 0; index < points.Length; ++index)
            {
                points[index] = new Point(random.Next(-30, 30), random.Next(-30, 30));
            }

            Triangle triangle = new Triangle(points);
        }

        [TestMethod]
        [ExpectedException(typeof(FigureBuildException))]
        public void Triangle_Constructor_GivenThreeSamePoints_ShouldPushException()
        {
            Random random = new Random();

            Point point1 = new Point(random.Next(-30, 30), random.Next(-30, 30));
            Point point2 = new Point(point1.X, point1.Y);
            Point point3 = new Point(point1.X, point1.Y);

            Triangle triangle = new Triangle(point1, point2, point3); 
        }

        [TestMethod]
        [ExpectedException(typeof(FigureBuildException))]
        public void Triangle_Constructor_GivenThreePointsOnTheSameStraight_ShouldReturnFalse()
        {
            Random random = new Random();

            Point[] points = new Point[3];

            int elongationX = random.Next(-30, 30);
            int elongationY = random.Next(-30, 30);

            points[0] = new Point(random.Next(-30, 30), random.Next(-30, 30));

            for (int index = 1; index < points.Length; index++)
            {
                points[index] = new Point(points[index - 1].X + elongationX, points[index - 1].Y + elongationY);
            }

            Triangle triangle = new Triangle(points);
        }

        [TestMethod]
        public void Triangle_Constructor_GivenThreeDifferentPoints_ShouldSuccessfulCreateATriangle()
        {
            Random random = new Random();

            Point[] points = new Point[3];

            do
            {

                for (int index = 0; index < points.Length; ++index)
                {
                    points[index] = new Point(random.Next(-30, 30), random.Next(-30, 30));
                }

            } while (PointsChecker.IsThreePointsLiedOnSameStraight(points));

            Triangle triangle = new Triangle(points);

            Assert.AreNotEqual(null, triangle);
        }

        [TestMethod]
        public void Triangle_Perimeter_SuccessfulCreateATriangle_ShouldReturnActualPerimeterOfTriangle()
        {
            Triangle triangle = TriangleGenerator.GetRandomTriangle();

            double expectedPerimeter = Math.Sqrt(Math.Pow(triangle.Vertices[0].X - triangle.Vertices[1].X, 2) 
                                               + Math.Pow(triangle.Vertices[0].Y - triangle.Vertices[1].Y, 2)) +
                                     Math.Sqrt(Math.Pow(triangle.Vertices[1].X - triangle.Vertices[2].X, 2)
                                               + Math.Pow(triangle.Vertices[1].Y - triangle.Vertices[2].Y, 2)) +
                                     Math.Sqrt(Math.Pow(triangle.Vertices[0].X - triangle.Vertices[2].X, 2)
                                               + Math.Pow(triangle.Vertices[0].Y - triangle.Vertices[2].Y, 2));
            double actualPerimeter = triangle.Perimeter;

            Assert.AreEqual(expectedPerimeter, actualPerimeter);
        }

        [TestMethod]
        public void Triangle_SemiPerimeter_SuccessfulCreateATriangle_ShouldReturnActualSemiPerimeterOfTriangle()
        {
            Triangle triangle = TriangleGenerator.GetRandomTriangle();

            double expectedSemiPerimeter = triangle.Perimeter / 2;
            double actualSemiPerimeter = triangle.SemiPerimeter;

            Assert.AreEqual(expectedSemiPerimeter, actualSemiPerimeter);
        }

        [TestMethod]
        public void TrTriangle_Area_SuccessfulCreateATriangle_ShouldReturnActualAreaOfTriangle()
        {
            Triangle triangle = TriangleGenerator.GetRandomTriangle();

            double expectedArea = Math.Sqrt(triangle.SemiPerimeter *
                                            (triangle.SemiPerimeter - triangle.Sides[0]) *
                                            (triangle.SemiPerimeter - triangle.Sides[1]) *
                                            (triangle.SemiPerimeter - triangle.Sides[2]));
            double actualArea = triangle.Area;

            Assert.AreEqual(expectedArea, actualArea);
        }
    }
}
