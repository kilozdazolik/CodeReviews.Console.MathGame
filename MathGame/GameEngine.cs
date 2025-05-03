using System.Diagnostics;
using MathGame.Models;

namespace MathGame;

internal class GameEngine
{
    internal void RunGame(string message, string operatorSymbol, GameType gameType)
    {
        Console.WriteLine($"{message}");

        Console.WriteLine("Please select a difficulty\n1 - Easy\n2 - Medium\n3 - Hard");
        var difficultyInput = Console.ReadLine();
        difficultyInput = Helpers.ValidateResult(difficultyInput);
        var (min, max) = Helpers.GetNumberRange(difficultyInput);

        var random = new Random();
        int firstNumber;
        int secondNumber;
        int score = 0;
        var stopWatch = Stopwatch.StartNew();

        for (int i = 0; i < 5; i++)
        {
            Console.Clear();
            Console.WriteLine(message);

            if (gameType == GameType.Division)
            {
                var divisionNumbers = Helpers.GetDivisionNumbers(difficultyInput);
                firstNumber = divisionNumbers[0];
                secondNumber = divisionNumbers[1];
            }
            else
            {
                firstNumber = random.Next(min, max + 1);
                secondNumber = random.Next(min, max + 1);
            }

            Console.WriteLine($"{firstNumber} {operatorSymbol} {secondNumber}");
            var result = Console.ReadLine();
            result = Helpers.ValidateResult(result);

            if (int.Parse(result) == Helpers.PerformOperation(firstNumber, secondNumber, gameType))
            {
                Console.WriteLine($"Your answer was correct! Type any key for the next question");
                score++;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Your answer was incorrect! Type any key for the next question");
                Console.ReadLine();
            }

            if (i == 4)
            {
                Console.WriteLine($"Game over. Your final score is {score}. Press any key to go back to the menu.");
                Console.ReadLine();
            }
        }

        stopWatch.Stop();
        var timeSpent = stopWatch.Elapsed;
        var difficultyLevel = (DifficultyLevel)int.Parse(difficultyInput);
        Helpers.AddToHistory(score, gameType, difficultyLevel, timeSpent);
    }

    internal void AdditionGame(string message)
    {
        RunGame(message, "+", GameType.Addition);
    }

    internal void SubtractionGame(string message)
    {
        RunGame(message, "-", GameType.Subtraction);
    }

    internal void MultiplicationGame(string message)
    {
        RunGame(message, "*", GameType.Multiplication);
    }

    internal void DivisionGame(string message)
    {
        RunGame(message, "/", GameType.Division);
    }

    internal void RandomGame(string message)
    {
        Console.WriteLine($"{message}");

        Console.WriteLine("Please select a difficulty\n1 - Easy\n2 - Medium\n3 - Hard");
        var difficultyInput = Console.ReadLine();
        difficultyInput = Helpers.ValidateResult(difficultyInput);
        var (min, max) = Helpers.GetNumberRange(difficultyInput);

        var random = new Random();
        int firstNumber, secondNumber;
        int score = 0;
        var stopWatch = Stopwatch.StartNew();

        for (int i = 0; i < 5; i++)
        {
            Console.Clear();
            Console.WriteLine(message);

            int randomGame = random.Next(0, 4); // 0: Addition, 1: Subtraction, 2: Multiplication, 3: Division

            string operationSymbol = randomGame switch
            {
                0 => "+",
                1 => "-",
                2 => "*",
                3 => "/",
                _ => throw new ArgumentOutOfRangeException()
            };

            if (operationSymbol == "/")
            {
                var divisionNumbers = Helpers.GetDivisionNumbers(difficultyInput);
                firstNumber = divisionNumbers[0];
                secondNumber = divisionNumbers[1];
            }
            else
            {
                firstNumber = random.Next(min, max + 1);
                secondNumber = random.Next(min, max + 1);
            }

            int correctAnswer = randomGame switch
            {
                0 => firstNumber + secondNumber,
                1 => firstNumber - secondNumber,
                2 => firstNumber * secondNumber,
                3 => firstNumber / secondNumber,
                _ => throw new ArgumentOutOfRangeException()
            };

            Console.WriteLine($"{firstNumber} {operationSymbol} {secondNumber}");
            var result = Console.ReadLine();
            result = Helpers.ValidateResult(result);

            if (int.Parse(result) == correctAnswer)
            {
                Console.WriteLine($"Your answer was correct! Type any key for the next question");
                score++;
            }
            else
            {
                Console.WriteLine("Your answer was incorrect! Type any key for the next question");
            }

            Console.ReadLine();

            if (i == 4)
            {
                Console.WriteLine($"Game over. Your final score is {score}. Press any key to go back to the menu.");
                Console.ReadLine();
            }
        }

        stopWatch.Stop();
        var timeSpent = stopWatch.Elapsed;
        var difficultyLevel = (DifficultyLevel)int.Parse(difficultyInput);
        Helpers.AddToHistory(score, GameType.Random, difficultyLevel, timeSpent);
    }
}