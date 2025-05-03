using MathGame.Models;

namespace MathGame;

internal class Helpers
{
    internal static List<Game> games = new();

    internal static void PrintGames()
    {   
        Console.Clear();
        Console.WriteLine("Games History");
        Console.WriteLine("-------------------------");
        foreach (var game in games)
        {
            Console.WriteLine($"{game.Date} - {game.Type} / Difficulty {game.Difficulty}: {game.Score}pts // Time: {game.TimeSpent}");
        }

        Console.WriteLine("-------------------------");
        Console.WriteLine("Press any key to return to Main Menu");
        Console.ReadLine();
    }

    internal static void AddToHistory(int gameScore, GameType gameType, DifficultyLevel difficulty, TimeSpan timeSpent)
    {
        games.Add(new Game { Date = DateTime.Now, Score = gameScore, Type = gameType, Difficulty = difficulty, TimeSpent = timeSpent });
    }

    internal static string? ValidateResult(string result)
    {
        while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
        {
            Console.WriteLine("Please enter a valid number");
            result = Console.ReadLine();
        }

        return result;
    }

    internal static string GetName()
    {
        Console.WriteLine("Please type your name");
        var name = Console.ReadLine();
        
        while (string.IsNullOrEmpty(name) || Int32.TryParse(name, out _))
        {
            Console.WriteLine("Name cant be empty");
            name = Console.ReadLine();
        }
        
        return name;
    }
    
    internal static (int min, int max) GetNumberRange(string difficulty)
    {
        switch (difficulty)
        {
            case "1": return (1, 100);
            case "2": return (10, 500);
            case "3": return (100, 1500);
            default: return (1, 20);
        }
    }
    
    internal static int PerformOperation(int firstNumber, int secondNumber, GameType gameType)
    {
        switch (gameType)
        {
            case GameType.Addition:
                return firstNumber + secondNumber;
            case GameType.Subtraction:
                return firstNumber - secondNumber;
            case GameType.Multiplication:
                return firstNumber * secondNumber;
            case GameType.Division:
                return firstNumber / secondNumber;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
    internal static int[] GetDivisionNumbers(string difficulty)
    {
        var (min, max) = GetNumberRange(difficulty);
        
        var random = new Random();
        var firstNumber = random.Next(min, max + 1);
        var secondNumber = random.Next(min, max + 1);

        var result = new int[2];

        while (firstNumber % secondNumber != 0)
        {
            firstNumber = random.Next(min, max + 1);
            secondNumber = random.Next(min, max + 1);
        }

        result[0] = firstNumber;
        result[1] = secondNumber;

        return result;
    }
}