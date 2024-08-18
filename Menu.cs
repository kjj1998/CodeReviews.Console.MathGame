namespace CodeReviews.Console.MathGame;

public static class Menu
{
    public static void DisplayMenu()
    {
        System.Console.WriteLine("Welcome to the Math Game!");
        System.Console.WriteLine("Please select which game you want to play from the list below:");
        System.Console.WriteLine("1. Addition - Press A to select this");
        System.Console.WriteLine("2. Subtraction - Press B to select this");
        System.Console.WriteLine("3. Multiplication - Press C to select this");
        System.Console.WriteLine("4. Division - Press D to select this");
        System.Console.WriteLine("5. Exit - Press E to end the game\n");
    }
}