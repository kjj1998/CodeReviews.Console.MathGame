namespace CodeReviews.Console.MathGame;

public static class Menu
{
    public static void DisplayMenu()
    {
        System.Console.WriteLine("Welcome to the Math Game!");
        System.Console.WriteLine("Please select which game you want to play from the list below:");
        System.Console.WriteLine("1. Addition - Press A to select the addition game");
        System.Console.WriteLine("2. Subtraction - Press B to select the subtraction game");
        System.Console.WriteLine("3. Multiplication - Press C to select the multiplication game");
        System.Console.WriteLine("4. Division - Press D to select the division game");
        System.Console.WriteLine("5. Random Game - Press E to select the random game");
        System.Console.WriteLine("6. Difficulty - Press F to set the difficulty of the game");
        System.Console.WriteLine("7. History and Statistics - Press G to show game history and stats");
        System.Console.WriteLine("8. Exit - Press H to end the game\n");
    }
}