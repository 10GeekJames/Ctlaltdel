public class Program3
{
    public void Run()
    {
        // lets build up a character sheet
        string name;
        string race;
        string characterClass;

        string backstory;
        
        Console.WriteLine("What shal thee be known by?  (character name)");
        name = Console.ReadLine();
        
        Console.WriteLine("What is your race?  (race name)");
        race = Console.ReadLine();
        
        Console.WriteLine("What is your character class?  (class name)");
        characterClass = Console.ReadLine();
        
        Console.WriteLine($@"Well met: 
{name}
{race}
{characterClass}
");

        Console.WriteLine("Press any key to quit");
        Console.ReadKey();
    }
}