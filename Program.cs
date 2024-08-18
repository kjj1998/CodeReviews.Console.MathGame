using System.Globalization;
using CodeReviews.Console.MathGame;

string? gameChoice;
bool exitGame = false;
HashSet<string> validGameChoices = ["A", "B", "C", "D", "E", "a", "b", "c", "d", "e"];
var numberGenerator = new Random();

do
{
    Menu.DisplayMenu();
    gameChoice = Console.ReadLine();
    while (gameChoice != null && !validGameChoices.Contains(gameChoice))
    {
        Console.WriteLine("Invalid input. Please re-enter your choice.");
        gameChoice = Console.ReadLine();
    }

    if (gameChoice is "e" or "E")
    {
        exitGame = true;
    }
    else
    {
        switch (gameChoice)
        {
            case "a":
                Console.WriteLine("You have selected the addition game!");
                Console.WriteLine("Enter your answer after the prompt or enter the letter 'e' to end the current game");
                
                while (true)
                {
                    int numA = numberGenerator.Next(0, 100);
                    int numB = numberGenerator.Next(0, 100);
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
                        Console.WriteLine(answer == sum ? "Your answer is correct!" : "Your answer is wrong!");
                    }
                }
                Console.WriteLine();
                break;  
            case "b":
                Console.WriteLine("You have selected the subtraction game!");
                break;
            case "c":
                Console.WriteLine("You have selected the multiplication game!");
                break;
            case "d":
                Console.WriteLine("You have selected the division game!");
                break;
            default:
                Console.WriteLine("Invalid input. Please re-enter your choice");
                break;
        }
    }
} while (exitGame == false);

