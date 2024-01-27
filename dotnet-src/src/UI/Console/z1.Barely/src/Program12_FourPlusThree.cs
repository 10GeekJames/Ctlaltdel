public class Program12
{
    public void Run()
    {
        // lets build a magic 8 ball
        string eightBallMachineName;

        string answer1 = "Definitely";
        string answer2 = "Try again";
        string answer3 = "I think I heard that somewhere";
        string answer4 = "It is unclear";
        string answer5 = "Probably Not";

        // ask for the clown's name
        eightBallMachineName = Console.ReadLine();

        // print out the clown's name
        Console.WriteLine($"Well met: {eightBallMachineName}");

        while(true) {
            var lastInput = Console.ReadKey();
            
        }
        
        Console.ReadKey();
    }
}