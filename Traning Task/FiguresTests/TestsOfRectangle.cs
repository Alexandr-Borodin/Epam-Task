using System;
using System.Drawing;
using FigureBuildExceptions;
using FigureGenerators;
using Figures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rectangle = Figures.Rectangle;

namespace FiguresTests
{
    [TestClass]
    public class TestsOfRectangle
    {
        [TestMethod]
        public void Rectangle_IsValid_DontGivenPoints_ShouldReturnFalse()
        {
            bool result = Rectangle.IsValid();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Rectangle_IsValid_GivenLessNumberOfPointThenNeed_ShouldReturnFalse()
        {
            Random random = new Random();

            Point[] points = new Point[random.Next(1, 3)];

            for (int index = 0; index < points.Length; ++index)
            {
                points[index] = new Point(random.Next(-30, 30), random.Next(-30, 30));
            }

            bool result = Rectangle.IsValid(points);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Rectangle_IsValid_GivenRightPointsToCreateASquare_ShouldReturnTrue()
        {
            Random random = new Random();

            int elongationX = random.Next(1, 20);
            int elongationY = random.Next(1, 20);

            Point point1 = new Point(random.Next(-10, 10), random.Next(-10, 10));

            Point point2 = new Point(point1.X - elongationX, point1.Y);
            Point point3 = new Point(point2.X, point2.Y + elongationY);
            Point point4 = new Point(point3.X + elongationX, point3.Y);

            bool result = Rectangle.IsValid(point1, point2, point3, point4);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Rectangle_IsValid_GivenWrongPointsToCreateASquare_ShouldReturnFalse()
        {
            Random random = new Random();

            // foothold point

            int elongationX = random.Next(1, 20);
            int elongationY = random.Next(1, 20);

            Point point1 = new Point(random.Next(-10, 10), random.Next(-10, 10));

            Point point2 = new Point(point1.X - elongationX + random.Next(1, 40), point1.Y + random.Next(1, 40));
            Point point3 = new Point(point2.X + random.Next(1, 40), point2.Y + elongationY + random.Next(1, 40));
            Point point4 = new Point(point3.X + elongationX + random.Next(1, 40), point3.Y + random.Next(1, 40));

            bool result = Rectangle.IsValid(point1, point2, point3, point4);

            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(FigureBuildException))]
        public void Rectangle_Constructor_CallsEmptyConstructor_ShouldPushException()
        {
            Rectangle rectangle = new Rectangle();
        }

        [TestMethod]
        [ExpectedException(typeof(FigureBuildException))]
        public void Rectangle_Constructor_GivenLessNumberOfPointThenNeed_ShouldPushException()
        {
            Random random = new Random();

            Point[] points = new Point[random.Next(1, 3)];

            for (int index = 0; index < points.Length; ++index)
            {
                points[index] = new Point(random.Next(-30, 30), random.Next(-30, 30));
            }

            Rectangle rectangle = new Rectangle(points);
        }

        [TestMethod]
        [ExpectedException(typeof(FigureBuildException))]
        public void Rectangle_Constructor_GivenWrongPointsToCreateARectangle_ShouldPushException()
        {
            Random random = new Random();

            // foothold point

            int elongationX = random.Next(1, 20);
            int elongationY = random.Next(1, 20);

            Point point1 = new Point(random.Next(-10, 10), random.Next(-10, 10));

            Point point2 = new Point(point1.X - elongationX + random.Next(1, 40), point1.Y + random.Next(1, 40));
            Point point3 = new Point(point2.X + random.Next(1, 40), point2.Y + elongationY + random.Next(1, 40));
            Point point4 = new Point(point3.X + elongationX + random.Next(1, 40), point3.Y + random.Next(1, 40));

            Rectangle rectangle = new Rectangle(point1, point2, point3, point4);
        }

        [TestMethod]
        public void Rectangle_Constructor_GivenRightPointsToCreateASquare_SuccessfulCreateARectangle()
        {
            Random random = new Random();

            int elongationX = random.Next(1, 20);
            int elongationY = random.Next(1, 20);

            Point point1 = new Point(random.Next(-10, 10), random.Next(-10, 10));

            Point point2 = new Point(point1.X - elongationX, point1.Y);
            Point point3 = new Point(point2.X, point2.Y + elongationY);
            Point point4 = new Point(point3.X + elongationX, point3.Y);

            Rectangle rectangle = new Rectangle(point1, point2, point3, point4);

            Assert.AreNotEqual(null, rectangle);
        }

        [TestMethod]
        public void Rectangle_Perimeter_SuccessfulCreateARectangle_ShouldReturnActualPerimeterOfRectangle()
        {
            Rectangle rectangle = RectangleGenerator.GetRandomRectangle();

            double expectedPerimeter = 2 * (rectangle.Sides[1] + rectangle.Sides[0]);
            double actualPerimeter = rectangle.Perimeter;

            Assert.AreEqual(Math.Round(expectedPerimeter, 3), Math.Round(actualPerimeter, 3));
        }

        [TestMethod]
        public void Rectangle_Area_SuccessfulCreateARectangle_ShouldReturnActualAreaOfRectangle()
        {
            Rectangle rectangle = RectangleGenerator.GetRandomRectangle();

            double expectedArea = rectangle.Sides[0] * rectangle.Sides[1];
            double actualArea = rectangle.Area;

            Assert.AreEqual(expectedArea, actualArea);
        }
    }
}
