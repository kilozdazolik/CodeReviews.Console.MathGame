namespace MathGame;

internal class Menu
{
    private GameEngine engine = new();

    internal void ShowMenu(string s, DateTime date)
    {
        Console.Clear();
        Console.WriteLine(
            $"Hello {s.ToUpper()}, its {date.DayOfWeek}. This is your math's game. That's great that you're working on improving yourself\n");
        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();
        
        bool isGameOn = true;

        do
        {
            Console.Clear();
            Console.WriteLine("What game would you like to play today? Choose from the options below: " +
                              "\nV - View Previous Games" +
                              "\nA - Addition" +
                              "\nS - Subtraction" +
                              "\nM - Multiplication" +
                              "\nD - Division" +
                              "\nR - Random Game" +
                              "\nQ - Quit the program");
            Console.WriteLine("-----------------------------------");

            var gameSelected = Console.ReadLine();

            switch (gameSelected.Trim().ToLower())
            {
                case "v":
                    Helpers.PrintGames();
                    break;
                case "a":
                    engine.AdditionGame("Addition game selected");
                    break;
                case "s":
                    engine.SubtractionGame("Subtraction game selected");
                    break;
                case "m":
                    engine.MultiplicationGame("Multiplication game selected");
                    break;
                case "d":
                    engine.DivisionGame("Divison game selected");
                    break;
                case "r":
                    engine.RandomGame("Random game selected");
                    break;
                case "q":
                    Console.WriteLine("Goodbye");
                    isGameOn = false;
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        } while (isGameOn);
    }
}