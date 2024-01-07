namespace Ctlaltdel.Models;
public class Level
{
    public int WidthX { get; set; }
    public int DepthY { get; set; }
    public List<Room> Rooms {get;set;} = new ();
}
