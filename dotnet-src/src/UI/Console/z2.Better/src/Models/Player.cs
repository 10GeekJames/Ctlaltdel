using System.Drawing;

namespace Ctlaltdel.Models;
public class Player
{
    public string Name { get; set; }
    public Point Location { get; private set; }

    private Player() { }

    public Player(Point location, string? name = "")
    {
        Location = location;
        Name = name;
    }

    public void MoveLocation(int x, int y)
    {
        Location = new Point(Location.X + x, Location.Y + y);
    }
}
