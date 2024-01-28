using System.Drawing;

namespace Ctlaltdel.Models;
public class Room
{
    public Level Level { get; set; }
    public Point Location { get; set; }
    public string RoomName { get; set; }
    public string RoomDescription { get; set; }
    public bool IsPassable { get; set; } = true;    
}