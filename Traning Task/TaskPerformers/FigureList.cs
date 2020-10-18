using System;
using System.Collections;
using System.Collections.Generic;
using Figures;

namespace TaskPerformers
{
    /// <summary>
    /// Describes figure list.
    /// </summary>
    public class FigureList
    {
        /// <summary>
        /// Actual figure list.
        /// </summary>
        private readonly List<Figure> _figures;

        /// <summary>
        /// Gets count of figures in figure list.
        /// </summary>
        public int Length => _figures.Count;

        /// <summary>
        /// Indexer for work with figure list by figures names.
        /// </summary>
        /// <param name="figureName">Figure name which user want get.</param>
        /// <returns>Figure which named with figure name.</returns>
        public Figure this[string figureName]
        {
            get
            {
                foreach (var figure in _figures)
                {
                    if (String.Compare(figureName, figure.ToString(), StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        return figure;
                    }
                }

                return null;
            }
        }

        /// <summary>
        /// Indexer for work with figure list by number of figure in figure list.
        /// </summary>
        /// <param name="index">Number of figure in figure list.</param>
        /// <returns>Figure which stay under "index" number in figure list.</returns>
        public Figure this[int index] => _figures[index];

        /// <summary>
        /// Constructor of FigureList.
        /// </summary>
        public FigureList()
        {
            _figures = new List<Figure>();
        }

        /// <summary>
        /// Constructor of figure list.
        /// </summary>
        /// <param name="figures">Figures which must add in figure list.</param>
        public FigureList(params Figure[] figures) : this()
        {
            foreach (var figure in figures)
            {
                _figures.Add(figure);
            }
        }

        /// <summary>
        /// Adds figure in figure list.
        /// </summary>
        /// <param name="figure">Figure to add in figure list.</param>
        public void AddFigure(Figure figure)
        {
            _figures.Add(figure);
        }

        /// <summary>
        /// Overload of GetEnumerator to work with figure list.
        /// </summary>
        /// <returns>GetEnumerator of figure list.</returns>
        public IEnumerator GetEnumerator()
        {
            return _figures.GetEnumerator();
        }
    }
}