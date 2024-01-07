public class Program1
{
    public void Run()
    {
        ConsoleKey? lastInput = null;

        while (true)
        {

            Console.Clear();
            if (lastInput is not null)
            {
                Console.WriteLine($"Your last input was {lastInput}");
                Console.WriteLine("What is your next input?");
            }
            else
            {
                Console.WriteLine("What is your input?");
            }

            var input = Console.ReadKey();
            lastInput = input.Key;

            if (lastInput == ConsoleKey.Q)
            {
                break;
            }
        }

        Console.WriteLine("Thank you for playing!");
    }
}