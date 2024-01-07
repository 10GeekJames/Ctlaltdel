using System.Drawing;

namespace Ctlaltdel.Models;
public class Player
{
    public string Name { get; set; }
    public Point Position { get; private set; }

    private Player() { }

    public Player(Point position, string? name = "")
    {
        Position = position;
        Name = name;
    }

    public void MovePosition(int x, int y)
    {
        Position = new Point(Position.X + x, Position.Y + y);
    }
}
