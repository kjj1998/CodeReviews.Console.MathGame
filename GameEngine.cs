// ReSharper disable ConvertSwitchStatementToSwitchExpression
namespace CodeReviews.Console.MathGame;

using System;

public static class GameEngine
{
    private static readonly Random NumberGenerator = new();
    private static readonly int[] AttemptedGames = [0, 0, 0, 0];
    private static readonly int[] GameScores = [0, 0, 0, 0];
    private static readonly string[] GameCategories = ["addition", "subtraction", "multiplication", "division"];
    private static readonly string[] Operators = ["+", "-", "*", "/"];
    private static readonly List<List<string>> Histories = [];

    private static bool CheckDividendsForDivision(int numA, int numB)
    {
        return numB != 0 && numA % numB == 0;
    }

    private static int[] GenerateNumbersForGame(int gameChoice)
    {
        int numA = NumberGenerator.Next(0, 100);
        int numB = NumberGenerator.Next(0, 11);
        int result = 0;

        if (gameChoice == 3)
        {
            while (CheckDividendsForDivision(numA, numB) == false)
            {
                numA = NumberGenerator.Next(0, 100);
                numB = NumberGenerator.Next(0, 11);
            }
        }

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
    
    public static void Game(int gameChoice)
    {
        Console.WriteLine($"You have selected the {GameCategories[gameChoice]} game!");
        Console.WriteLine("Enter your answer after the prompt or enter the letter 'e' to end the current game");
                
        while (true)
        {
            var localTime = DateTime.Now;
            int[] gameNumbers = GenerateNumbersForGame(gameChoice);
                    
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
                }
                else
                {
                    Console.WriteLine("Your answer is wrong!");
                    currentGame.Add("Incorrect");
                }
            }
            AttemptedGames[gameChoice]++;
            Histories.Add(currentGame);
        }
        
        Console.WriteLine($"You attempted {AttemptedGames[gameChoice]} {GameCategories[gameChoice]} questions " +
                          $"and got {GameScores[gameChoice]} questions correct!\n");
    }

    public static void DisplayHistoryAndStatistics()
    {
        if (Histories.Count == 0)
        {
            Console.WriteLine("You have not played any games!\n");
            return;
        } 
        
        Console.WriteLine("Time\t\t \tQuestion\tResponse\tStatus");
        foreach (var history in Histories)
        {
            Console.Write($"{history[0]}\t");
            Console.Write($"{history[1]} {history[2]} {history[3]}\t");
            Console.Write($"\t{history[4]}\t");
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

        double correctPercentage = Math.Round((totalScore / (double) totalGamesAttempted) * 100, 2);
        
        Console.WriteLine($"In total, you attempted {totalGamesAttempted} and got a score of {totalScore} with a " +
                          $"correct percentage of {correctPercentage}%\n");
    }
}