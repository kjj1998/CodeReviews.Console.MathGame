using CodeReviews.Console.MathGame;

string? gameChoice;
bool exitGame = false;
HashSet<string> validGameChoices = ["A", "B", "C", "D", "E", "F", "G", "H", "a", "b", "c", "d", "e", "f", "g", "h"];

do
{
    Menu.DisplayMenu();
    gameChoice = Console.ReadLine();
    while (gameChoice != null && !validGameChoices.Contains(gameChoice))
    {
        Console.WriteLine("Invalid input. Please re-enter your choice.");
        gameChoice = Console.ReadLine();
    }
    gameChoice = gameChoice?.ToLower();

    if (gameChoice is "h")
    {
        exitGame = true;
    }
    else
    {
        switch (gameChoice)
        {
            case "a":
                GameEngine.Game(0);
                break;  
            case "b":
                GameEngine.Game(1);
                break;
            case "c":
                GameEngine.Game(2);
                break;
            case "d":
                GameEngine.Game(3);
                break;
            case "e":
                GameEngine.Game(0, true);
                break;
            case "f":
                GameEngine.SetGameDifficulty();
                break;
            case "g":
                GameEngine.DisplayHistoryAndStatistics();
                break;
            default:
                Console.WriteLine("Invalid input. Please re-enter your choice");
                break;
        }
    }
} while (exitGame == false);

