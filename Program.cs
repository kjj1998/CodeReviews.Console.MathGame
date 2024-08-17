using CodeReviews.Console.MathGame;

string? gameChoice;
bool exitGame = false;
HashSet<string> validGameChoices = ["A", "B", "C", "D", "E", "a", "b", "c", "d", "e"];

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

