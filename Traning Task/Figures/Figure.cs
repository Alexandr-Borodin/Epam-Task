using System.Drawing;
using FigureBuildExceptions;
using FigureValidator;
using FigureValidator = FigureValidator.CommonFigureValidator;

namespace Figures
{
    /// <summary>
    /// Describes abstract essence figure.
    /// </summary>
    public abstract class Figure
    {
        /// <summary>
        /// Stores figure vertices.
        /// </summary>
        public Point[] Vertices;

        /// <summary>
        /// Describes figure perimeter.
        /// </summary>
        public abstract double Perimeter { get; }

        /// <summary>
        /// Describes figure area. 
        /// </summary>
        public abstract double Area { get; }

        /// <summary>
        /// Figure validator.
        /// </summary>
        private static CommonFigureValidator _validator { get; } = new CommonFigureValidator();

        /// <summary>
        /// Constructor of Figure.
        /// </summary>
        /// <param name="vertices">Figure vertices.</param>
        protected Figure(params Point[] vertices)
        {
            if(!IsValid(vertices))
                throw new FigureBuildException("Can't create a figure.");

            Vertices = vertices;
        }

        /// <summary>
        /// Checks valid of given vertices(opportunity to creates figure from it).
        /// </summary>
        /// <param name="vertices">Figure vertices.</param>
        /// <returns>True if can create figure from given points, otherwise false.</returns>
        public static bool IsValid(params Point[] vertices)
        {
            return _validator.IsCanCreateFigure(vertices);
        }

        /// <summary>
        /// Override of ToString method.
        /// </summary>
        /// <returns>String "Name".</returns>
        public override string ToString()
        {
            return "Figure";
        }
    }
}