using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Figures;
using TaskExecutionExceptions;

namespace TaskPerformers
{
    public class FiguresFinder
    {
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

        public static Type GetLargestAveragePerimeterTypeFigure(FigureList figureList)
        {
            Dictionary<Type, double> dictionariesTypesAndPerimeters = new Dictionary<Type, double>();

            addKeysInDictionary(figureList, dictionariesTypesAndPerimeters);

            addValuesInDictionary(figureList, dictionariesTypesAndPerimeters);

            Type largestAveragePerimeterType = findLargestAveragePerimeterType(dictionariesTypesAndPerimeters);

            return largestAveragePerimeterType;
        }

        #region GetLargestAveragePerimeterTypeFigure Fuctions

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

        private static void addValuesInDictionary(FigureList figureList,
            Dictionary<Type, double> dictionariesTypesAndPerimeters)
        {
            foreach (Type typeOfFigure in dictionariesTypesAndPerimeters.Keys.ToArray())
            {
                dictionariesTypesAndPerimeters[typeOfFigure] =
                    calculateAveragePerimeterForType(typeOfFigure, figureList);
            }
        }

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