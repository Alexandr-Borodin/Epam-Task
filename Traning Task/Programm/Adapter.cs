using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using FigureGenerators;
using Figures;
using TaskPerformers;
using Rectangle = Figures.Rectangle;

namespace Programm
{
    /// <summary>
    /// Adapter for user interface to work with task performers.
    /// </summary>
    public class Adapter
    {
        /// <summary>
        /// Describes delegates which stores IsValid figures methods.
        /// </summary>
        /// <param name="vertices">Figure vertices.</param>
        /// <returns>True if can create figure with given points, otherwise false.</returns>
        delegate bool figureValidator(params Point[] vertices);

        /// <summary>
        /// Describes delegates which stores figure creators methods.
        /// </summary>
        /// <param name="vertices">Figure vertices</param>
        /// <returns>Created figure.</returns>
        delegate Figure figureCreator(params Point[] vertices);

        /// <summary>
        /// Describes delegates which stores random figure generators.
        /// </summary>
        /// <returns></returns>
        delegate Figure FigureGenerators();

        /// <summary>
        /// Stores IsValid figures methods as key and figure creators methods as value.
        /// </summary>
        Dictionary<figureValidator, figureCreator> createFigureDictionary = new Dictionary<figureValidator, figureCreator>()
        {
            {Square.IsValid, FigureCreator.CreateASquare},
            {Rectangle.IsValid, FigureCreator.CreateARectangle},
            {Circle.IsValid, FigureCreator.CreateACircle},
            {Triangle.IsValid, FigureCreator.CreateAtTriangle},
            {Rhombus.IsValid, FigureCreator.CreateARhombus}
        };

        /// <summary>
        /// Stores figure generators methods.
        /// </summary>
        FigureGenerators[] figureGenerators = {
            SquareGenerator.GetRandomSquare,
            RectangleGenerator.GetRandomRectangle,
            CircleGenerator.GetRandomCircle,
            RhombusGenerator.GetRandomRhombus,
            TriangleGenerator.GetRandomTriangle,
        };

        /// <summary>
        /// Stores figures.
        /// </summary>
        private FigureList figureList = new FigureList();

        /// <summary>
        /// Gets last figure if figure list.
        /// </summary>
        public Figure GetLastFigure
        {
            get
            {
                if (figureList.Length == 0)
                    throw new Exception("Figure list has not figures.");

                return figureList[figureList.Length - 1];
            }
        }

        /// <summary>
        /// Creates figure from given points.
        /// </summary>
        /// <param name="points">Expected figure vertices.</param>
        /// <returns>True if figure was successful created, otherwise false.</returns>
        public bool CreateFigure(params Point[] points)
        {
            foreach (var dictionaryRecord in createFigureDictionary)
            {
                if (dictionaryRecord.Key.Invoke(points))
                {
                    Figure figure = dictionaryRecord.Value.Invoke(points);
                    figureList.AddFigure(figure);

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Overload of GetEnumerator for adapter figures list.
        /// </summary>
        /// <returns>GetEnumerator of figure list.</returns>
        public IEnumerator GetEnumerator()
        {
            return figureList.GetEnumerator();
        }

        /// <summary>
        /// Gets average perimeter of all figures.
        /// </summary>
        /// <returns>Average perimeters of all figures.</returns>
        public double AveragePerimeterOfAllFigures()
        {
            return FigureValuesCalculator.GetAllFiguresAveragePerimeter(figureList);
        }

        /// <summary>
        /// Gets average area of all figures.
        /// </summary>
        /// <returns>Average area of all figures.</returns>
        public double AverageAreaOfAllFigures()
        {
            return FigureValuesCalculator.GetAllFiguresAverageArea(figureList);
        }

        /// <summary>
        /// Gets largest area figure.
        /// </summary>
        /// <returns>Largest area figure.</returns>
        public Figure GetLargestAreaFigure()
        {
            return FiguresFinder.GetLargestAreaFigure(figureList);
        }

        /// <summary>
        /// Gets largest average perimeter type figure.
        /// </summary>
        /// <returns>Largest average perimeter type figure.</returns>
        public Type GetLargestAveragePerimeterTypeFigure()
        {
            return FiguresFinder.GetLargestAveragePerimeterTypeFigure(figureList);
        }

        /// <summary>
        /// Automatically generates random figure and add it in figure list.
        /// </summary>
        public void AutomaticallyGenerateFigure()
        {
            Random random = new Random();
            figureList.AddFigure(figureGenerators[random.Next(0, figureGenerators.Length - 1)].Invoke());
        }

    }
}