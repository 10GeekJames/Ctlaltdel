using System.Drawing;

namespace Ctlaltdel.Models;
public class Room
{
    public Level Level { get; private set; }
    public Point Point { get; init; }
    public string RoomName { get; private set; }
    public string RoomDescription { get; private set; }
    public bool IsPassable { get; private set; } = true;
    private Room() { }
    public Room(Point point, bool? isPassable = true)
    {
        Point = point;
        IsPassable = isPassable.Value;
    }
    public void SetRoomName(string roomName) {
        RoomName = roomName;
    }
    public void SetRoomDescription(string roomDescription)
    {
        RoomDescription = roomDescription;
    }
}