using System;

class Player
{
    public string Username { get; private set; }

    public Player(string username)
    {
        SetUsername(username);
    }

    public void SetUsername(string username)
    {
        while (string.IsNullOrWhiteSpace(username))
        {
            Console.WriteLine("Invalid username. Please enter a valid username.");
            Console.Write("Enter your username: ");
            username = Console.ReadLine();
        }
        Username = username;
    }
}

class DiceRoller
{
    public int Sides {get;set;}

    public DiceRoller(int sides)
    {
        SetSides(sides);
    }

    public void SetSides(int sides)
    {
        const int maxSides = 5000;

        while (sides <= 0 || sides > maxSides)
        {
            Console.Write($"Enter the number of sides for the die (1-{maxSides}): ");
            if (int.TryParse(Console.ReadLine(), out int inputSides) && inputSides > 0 && inputSides <= maxSides)
            {
                Sides = inputSides;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number of sides.");
            }
        }
    }

    public int RollDie()
    {
        Random random = new Random();
        return random.Next(1, Sides + 1);
    }
}

class MenuSystem
{
    public string GetUserInput()
    {
        Console.Write("(a)lter name, (c)hange die, (r)eroll as default, (s)tart over, (e)xit or (q)uit: ");
        return Console.ReadLine().ToLower();
    }
}

class GameController
{
    private Player player;
    private DiceRoller diceRoller;
    private MenuSystem menuSystem;

    public GameController()
    {
        player = new Player(GetUsername());
        diceRoller = new DiceRoller(GetDiceSides());
        menuSystem = new MenuSystem();
    }

    private string GetUsername()
    {
        Console.Write("Enter your username: ");
        return Console.ReadLine();
    }

    private int GetDiceSides()
    {
        Console.Write("Enter the number of sides for the die: ");
        return int.Parse(Console.ReadLine());
    }

    public void RunGame()
    {
        while (true)
        {
            int result = diceRoller.RollDie();
            Console.WriteLine($"{player.Username}, rolled a {diceRoller.Sides}-sided die, and got a result: {result}");

            string input = menuSystem.GetUserInput();

            switch (input)
            {
                case "a":
                    player.SetUsername(GetUsername());
                    break;
                case "c":
                    diceRoller.SetSides(GetDiceSides());
                    break;
                case "r":
                    // Default behavior, no change needed
                    break;
                case "s":
                    player.SetUsername(GetUsername());
                    diceRoller.SetSides(GetDiceSides());
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

public static class OO
{
    public static void Run()
    {
        Console.WriteLine("Welcome to the Die Roller!");

        GameController gameController = new GameController();
        gameController.RunGame();
    }
}
