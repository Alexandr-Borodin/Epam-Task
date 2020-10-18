using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Figures;
using TaskExecutionExceptions;

namespace TaskPerformers
{
    public class FigureValuesCalculator
    {
        public static double GetAllFiguresAveragePerimeter(FigureList figureList)
        {
            if (figureList == null)
                throw new TaskExecutionException("Can't computing average perimeter without figure list.");

            if (figureList.Length == 0)
                throw new TaskExecutionException("Can't computing average perimeter in zero length figure list.");

            double result = GetAllFiguresPerimeter(figureList);

            return result / figureList.Length;
        }

        public static double GetAllFiguresPerimeter(FigureList figureList)
        {
            if (figureList == null)
                throw new TaskExecutionException("Can't computing perimeter without figure list.");

            if (figureList.Length == 0)
                throw new TaskExecutionException("Can't computing perimeter in zero length figure list.");

            double result = 0f;

            foreach (Figure figure in figureList)
            {
                result += figure.Perimeter;
            }

            return result;
        }

        public static double GetAllFiguresAverageArea(FigureList figureList)
        {
            if (figureList == null)
                throw new TaskExecutionException("Can't computing average perimeter without figure list.");

            if (figureList.Length == 0)
                throw new TaskExecutionException("Can't computing average perimeter in zero length figure list.");

            double result = GetAllFiguresArea(figureList);

            return result / figureList.Length;
        }

        public static double GetAllFiguresArea(FigureList figureList)
        {
            if (figureList == null)
                throw new TaskExecutionException("Can't computing perimeter without figure list.");

            if (figureList.Length == 0)
                throw new TaskExecutionException("Can't computing perimeter in zero length figure list.");

            double result = 0f;

            foreach (Figure figure in figureList)
            {
                result += figure.Area;
            }

            return result;
        }
    }
}