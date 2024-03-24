using System;

public static class Kim
{
    static string GetUsername()
    {
        Console.Write("Enter your username: ");
        return Console.ReadLine();
    }

    static string ChangeUsername()
    {
        Console.Write("Do you want to change your username? (yes/no): ");
        string input = Console.ReadLine().ToLower();

        if (input.Equals("yes") || input.Equals("y"))
        {
            return GetUsername();
        }
        else if (input.Equals("exit") || input.Equals("x"))
        {
            Environment.Exit(0);
        }

        return null;
    }

    static int GetValidDiceSides()
    {
        int[] validSides = { 4, 6, 8, 10, 12, 20, 100 };

        while (true)
        {
            Console.Write("Enter the number of sides for the die (4, 6, 8, 10, 12, 20, 100): ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int sides) && Array.IndexOf(validSides, sides) != -1)
            {
                return sides;
            }
            else if (input.Equals("exit") || input.Equals("x"))
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number of sides.");
            }
        }
    }

    static int RollDie(int sides)
    {
        Random random = new Random();
        return random.Next(1, sides + 1);
    }

    static bool ShouldRollAgain()
    {
        while (true)
        {
            Console.Write("Do you want to roll again? (yes/no): ");
            string input = Console.ReadLine().ToLower();

            if (input.Equals("yes") || input.Equals("y"))
            {
                return true;
            }
            else if (input.Equals("no") || input.Equals("n"))
            {
                return false;
            }
            else if (input.Equals("exit") || input.Equals("x"))
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
            }
        }
    }

    public static void Run()
    {
        string username = GetUsername();
        Console.WriteLine($"Welcome, {username}!");

        while (true)
        {
            username = ChangeUsername();
            if (username != null)
            {
                Console.WriteLine($"Username updated to: {username}");
            }

            int sides = GetValidDiceSides();
            int result = RollDie(sides);

            Console.WriteLine($"You rolled a {result} with a {sides}-sided die.");

            if (!ShouldRollAgain())
            {
                sides = GetValidDiceSides();
            }
        }
    }
}
