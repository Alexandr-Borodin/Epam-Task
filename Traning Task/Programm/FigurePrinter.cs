using System;
using System.Drawing;
using Figures;

namespace Programm
{
    /// <summary>
    /// Class for print figures.
    /// </summary>
    public class FigurePrinter
    {
        /// <summary>
        /// Method for print figure.
        /// </summary>
        /// <param name="figure">Figure to print.</param>
        public static void PrintFigure(Figure figure)
        {
            Console.WriteLine(figure.ToString());

            Console.WriteLine($"Perimeter: {figure.Perimeter}");
            Console.WriteLine($"Area: {figure.Area}");

            Console.WriteLine("Vertices:");

            int index = 1;

            foreach (Point point in figure.Vertices)
            {
                Console.WriteLine($"{index++}. ({point.X}, {point.Y})");
            }
        }
    }
}
