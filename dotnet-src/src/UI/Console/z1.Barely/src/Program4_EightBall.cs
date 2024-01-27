public class Program4
{
    public void Run()
    {
        // lets build a magic 8 ball
        string eightBallMachineName;

        string answer1 = "Definitely";
        string answer2 = "Definitely";

        // ask for the clown's name
        eightBallMachineName = Console.ReadLine();

        // print out the clown's name
        Console.WriteLine($"Well met: {eightBallMachineName}");
        
        Console.ReadKey();
    }
}