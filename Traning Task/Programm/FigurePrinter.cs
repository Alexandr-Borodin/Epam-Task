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

            foreach (Point vertex in figure.Vertices)
            {
                Console.WriteLine($"1. ({vertex.X}, {vertex.Y})");
            }
        }
    }
}
