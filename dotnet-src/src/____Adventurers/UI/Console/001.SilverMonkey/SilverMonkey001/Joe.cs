using System;

public static class Joe
{
    public static void Run()
    {
        Console.WriteLine("Welcome to the Dice Rolling Game!");

        string username = GetUsername();

        bool exitRequested = false;

        while (!exitRequested)
        {
            int numberOfSides = GetNumberOfSides();

            // Roll the dice
            int result = RollDice(numberOfSides);

            // Display the result and which die was used
            DisplayResult(username, result, numberOfSides);

            // Ask if they want to roll again or change username
            string userInput = GetUserInput("Do you want to roll again? (yes/no/change/exit): ");

            switch (userInput.ToLower())
            {
                case "yes":
                    break; // Continue with the loop
                case "no":
                    numberOfSides = GetNumberOfSides(); // Ask for the die number again
                    break;
                case "change":
                    username = GetUsername(); // Change username
                    break;
                case "exit":
                    exitRequested = ConfirmExit(); // Ask if sure to exit
                    break;
                default:
                    Console.WriteLine("Invalid input. Please enter 'yes', 'no', 'change', or 'exit'.");
                    break;
            }
        }

        Console.WriteLine("Thanks for playing! Goodbye.");
    }

    static string GetUsername()
    {
        Console.Write("Enter your username: ");
        string username = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(username))
        {
            Console.WriteLine("Username cannot be empty. Please enter a valid username.");
            Console.Write("Enter your username: ");
            username = Console.ReadLine();
        }

        Console.WriteLine($"Welcome, {username}!");
        return username;
    }

    static int GetNumberOfSides()
    {
        int[] validSides = { 4, 6, 8, 10, 12, 20, 100 };
        int numberOfSides;

        while (true)
        {
            Console.Write("Enter the number of sides on the die (4, 6, 8, 10, 12, 20, 100): ");
            string input = Console.ReadLine();

            if (input.ToLower() == "exit" || input.ToLower() == "x")
                Environment.Exit(0);

            if (int.TryParse(input, out numberOfSides) && Array.Exists(validSides, element => element == numberOfSides))
            {
                return numberOfSides;
            }

            Console.WriteLine("Invalid input. Please enter a valid number of sides.");
        }
    }

    static int RollDice(int numberOfSides)
    {
        Random random = new Random();
        return random.Next(1, numberOfSides + 1);
    }

    static void DisplayResult(string username, int result, int numberOfSides)
    {
        Console.WriteLine($"{username}, you rolled a {result} on a {numberOfSides}-sided die.");

        if (numberOfSides == 20 && result == 20)
        {
            Console.WriteLine("***** Congrats on the Nat20! *****");
        }
    }

    static string GetUserInput(string message)
    {
        Console.Write(message);
        string input = Console.ReadLine();

        if (input.ToLower() == "exit" || input.ToLower() == "x")
            Environment.Exit(0);

        return input;
    }

    static bool ConfirmExit()
    {
        string input = GetUserInput("Are you sure you want to exit? (yes/no): ");

        return input.ToLower() == "yes";
    }
}
