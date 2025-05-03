namespace MathGame.Models;

internal class Game
{
    public int Score { get; set; }

    public DateTime Date { get; set; }

    public GameType Type { get; set; }
    
    public DifficultyLevel Difficulty { get; set; }
    
    public TimeSpan TimeSpent { get; set; }
}

internal enum GameType
{
    Addition, Subtraction, Multiplication, Division, Random
}

internal enum DifficultyLevel
{
    Easy = 1,  Medium = 2, Hard = 3
}
