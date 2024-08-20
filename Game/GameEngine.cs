// ReSharper disable ConvertSwitchStatementToSwitchExpression
namespace CodeReviews.Console.MathGame;
using System;
using System.Diagnostics;

public static class GameEngine
{
    private static readonly Random NumberGenerator = new();
    private static readonly int[] AttemptedGames = [0, 0, 0, 0];
    private static readonly int[] GameScores = [0, 0, 0, 0];
    private static readonly string[] GameCategories = ["addition", "subtraction", "multiplication", "division"];
    private static readonly string[] Operators = ["+", "-", "*", "/"];
    private static readonly List<List<string>> Histories = [];
    private static string _gameDifficulty = "Medium";
    private static readonly HashSet<string> DifficultyChoices = ["e", "E", "m", "M", "h", "H"];

    private static bool CheckDividendsForDivision(int numA, int numB)
    {
        return numB != 0 && numA % numB == 0;
    }

    private static int[] GenerateNumbersForGame(int gameChoice)
    {
        int numA = 0, numB = 0;
        switch (_gameDifficulty)
        {
            case "Easy":
                numA = NumberGenerator.Next(0, 11);
                numB = NumberGenerator.Next(0, 11);
                break;
            case "Medium":
                numA = NumberGenerator.Next(0, 101);
                numB = NumberGenerator.Next(0, 11);
                break;
            case "Hard":
                numA = NumberGenerator.Next(0, 101);
                numB = NumberGenerator.Next(0, 101);
                break;
        }

        if (gameChoice != 3) 
            return [numA, numB];
        
        while (CheckDividendsForDivision(numA, numB) == false)
        {
            switch (_gameDifficulty)
            {
                case "Easy":
                    numA = NumberGenerator.Next(0, 11);
                    numB = NumberGenerator.Next(0, 11);
                    break;
                case "Medium":
                    numA = NumberGenerator.Next(0, 101);
                    numB = NumberGenerator.Next(0, 21);
                    break;
                case "Hard":
                    numA = NumberGenerator.Next(0, 101);
                    numB = NumberGenerator.Next(0, 101);
                    break;
            }
        }

        return [numA, numB];
    }

    private static int[] GenerateQuestionAndAnswer(int gameChoice)
    {
        int[] gameNumbers = GenerateNumbersForGame(gameChoice);
        int numA = gameNumbers[0];
        int numB = gameNumbers[1];
        int result = 0;
        
        switch (gameChoice)
        {
            case 0:
                result = numA + numB;
                break;
            case 1:
                result = numA - numB;
                break;
            case 2:
                result = numA * numB;
                break;
            case 3:
                result = numA / numB;
                break;
        }

        return [numA, numB, result];
    }
    
    public static void Game(int gameChoice, bool randomGame = false)
    {
        Console.WriteLine($"You have selected the {(randomGame ? "random" : GameCategories[gameChoice])} game " +
                          $"and you are playing on {_gameDifficulty} difficulty!");
        Console.WriteLine("Enter your answer after the prompt or enter the letter 'e' to end the current game");

        var numberOfAttemptedQuestions = 0;
        var numberOfCorrectQuestions = 0;
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        
        while (true)
        {
            if (randomGame)
                gameChoice = NumberGenerator.Next(0, 4);
            
            var localTime = DateTime.Now;
            int[] gameNumbers = GenerateQuestionAndAnswer(gameChoice);
                    
            Console.WriteLine($"What is {gameNumbers[0]} {Operators[gameChoice]} {gameNumbers[1]} ?");
            string response = Console.ReadLine() ?? string.Empty;

            if (response.ToLower().Equals("e"))
            {
                break;
            }
            
            bool validAnswer = int.TryParse(response, out int answer);
            List<string> currentGame =
            [
                localTime.ToString("yyyy-MM-dd HH:mm:ss"),
                gameNumbers[0].ToString(),
                Operators[gameChoice],
                gameNumbers[1].ToString()
            ];

            if (validAnswer == false)
            {
                Console.WriteLine($"{response} is invalid!");
                currentGame.Add(response);
                currentGame.Add("Invalid");
            }
            else
            {
                currentGame.Add(answer.ToString());
                if (answer == gameNumbers[2])
                {
                    Console.WriteLine("Your answer is correct!");
                    GameScores[gameChoice] += 1;
                    currentGame.Add("Correct");
                    numberOfCorrectQuestions++;
                }
                else
                {
                    Console.WriteLine("Your answer is wrong!");
                    currentGame.Add("Incorrect");
                }
            }
            currentGame.Add(_gameDifficulty);
            AttemptedGames[gameChoice]++;
            Histories.Add(currentGame);
            numberOfAttemptedQuestions++;
        }
        stopwatch.Stop();
        
        Console.WriteLine($"Question category: {(randomGame ? "random" : GameCategories[gameChoice])}");
        Console.WriteLine($"Number of questions attempted: {numberOfAttemptedQuestions}");
        Console.WriteLine($"Number of correct questions: {numberOfCorrectQuestions}");
        Console.WriteLine($"Difficulty level: {_gameDifficulty}");
        Console.WriteLine($"Time taken: {stopwatch.Elapsed.Seconds} seconds\n");
    }

    public static void DisplayHistoryAndStatistics()
    {
        if (Histories.Count == 0)
        {
            Console.WriteLine("You have not played any games!\n");
            return;
        } 
        
        Console.WriteLine("Time\t\t \tQuestion\tResponse\tDifficulty\tStatus");
        foreach (var history in Histories)
        {
            Console.Write($"{history[0]}\t"); 
            Console.Write($"{history[1]} {history[2]} {history[3]}\t");
            Console.Write($"\t{history[4]}\t");
            Console.Write($"\t{history[6]}\t");
            Console.Write($"\t{history[5]}\n");
        }
        Console.WriteLine();
        
        int totalGamesAttempted = 0;
        int totalScore = 0;
        for (int i = 0; i < AttemptedGames.Length; i++)
        {
            Console.WriteLine($"You attempted {AttemptedGames[i]} {GameCategories[i]} questions " +
                              $"and got {GameScores[i]} questions correct.");
            totalGamesAttempted += AttemptedGames[i];
            totalScore += GameScores[i];
        }

        double correctPercentage = Math.Round(totalScore / (double) totalGamesAttempted * 100, 2);
        Console.WriteLine($"In total, you attempted {totalGamesAttempted} and got a score of {totalScore} with a " +
                          $"correct percentage of {correctPercentage}%\n");
    }

    public static void SetGameDifficulty()
    {
        Console.WriteLine($"Please set your desired game difficulty. Current difficulty is {_gameDifficulty}");
        Console.WriteLine("1. Press E to set easy difficulty.");
        Console.WriteLine("2. Press M to set medium difficulty.");
        Console.WriteLine("3. Press H to set hard difficulty");
        
        string difficultyChoice = Console.ReadLine() ?? string.Empty;
        while (!DifficultyChoices.Contains(difficultyChoice))
        {
            Console.WriteLine("Invalid input. Please re-enter your choice.");
            difficultyChoice = Console.ReadLine() ?? string.Empty;
        }
        difficultyChoice = difficultyChoice.ToLower();
        

        switch (difficultyChoice)
        {
            case "e":
                Console.WriteLine("You have selected Easy difficulty.\n");
                _gameDifficulty = "Easy";
                break;
            case "m":
                Console.WriteLine("You have selected Medium difficulty.\n");
                _gameDifficulty = "Medium";
                break;
            case "h":
                Console.WriteLine("You have selected Hard difficulty.\n");
                _gameDifficulty = "Hard";
                break;
        }
    }
}