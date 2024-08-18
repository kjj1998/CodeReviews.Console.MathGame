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
            int[] gameNumbers = GenerateNumbersForGame(gameChoice);
                    
            Console.WriteLine($"What is {gameNumbers[0]} {Operators[gameChoice]} {gameNumbers[1]} ?");
            string? response = Console.ReadLine();

            if (response != null && response.ToLower().Equals("e"))
            {
                break;
            }
                    
            bool validAnswer = int.TryParse(response, out int answer);
            if (validAnswer == false)
            {
                Console.WriteLine($"{response} is invalid!");
            }
            else
            {
                if (answer == gameNumbers[2])
                {
                    Console.WriteLine("Your answer is correct!");
                    GameScores[gameChoice] += 1;
                }
                else
                {
                    Console.WriteLine("Your answer is wrong!");
                }
            }
            AttemptedGames[gameChoice]++;
        }
        
        Console.WriteLine($"You attempted {AttemptedGames[gameChoice]} {GameCategories[gameChoice]} questions " +
                          $"and got {GameScores[gameChoice]} questions correct!\n");
    }
}