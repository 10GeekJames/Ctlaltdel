using System.Drawing;
using System.Text;
using Ctlaltdel.Models;

var level = new Level();
level.DepthY = 20;
level.WidthX = 20;

for (var x = 0; x < 20; x++)
{
    for (var y = 0; y < 20; y++)
    {
        var room = new Room();
        room.Location = new Point(x, y);
        level.Rooms.Add(room);
    }
}

var player = new Player();
player.Location = new Point(10, 10);

var instructions = "wasd, or arrow keys to move, q to quit";

var feedbackMessage = "";

ConsoleKey? lastInput = null;

while (true)
{
    Console.Clear();

    var visualMap = new StringBuilder();

    for (var x = 0; x < level.WidthX; x++)
    {
        for (var y = 0; y < level.DepthY; y++)
        {
            var room = level.Rooms.FirstOrDefault(rs => rs.Location.X == x && rs.Location.Y == y);
            if (player.Location.X == x && player.Location.Y == y)
            {
                visualMap.Append("x ");
            }
            else if (room.IsPassable)
            {
                visualMap.Append(". ");
            }
            else
            {
                visualMap.Append("@ ");
            }
        }
        visualMap.AppendLine();
    }

    Console.WriteLine(visualMap.ToString());

    if (feedbackMessage != "")
    {
        Console.WriteLine($"{feedbackMessage}");
        feedbackMessage = "";
    }

    Console.WriteLine(instructions);

    var input = Console.ReadKey();
    lastInput = input.Key;

    if (lastInput == ConsoleKey.Q)
    {
        break;
    }

    switch (lastInput)
    {
        case ConsoleKey.W:
        case ConsoleKey.UpArrow:
            {
                feedbackMessage = AttemptToMove(-1, 0);
                break;
            }

        case ConsoleKey.D:
        case ConsoleKey.RightArrow:
            {
                feedbackMessage = AttemptToMove(0, 1);
                break;
            }

        case ConsoleKey.S:
        case ConsoleKey.DownArrow:
            {
                feedbackMessage = AttemptToMove(1, 0);
                break;
            }

        case ConsoleKey.A:
        case ConsoleKey.LeftArrow:
            {
                feedbackMessage = AttemptToMove(0, -1);
                break;
            }
    }
}

Console.WriteLine("Thank you for playing!");

string AttemptToMove(int x, int y)
{
    var errorMessage = "";
    var currentRoom = level.Rooms.SingleOrDefault(rs => rs.Location.X == player.Location.X && rs.Location.Y == player.Location.Y);
    var nextRoom = level.Rooms.SingleOrDefault(rs => rs.Location.X == player.Location.X + x && rs.Location.Y == player.Location.Y + y);
    if (nextRoom is null || !nextRoom.IsPassable)
    {
        errorMessage = "Cannot move that direction, -1hp";
    }
    else
    {
        MovePosition(x, y);
    }
    return errorMessage;
}

void MovePosition(int x, int y)
{
    player.Location = new Point(player.Location.X + x, player.Location.Y + y);
}

