using System;
using FigureGenerators;
using Figures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskPerformers;

namespace TaskPerformersTests
{
    [TestClass]
    public class FigureValuesCalculatorTests
    {
        [TestMethod]
        public void FigureValuesCalculator_GetAllFiguresPerimeter_GivenSomeFigures_ShouldReturnFiguresActualPerimeter()
        {
            Square square = SquareGenerator.GetRandomSquare();
            Circle circle = CircleGenerator.GetRandomCircle();
            Rhombus rhombus = RhombusGenerator.GetRandomRhombus();

            FigureList figureList = new FigureList(square, circle, rhombus);

            double expectedResult = square.Perimeter + circle.Perimeter + rhombus.Perimeter;
            double actualResult = FigureValuesCalculator.GetAllFiguresPerimeter(figureList);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void
            FigureValuesCalculator_GetAllFiguresAveragePerimeter_GivenSomeFigures_ShouldReturnFiguresActualAveragePerimeter()
        {
            Rhombus rhombus = RhombusGenerator.GetRandomRhombus();
            Rectangle rectangle = RectangleGenerator.GetRandomRectangle();
            Circle circle = CircleGenerator.GetRandomCircle();

            FigureList figureList = new FigureList(rectangle, circle, rhombus);

            double expectedResult = (rectangle.Perimeter + circle.Perimeter + rhombus.Perimeter) / 3;
            double actualResult = FigureValuesCalculator.GetAllFiguresAveragePerimeter(figureList);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void FigureValuesCalculator_GetAllFiguresArea_GivenSomeFigures_ShouldReturnFiguresActualArea()
        {
            Square square = SquareGenerator.GetRandomSquare();
            Circle circle = CircleGenerator.GetRandomCircle();
            Rhombus rhombus = RhombusGenerator.GetRandomRhombus();
            Rectangle rectangle = RectangleGenerator.GetRandomRectangle();

            FigureList figureList = new FigureList(square, circle, rhombus, rectangle);

            double expectedResult = square.Area + circle.Area + rhombus.Area + rectangle.Area;
            double actualResult = FigureValuesCalculator.GetAllFiguresArea(figureList);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void
            FigureValuesCalculator_GetAllFiguresAverageArea_GivenSomeFigures_ShouldReturnFiguresActualAverageArea()
        {
            Square square1 = SquareGenerator.GetRandomSquare();
            Circle circle = CircleGenerator.GetRandomCircle();
            Rhombus rhombus = RhombusGenerator.GetRandomRhombus();
            Rectangle rectangle = RectangleGenerator.GetRandomRectangle();
            Square square2 = SquareGenerator.GetRandomSquare();

            FigureList figureList = new FigureList(square1, circle, rhombus, rectangle, square2);

            double expectedResult = (square1.Area + circle.Area + rhombus.Area + rectangle.Area + square2.Area) / 5;
            double actualResult = FigureValuesCalculator.GetAllFiguresAverageArea(figureList);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
