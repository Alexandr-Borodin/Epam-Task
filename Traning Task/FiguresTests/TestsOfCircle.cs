using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FigureBuildExceptions;
using System.Drawing;
using Figures;

namespace FiguresTests
{
    [TestClass]
    public class TestsOfCircle
    {
        [TestMethod]
        public void Circle_IsValid_DontGivenPoints_ShouldReturnFalse()
        {
            bool result = Circle.IsValid();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Circle_IsValid_GivenOnePoint_ShouldReturnFalse()
        {
            Random random = new Random();

            Point point = new Point(random.Next(-30, 30), random.Next(-30, 30));

            bool result = Circle.IsValid(point);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Circle_IsValid_GivenTwoSamePoints_ShouldReturnFalse()
        {
            Random random = new Random();

            Point point1 = new Point(random.Next(-30, 30), random.Next(-30, 30));
            Point point2 = new Point(point1.X, point1.Y);

            bool result = Circle.IsValid(point1, point2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Circle_IsValid_GivenTwoDifferentPoints_ShouldReturnTrue()
        {
            Random random = new Random();

            Point point1 = new Point(random.Next(-30, 30), random.Next(-30, 30));
            Point point2 = new Point(point1.X + random.Next(1, 10), point1.Y + random.Next(-10, -1));

            bool result = Circle.IsValid(point1, point2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(FigureBuildException))]
        public void Circle_Constructor_CallsEmptyConstructor_ShouldPushException()
        {
            Circle circle = new Circle();
        }


        [TestMethod]
        [ExpectedException(typeof(FigureBuildException))]
        public void Circle_Constructor_GivenOnePoint_ShouldPushException()
        {
            Random random = new Random();

            Point point = new Point(random.Next(-30, 30), random.Next(-30, 30));

            Circle circle = new Circle(point);
        }

        [TestMethod]
        [ExpectedException(typeof(FigureBuildException))]
        public void Circle_Construcror_GivenTwoSamePoints_ShouldPushException()
        {
            Random random = new Random();

            Point point1 = new Point(random.Next(-30, 30), random.Next(-30, 30));
            Point point2 = new Point(point1.X, point1.Y);

            Circle circle = new Circle(point1, point2);
        }

        [TestMethod]
        public void Circle_Constructor_GivenTwoDifferentPoints_ShouldSuccessfulCreateACircle()
        {
            Random random = new Random();

            Point point1 = new Point(random.Next(-30, 30), random.Next(-30, 30));
            Point point2 = new Point(point1.X + random.Next(1, 10), point1.Y + random.Next(-10, -1));

            Circle circle = new Circle(point1, point2);

            Assert.AreNotEqual(null, circle);
        }

        [TestMethod]
        public void Circle_Radius_GivenTwoDifferentPoints_SuccessfulCreateOfCircle_ShouldReturnDistanceBettweenThisPoints()
        {
            Random random = new Random();

            Point point1 = new Point(random.Next(-30, 30), random.Next(-30, 30));
            Point point2 = new Point(point1.X + random.Next(1, 10), point1.Y + random.Next(-10, -1));

            Circle circle = new Circle(point1, point2);

            double expectedValue = Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2));
            double actualValue = circle.Radius;

            Assert.AreEqual(expectedValue, actualValue);
        }


        [TestMethod]
        public void Circle_Perimetr_SuccessfulCreateOfCircle_ShouldReturnActualPerimeterOfCircle()
        {
            Random random = new Random();

            Point point1 = new Point(random.Next(-30, 30), random.Next(-30, 30));
            Point point2 = new Point(point1.X + random.Next(1, 10), point1.Y + random.Next(-10, -1));

            Circle circle = new Circle(point1, point2);

            double expectedValue = Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2)) *
                2 * Math.PI;
            double actualValue = circle.Perimeter;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void Circle_Area_SuccessfulCreateOfCircle_ShouldReturnActualAreaOfCircle()
        {
            Random random = new Random();

            Point point1 = new Point(random.Next(-30, 30), random.Next(-30, 30));
            Point point2 = new Point(point1.X + random.Next(1, 10), point1.Y + random.Next(-10, -1));

            Circle circle = new Circle(point1, point2);

            double expectedValue = Math.Pow(Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2)), 2) *
                Math.PI;
            double actualValue = circle.Area;

            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
