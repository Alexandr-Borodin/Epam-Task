using System;
using System.Drawing;
using System.Text.RegularExpressions;
using Figures;

namespace Programm
{
    /// <summary>
    /// Describes console user interface.
    /// </summary>
    public class UserInterface
    {
        /// <summary>
        /// Pattern(for regular expression) for check user input.
        /// </summary>
        private readonly string patternForIntValues = @"[^/-][^0-9]";

        /// <summary>
        /// Interface menu.
        /// </summary>
        private readonly InterfaceMenu menu;

        /// <summary>
        /// Adapter for user interface.
        /// </summary>
        private readonly Adapter adapter;

        /// <summary>
        /// Constructor for UserInterface.
        /// </summary>
        public UserInterface()
        {
            menu = new InterfaceMenu();
            adapter = new Adapter();
        }

        /// <summary>
        /// Calls in beginning of program execution, because to do calculation must be at least one figure.
        /// </summary>
        public void Beginning()
        {
            Console.WriteLine("For start you must enter at least 1 figure.");
            AddFigure();
        }

        /// <summary>
        /// Print interface menu.
        /// </summary>
        public void PrintMenu()
        {
            Console.WriteLine(menu.Head);
            for (int index = 0; index < menu.Length; index++)
            {
                Console.WriteLine($"{index + 1}. {menu[index]}");
            }
        }

        /// <summary>
        /// Add figure in adapter figure list.
        /// </summary>
        public void AddFigure()
        {
            bool successfulAdd;

            do
            {
                Console.Write("Enter how many vertices: ");
                int numberOfVertices;
                do
                {
                    numberOfVertices = InputInt();

                } while (numberOfVertices <= 0);

                Point[] points = new Point[numberOfVertices];

                for (int index = 0; index < numberOfVertices; index++)
                {
                    Console.WriteLine($"{index + 1} vertex:");
                    points[index] = InputPoint();
                }

                if (adapter.CreateFigure(points))
                {
                    Console.WriteLine(adapter.GetLastFigure + " was added.");
                    successfulAdd = true;
                }
                else
                {
                    Console.WriteLine("Can't create that figure.");
                    successfulAdd = false;
                }
            } while (!successfulAdd);
        }

        /// <summary>
        /// Shows average perimeter of all figures in console.
        /// </summary>
        public void ShowAveragePerimeterOfAllFigure()
        {
            Console.WriteLine($"Average perimeter of all figures: {adapter.AveragePerimeterOfAllFigures()}");
        }

        /// <summary>
        /// Automatically generates figure.
        /// </summary>
        public void AutomaticallyGenerateFigure()
        {
            adapter.AutomaticallyGenerateFigure();
            Console.WriteLine(adapter.GetLastFigure + " was added.");
        }

        /// <summary>
        /// Shows average area of all figures.
        /// </summary>
        public void ShowAverageAreaOfAllFigure()
        {
            Console.WriteLine($"Average area of all figures: {adapter.AverageAreaOfAllFigures()}");
        }

        /// <summary>
        /// Shows largest area figure i console.
        /// </summary>
        public void ShowLargestAreaFigure()
        {
            Console.WriteLine("Largest area figure:");
            FigurePrinter.PrintFigure(adapter.GetLargestAreaFigure());
        }

        /// <summary>
        /// Shows largest average perimeter type figure in console.
        /// </summary>
        public void ShowLargestAveragePerimeterTypeFigure()
        {
            Console.WriteLine("Type of largest average perimeter figure: ");
            Console.WriteLine(adapter.GetLargestAveragePerimeterTypeFigure());
        }

        /// <summary>
        /// Prints all figures in console.
        /// </summary>
        public void PrintAllFigures()
        {
            foreach (Figure figure in adapter)
            {
                FigurePrinter.PrintFigure(figure);
            }
        }

        /// <summary>
        /// Create point from user input.
        /// </summary>
        /// <returns>New point.</returns>
        public Point InputPoint()
        {
            Console.Write("X=");
            int x = InputInt();

            Console.Write("Y=");
            int y = InputInt();

            return new Point(x, y);
        }

        /// <summary>
        /// Gets int values from user input.
        /// </summary>
        /// <returns>Int values.</returns>
        public int InputInt()
        {
            string userInput;

            int result;

            do
            {
                userInput = Console.ReadLine();

            } while (!Int32.TryParse(userInput, out result) || Regex.IsMatch(userInput, patternForIntValues));


            return result;
        }

        /// <summary>
        /// Gets user choise(choise what point in menu program must do).
        /// </summary>
        /// <returns>User chosen menu point</returns>
        public int GetUserChoise()
        {
            int userChoise;

            do
            {
                Console.Write("Enter menu point: ");
                userChoise = InputInt();
                Console.Clear();
            } while (userChoise < 0 || userChoise > 7);

            return userChoise;
        }
    }
}