using System;
using System.Collections.Generic;
using System.Linq;
using Figures;
using TaskExecutionExceptions;

namespace TaskPerformers
{
    /// <summary>
    /// Describes figures finder.
    /// </summary>
    public class FiguresFinder
    {
        /// <summary>
        /// Gets largest area figure.
        /// </summary>
        /// <param name="figureList">Figure list.</param>
        /// <returns>Largest area figure.</returns>
        public static Figure GetLargestAreaFigure(FigureList figureList)
        {
            if(figureList == null)
                throw new TaskExecutionException("Can't find largest area figure without figure list.");

            if (figureList.Length == 0)
                throw new Exception("Can't find largest area figure in zero length figure list.");

            Figure largestAreaFigure = null;
            double largestArea = 0f;

            foreach (Figure figure in figureList)
            {
                if (figure.Area > largestArea)
                {
                    largestArea = figure.Area;
                    largestAreaFigure = figure;
                }
            }

            return largestAreaFigure;
        }

        /// <summary>
        /// Gets largest average perimeter type figure.
        /// </summary>
        /// <param name="figureList">Figure list.</param>
        /// <returns>Largest average type figure.</returns>
        public static Type GetLargestAveragePerimeterTypeFigure(FigureList figureList)
        {
            Dictionary<Type, double> dictionariesTypesAndPerimeters = new Dictionary<Type, double>();

            addKeysInDictionary(figureList, dictionariesTypesAndPerimeters);

            addValuesInDictionary(figureList, dictionariesTypesAndPerimeters);

            Type largestAveragePerimeterType = findLargestAveragePerimeterType(dictionariesTypesAndPerimeters);

            return largestAveragePerimeterType;
        }

        #region GetLargestAveragePerimeterTypeFigure Fuctions

        /// <summary>
        /// Finds largest average perimeter type of figure. 
        /// </summary>
        /// <param name="dictionariesTypesAndPerimeters">Dictionary with figure types as keys and perimeters as values.</param>
        /// <returns>Largest average perimeter type of figure.</returns>
        private static Type findLargestAveragePerimeterType(Dictionary<Type, double> dictionariesTypesAndPerimeters)
        {
            Type largestAveragePerimeterFigureType = null;

            double largeAveregePerimeter = 0;

            foreach (var dictionaryElement in dictionariesTypesAndPerimeters.ToArray())
            {
                if (dictionaryElement.Value > largeAveregePerimeter)
                {
                    largeAveregePerimeter = dictionaryElement.Value;
                    largestAveragePerimeterFigureType = dictionaryElement.Key;
                }
            }

            return largestAveragePerimeterFigureType;
        }

        /// <summary>
        /// Adds values in dictionary.
        /// </summary>
        /// <param name="figureList">Figure list.</param>
        /// <param name="dictionariesTypesAndPerimeters">Dictionary with figure types as keys and perimeters as values.</param>
        private static void addValuesInDictionary(FigureList figureList,
            Dictionary<Type, double> dictionariesTypesAndPerimeters)
        {
            foreach (Type typeOfFigure in dictionariesTypesAndPerimeters.Keys.ToArray())
            {
                dictionariesTypesAndPerimeters[typeOfFigure] =
                    calculateAveragePerimeterForType(typeOfFigure, figureList);
            }
        }

        /// <summary>
        /// Calculates average perimeter for one type of figure.
        /// </summary>
        /// <param name="type">Type of figure.</param>
        /// <param name="figureList">Figure list.</param>
        /// <returns>Average perimeter for one type of figure</returns>
        private static double calculateAveragePerimeterForType(Type type, FigureList figureList)
        {
            FigureList figureListByOneType = new FigureList();

            foreach (Figure figure in figureList)
            {
                if (type == figure.GetType())
                    figureListByOneType.AddFigure(figure);
            }

            return FigureValuesCalculator.GetAllFiguresAveragePerimeter(figureListByOneType);
        }

        /// <summary>
        /// Adds keys in dictionary.
        /// </summary>
        /// <param name="figureList">Figure list.</param>
        /// <param name="dictionariesTypesAndPerimeters">Dictionary with figure types as keys and perimeters as values.</param>
        private static void addKeysInDictionary(FigureList figureList, Dictionary<Type, double> dictionariesTypesAndPerimeters)
        {
            HashSet<Type> set = new HashSet<Type>();

            List<Type> types = new List<Type>();

            foreach (Figure figure in figureList)
            {
                if (set.Add(figure.GetType()))
                {
                    types.Add(figure.GetType());
                }
            }

            FormationTypesWithZeroValuesInDictionary(dictionariesTypesAndPerimeters, types);
        }

        /// <summary>
        /// Adds types as key and zero as value in dictionary.
        /// </summary>
        /// <param name="dictionariesTypesAndPerimeters">Dictionary with figure types as keys and perimeters as values.</param>
        /// <param name="types">Type of figure.</param>
        private static void FormationTypesWithZeroValuesInDictionary(
            Dictionary<Type, double> dictionariesTypesAndPerimeters, List<Type> types)
        {
            for (int index = 0; index < types.Count; index++)
            {
                dictionariesTypesAndPerimeters.Add(types[index], 0);
            }
        }

#endregion
    }
}