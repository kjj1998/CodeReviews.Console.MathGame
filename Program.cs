﻿using CodeReviews.Console.MathGame;

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
    gameChoice = gameChoice?.ToLower();

    if (gameChoice is "e" or "E")
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
            default:
                Console.WriteLine("Invalid input. Please re-enter your choice");
                break;
        }
    }
} while (exitGame == false);

