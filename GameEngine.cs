namespace CodeReviews.Console.MathGame;

using System;

public static class Game
{
    private static readonly Random NumberGenerator = new();
    private static int _additionGameScore, _additionGameQuestionsAnswered;
    private static int _subtractionGameScore, _subtractionGameQuestionsAnswered;
    private static int[] attemptedGames = [0, 0, 0, 0];
    private static int[] gameScores = [0, 0, 0, 0];
    
    public static void AdditionGame(int gameChoice)
    {
        Console.WriteLine("You have selected the addition game!");
        Console.WriteLine("Enter your answer after the prompt or enter the letter 'e' to end the current game");
                
        while (true)
        {
            int numA = NumberGenerator.Next(0, 100);
            int numB = NumberGenerator.Next(0, 100);
            int sum = numA + numB;
                    
            Console.WriteLine($"What is {numA} + {numB} ?");
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
                if (answer == sum)
                {
                    Console.WriteLine("Your answer is correct!");
                    _additionGameScore++;
                }
                else
                {
                    Console.WriteLine("Your answer is wrong!");
                }
            }
            _additionGameQuestionsAnswered++;
        }
        Console.WriteLine($"You attempted {_additionGameQuestionsAnswered} addition questions and got {_additionGameScore} questions correct!\n");
    }

    public static void SubtractionGame()
    {
        Console.WriteLine("You have selected the subtraction game!");
        Console.WriteLine("Enter your answer after the prompt or enter the letter 'e' to end the current game");
                
        while (true)
        {
            int numA = NumberGenerator.Next(0, 100);
            int numB = NumberGenerator.Next(0, 100);
            int difference = numA - numB;
                    
            Console.WriteLine($"What is {numA} - {numB} ?");
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
                if (answer == difference)
                {
                    Console.WriteLine("Your answer is correct!");
                    _subtractionGameScore++;
                }
                else
                {
                    Console.WriteLine("Your answer is wrong!");
                }
            }
            _subtractionGameQuestionsAnswered++;
        }
        Console.WriteLine($"You attempted {_subtractionGameScore} subtraction questions and got {_subtractionGameQuestionsAnswered} questions correct!\n");
    }
}