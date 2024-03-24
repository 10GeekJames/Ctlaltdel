using System;

public static class James
{
    static string GetUsername()
    {
        Console.Write("Enter your username: ");
        return Console.ReadLine();
    }

    static string ValidateUsername(string username)
    {
        while (string.IsNullOrWhiteSpace(username))
        {
            Console.WriteLine("Invalid username. Please enter a valid username.");
            Console.Write("Enter your username: ");
            username = Console.ReadLine();
        }
        return username;
    }

    static int GetValidDiceSides()
    {
        int maxSides = 5000;

        while (true)
        {
            Console.Write($"Enter the number of sides for the die (1-{maxSides}): ");
            if (int.TryParse(Console.ReadLine(), out int sides) && sides > 0 && sides <= maxSides)
            {
                return sides;
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

    public static void Run()
    {
        string username = ValidateUsername(GetUsername());
        int sides = GetValidDiceSides();

        while (true)
        {
            int result = RollDie(sides);
            Console.WriteLine($"{username}, rolled a {sides}-sided die, and got a result: {result}");

            Console.Write("(a)lter name, (c)hange die, (r)eroll as default, (s)tart over, (e)xit or (q)uit: ");
            string input = Console.ReadLine().ToLower();

            switch (input)
            {
                case "a":
                    username = ValidateUsername(GetUsername());
                    break;
                case "c":
                    sides = GetValidDiceSides();
                    break;
                case "r":
                    // Default behavior, no change needed
                    break;
                case "s":
                    username = ValidateUsername(GetUsername());
                    sides = GetValidDiceSides();
                    break;
                case "e":
                case "q":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid input. Please enter a valid option.");
                    break;
            }
        }
    }
}
