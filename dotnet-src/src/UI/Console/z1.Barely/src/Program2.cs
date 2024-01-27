public class Program2
{
    public void Run()
    {

        var iAmANumber = 123;
        var iAmAString = "123";

        var addedNumber = iAmANumber + iAmANumber;
        var addedString = iAmAString + iAmAString;

        Console.WriteLine($"{addedNumber}, {addedString}");

        var x = 9;
        while (x >= 0)
        {
            Console.WriteLine(x);

            if (x == 0)
            {
                Console.WriteLine("Finished X");
            }
            x--;
        }

        for (var y = 0; y < 10; y++)
        {
            Console.WriteLine(y);

            if (y == 9)
            {
                Console.WriteLine("Finished Y");
            }
        }

        Console.WriteLine("Supper, BRB!!!!!!!");

        //program1.Run();

    }
}