using System;

public static class Kp
{
    public static void Run()
    {
        string username = GetUsername();
        Console.WriteLine($"Welcome, {username}!");

        while (true)
        {
            int sides = GetNumberOfSides();

            int result = RollDice(sides);
            Console.WriteLine($"You rolled a {result} using a {sides}-sided die.");

            if (!RollAgainPrompt())
                break;
        }

        Console.WriteLine("Goodbye!");
    }

    static string GetUsername()
    {
        string username;

        do
        {
            Console.Write("Enter your username: ");
            username = Console.ReadLine();

            if (ValidateUsername(username))
                break;
            else
                Console.WriteLine("Invalid username. Please try again.");

        } while (true);

        return username;
    }

    static bool ValidateUsername(string username)
    {
        Console.Write($"Is '{username}' your username? (yes/no): ");
        string response = Console.ReadLine().ToLower();

        return response == "yes" || response == "y";
    }

    static int GetNumberOfSides()
    {
        int sides;

        do
        {
            Console.Write("Enter the number of sides on the die (4, 6, 8, 10, 12, 20, 100) or 'x' to exit: ");
            string input = Console.ReadLine().ToLower();

            if (input == "x" || input == "exit" || input == "quit" || input == "q")
                ExitProgram();

            if (int.TryParse(input, out sides) && (sides == 4 || sides == 6 || sides == 8 || sides == 10 || sides == 12 || sides == 20 || sides == 100))
                return sides;

            Console.WriteLine("Invalid input. Please enter a valid number of sides.");
        } while (true);
    }

    static int RollDice(int sides)
    {
        Random random = new Random();
        return random.Next(1, sides + 1);
    }

    static bool RollAgainPrompt()
    {
        do
        {
            Console.Write("Roll again? (yes/no/change/exit): ");
            string input = Console.ReadLine().ToLower();

            if (input == "yes" || input == "y")
                return true;
            else if (input == "no" || input == "n")
                return ExitOrChangeUsernamePrompt();
            else if (input == "change" || input == "c")
                break;
            else if (input == "exit" || input == "x" || input == "quit" || input == "q")
                ExitProgram();
            else
                Console.WriteLine("Invalid input. Please enter a valid option.");

        } while (true);

        return true;
    }

    static bool ExitOrChangeUsernamePrompt()
    {
        do
        {
            Console.Write("Do you want to exit or change username? (exit/change): ");
            string input = Console.ReadLine().ToLower();

            if (input == "exit" || input == "x")
                ExitProgram();
            else if (input == "change" || input == "c")
                return false;
            else
                Console.WriteLine("Invalid input. Please enter a valid option.");

        } while (true);

        return false;
    }

    static void ExitProgram()
    {
        Console.WriteLine("Goodbye!");
        Environment.Exit(0);
    }
}
