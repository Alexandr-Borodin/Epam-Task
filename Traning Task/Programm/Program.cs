using System;

namespace Programm
{
    class Program
    {
        static void Main()
        {
            UserInterface userInterface = new UserInterface();

            int userChoise;

            userInterface.Beginning();

            do
            {
                userInterface.PrintMenu();

                userChoise = userInterface.GetUserChoise();

                switch (userChoise)
                {
                    case 1:
                    {
                        userInterface.AddFigure();
                        break;
                    }
                    case 2:
                    {
                        userInterface.AutomaticallyGenerateFigure();
                        break;
                    }
                    case 3:
                    {
                        userInterface.PrintAllFigures();
                        break;
                    }
                    case 4:
                    {
                        userInterface.ShowAveragePerimeterOfAllFigure();
                        userInterface.ShowAverageAreaOfAllFigure();
                        break;
                    }
                    case 5:
                    {
                        userInterface.ShowLargestAreaFigure();
                        break;
                    }
                    case 6:
                    {
                        userInterface.ShowLargestAveragePerimeterTypeFigure();
                        break;
                    }

            }
            } while (userChoise != 7);

            Console.Write("Enter any key: ");
            Console.ReadLine();
        }
    }
}