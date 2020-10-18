using System;
using System.Collections.Generic;
using FigureGenerators;
using Figures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskPerformers;

namespace TaskPerformersTests
{
    [TestClass]
    public class FigureFinderTests
    {
        [TestMethod]
        public void FiguresFinder_GetLargestAreaFigure_GivenSomeFigures_ShouldReturnFigureWithLargestArea()
        {
            Square square = SquareGenerator.GetRandomSquare();
            Rhombus rhombus = RhombusGenerator.GetRandomRhombus();
            Circle circle = CircleGenerator.GetRandomCircle();

            FigureList figureList = new FigureList(square, rhombus, circle);

            Figure expectedFigure = null;
            double maxArea = 0f;

            foreach (Figure figure in figureList)
            {
                if (figure.Area > maxArea)
                {
                    maxArea = figure.Area;
                    expectedFigure = figure;
                }
            }

            Figure actualFigure = FiguresFinder.GetLargestAreaFigure(figureList);

            Assert.AreSame(expectedFigure, actualFigure);
        }

        delegate Figure FigureGenerators();


        [TestMethod]
        public void
            FiguresFinder_GetLargestAveragePerimeterTypeFigure_GivenTwoFiguresByEachType_ShouldReturnTypeOfFigureWithLargestPerimeter()
        {
            Random random = new Random();

            FigureGenerators[] generators = new FigureGenerators[]
            {
                SquareGenerator.GetRandomSquare,
                RectangleGenerator.GetRandomRectangle,
                CircleGenerator.GetRandomCircle,
                RhombusGenerator.GetRandomRhombus,
                TriangleGenerator.GetRandomTriangle,
            };
            
            Figure[] figure = new Figure[10];
            for (int index = 0; index < figure.Length / 2; index++)
            {
                figure[index] = generators[index].Invoke();
            }

            for (int index = figure.Length / 2; index < figure.Length; ++index)
            {
                figure[index] = generators[index - figure.Length / 2].Invoke();
            }

            Dictionary<Type, double> dictionary = new Dictionary<Type, double>()
            {
                {typeof(Square), 0},
                {typeof(Rectangle), 0},
                {typeof(Circle), 0},
                {typeof(Rhombus), 0},
                {typeof(Triangle), 0}
            };
            // для квадратов
            dictionary[typeof(Square)] = calculateAveragePerimeterByOneTypeOfFigure(figure, typeof(Square));
            // для кургов
            dictionary[typeof(Circle)] = calculateAveragePerimeterByOneTypeOfFigure(figure, typeof(Circle));
            // для прямоугольников
            dictionary[typeof(Rectangle)] = calculateAveragePerimeterByOneTypeOfFigure(figure, typeof(Rectangle));
            // для ромбов
            dictionary[typeof(Rhombus)] = calculateAveragePerimeterByOneTypeOfFigure(figure, typeof(Rhombus));
            // для треугольников
            dictionary[typeof(Triangle)] = calculateAveragePerimeterByOneTypeOfFigure(figure, typeof(Triangle));

            double largeArea = 0f;
            Type largeType = null;

            foreach (var element in dictionary)
            {
                if (element.Value > largeArea)
                {
                    largeArea = element.Value;
                    largeType = element.Key;
                }
            }

            FigureList figures = new FigureList(figure);
            Type actual = FiguresFinder.GetLargestAveragePerimeterTypeFigure(figures);

            Assert.AreEqual(largeType, actual);

        }

        private double calculateAveragePerimeterByOneTypeOfFigure(Figure[] figures, Type type)
        {
            double result = 0f;
            int count = 0;

            for (int index = 0; index < figures.Length; index++)
            {
                if (figures[index].GetType() == type)
                {
                    result += figures[index].Perimeter;
                    ++count;
                }
            }

            return result / count;
        }
    }
}