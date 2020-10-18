using Figures;
using TaskExecutionExceptions;

namespace TaskPerformers
{
    /// <summary>
    /// Describes figure values calculator.
    /// </summary>
    public class FigureValuesCalculator
    {
        /// <summary>
        /// Gets all figures average perimeter.
        /// </summary>
        /// <param name="figureList">Figure list.</param>
        /// <returns>All figures average perimeter.</returns>
        public static double GetAllFiguresAveragePerimeter(FigureList figureList)
        {
            if (figureList == null)
                throw new TaskExecutionException("Can't computing average perimeter without figure list.");

            if (figureList.Length == 0)
                throw new TaskExecutionException("Can't computing average perimeter in zero length figure list.");

            double result = GetAllFiguresPerimeter(figureList);

            return result / figureList.Length;
        }

        /// <summary>
        /// Gets all figures perimeter.
        /// </summary>
        /// <param name="figureList">Figure list.</param>
        /// <returns>All figures perimeter.</returns>
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

        /// <summary>
        /// Gets all figures average area.
        /// </summary>
        /// <param name="figureList">Figures list.</param>
        /// <returns>All figures average area.</returns>
        public static double GetAllFiguresAverageArea(FigureList figureList)
        {
            if (figureList == null)
                throw new TaskExecutionException("Can't computing average perimeter without figure list.");

            if (figureList.Length == 0)
                throw new TaskExecutionException("Can't computing average perimeter in zero length figure list.");

            double result = GetAllFiguresArea(figureList);

            return result / figureList.Length;
        }

        /// <summary>
        /// Gets all figures area.
        /// </summary>
        /// <param name="figureList">Figures area.</param>
        /// <returns>All figures area.</returns>
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