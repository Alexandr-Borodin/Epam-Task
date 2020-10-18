using System;
using System.Drawing;
using FigureBuildExceptions;
using FigureGenerators;
using Figures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FiguresTests
{
    [TestClass]
    public class TestsOfRhombus
    {
        [TestMethod]
        public void Rhombus_IsValid_DontGivenPoints_ShouldReturnFalse()
        {
            bool result = Rhombus.IsValid();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Rhombus_IsValid_GivenLessNumberOfPointThenNeed_ShouldReturnFalse()
        {
            Random random = new Random();

            Point[] points = new Point[random.Next(1, 3)];

            for (int index = 0; index < points.Length; ++index)
            {
                points[index] = new Point(random.Next(-30, 30), random.Next(-30, 30));
            }

            bool result = Rhombus.IsValid(points);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Rhombus_IsValid_GivenRightPointsToCreateARhombus_ShouldReturnTrue()
        {
            Random random = new Random();

            // foothold point
            Point point1;

            Point point2;
            Point point3;
            Point point4;

            do
            {
                int sideX = random.Next(4, 34);
                int sideY = random.Next(4, 34);

                // foothold point
                point1 = new Point(random.Next(-10, 10), random.Next(-10, 10));

                point2 = new Point(point1.X + sideX, point1.Y + sideY);
                point3 = new Point(point2.X + sideX, point2.Y - sideY);
                point4 = new Point(point3.X - sideX, point3.Y - sideY);


            } while (Square.IsValid(point1, point2, point3, point4));

            bool result = Rhombus.IsValid(point1, point2, point3, point4);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Rhombus_IsValid_GivenWrongPointsToCreateASquare_ShouldReturnFalse()
        {
            Random random = new Random();

            int sideX = random.Next(4, 34);
            int sideY = random.Next(4, 34);

            // foothold point
            Point point1 = new Point(random.Next(-10, 10), random.Next(-10, 10));

            Point point2 = new Point(point1.X + sideX + random.Next(1, 88), point1.Y + sideY + random.Next(1, 88));
            Point point3 = new Point(point2.X + sideX + random.Next(1, 88), point2.Y - sideY + random.Next(1, 88));
            Point point4 = new Point(point3.X - sideX + random.Next(1, 88), point3.Y - sideY + random.Next(1, 88));

            bool result = Rhombus.IsValid(point1, point2, point3, point4);

            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(FigureBuildException))]
        public void Rhombus_Constructor_CallsEmptyConstructor_ShouldPushException()
        {
            Rhombus rhombus = new Rhombus();
        }

        [TestMethod]
        [ExpectedException(typeof(FigureBuildException))]
        public void Rhombus_Constructor_GivenLessNumberOfPointThenNeed_ShouldPushException()
        {
            Random random = new Random();

            Point[] points = new Point[random.Next(1, 3)];

            for (int index = 0; index < points.Length; ++index)
            {
                points[index] = new Point(random.Next(-30, 30), random.Next(-30, 30));
            }

            Rhombus rhombus = new Rhombus(points);
        }

        [TestMethod]
        [ExpectedException(typeof(FigureBuildException))]
        public void Rhombus_Constructor_GivenWrongPointsToCreateASquare_ShouldPushException()
        {
            Random random = new Random();

            int sideX = random.Next(4, 34);
            int sideY = random.Next(4, 34);

            // foothold point
            Point point1 = new Point(random.Next(-10, 10), random.Next(-10, 10));

            Point point2 = new Point(point1.X + sideX + random.Next(1, 88), point1.Y + sideY + random.Next(1, 88));
            Point point3 = new Point(point2.X + sideX + random.Next(1, 88), point2.Y - sideY + random.Next(1, 88));
            Point point4 = new Point(point3.X - sideX + random.Next(1, 88), point3.Y - sideY + random.Next(1, 88));

            Rhombus rhombus = new Rhombus(point1, point2, point3, point4);
        }

        [TestMethod]
        public void Rhombus_Constructor_GivenRightPointsToCreateASquare_SuccessfulCreateARhombus()
        {
            Random random = new Random();

            // foothold point
            Point point1;

            Point point2;
            Point point3;
            Point point4;

            do
            {
                int sideX = random.Next(4, 34);
                int sideY = random.Next(4, 34);

                // foothold point
                point1 = new Point(random.Next(-10, 10), random.Next(-10, 10));

                point2 = new Point(point1.X + sideX, point1.Y + sideY);
                point3 = new Point(point2.X + sideX, point2.Y - sideY);
                point4 = new Point(point3.X - sideX, point3.Y - sideY);


            } while (Square.IsValid(point1, point2, point3, point4));

            Rhombus rhombus = new Rhombus(point1, point2, point3, point4);
        }

        [TestMethod]
        public void Rhombus_Perimeter_SuccessfulCreateARhombus_ShouldReturnActualPerimeterOfRhombus()
        {
            Rhombus rhombus = RhombusGenerator.GetRandomRhombus();

            double expectedPerimeter = rhombus.Sides[0] + rhombus.Sides[1] + rhombus.Sides[2] + rhombus.Sides[3];
            double actualPerimeter = rhombus.Perimeter;

            Assert.AreEqual(expectedPerimeter, actualPerimeter);
        }

        [TestMethod]
        public void Rhombus_Area_SuccessfulCreateARhombus_ShouldReturnActualAreaOfRhombus()
        {
            Rhombus rhombus = RhombusGenerator.GetRandomRhombus();

            double expectedArea = 0.5 * rhombus.DiagonalA * rhombus.DiagonalB;
            double actualArea = rhombus.Area;

            Assert.AreEqual(expectedArea, actualArea);
        }
    }
}
