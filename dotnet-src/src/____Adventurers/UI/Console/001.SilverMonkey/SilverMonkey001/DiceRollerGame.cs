using System;

class DiceRollerGame
{
    private string username;
    private int sides;

    public DiceRollerGame()
    {
        username = GetUsername();
        sides = 6; // Default die has 6 sides
    }

    private string GetUsername()
    {
        Console.Write("Enter your username: ");
        string input = Console.ReadLine();
        return ValidateUsername(input);
    }

    private string ValidateUsername(string username)
    {
        while (string.IsNullOrWhiteSpace(username))
        {
            Console.WriteLine("Invalid username. Please enter a valid username.");
            Console.Write("Enter your username: ");
            username = Console.ReadLine();
        }
        return username;
    }

    private int RollDie()
    {
        Random random = new Random();
        return random.Next(1, sides + 1);
    }

    public void StartGame()
    {
        while (true)
        {
            Console.WriteLine($"Welcome, {username}! You are using a {sides}-sided die.");

            int result = RollDie();
            Console.WriteLine($"You rolled a {result}.");

            string input = GetMenuInput();

            switch (input)
            {
                case "a":
                    username = GetUsername();
                    break;
                case "c":
                    sides = GetValidDiceSides();
                    break;
                case "r":
                    // Default behavior, no change needed
                    break;
                case "s":
                    username = GetUsername();
                    sides = 6; // Reset to default die with 6 sides
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

    private int GetValidDiceSides()
    {
        int[] validSides = { 4, 6, 8, 10, 12, 20 };

        while (true)
        {
            Console.Write("Enter the number of sides for the die (4, 6, 8, 10, 12, 20): ");
            if (int.TryParse(Console.ReadLine(), out int inputSides) && Array.IndexOf(validSides, inputSides) != -1)
            {
                return inputSides;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number of sides.");
            }
        }
    }

    private string GetMenuInput()
    {
        Console.Write("(a)lter name, (c)hange die, (r)eroll as default, (s)tart over, (e)xit or (q)uit: ");
        return Console.ReadLine().ToLower();
    }
}

class Program
{
    static void Main()
    {
        DiceRollerGame game = new DiceRollerGame();
        game.StartGame();
    }
}
