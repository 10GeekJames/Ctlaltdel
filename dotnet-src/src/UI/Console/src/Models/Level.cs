namespace Ctlaltdel.Models;
public class Level
{
    public int WidthX { get; init; }
    public int DepthY { get; init; }
    private List<Room> _rooms = new();
    public IEnumerable<Room> Rooms => _rooms.AsReadOnly();

    private Level() { }
    public Level(int widthX, int depthY)
    {
        if(widthX < 0) {
            throw new Exception("Level width must be greater than zero");
        }
        if(DepthY < 0) {
            throw new Exception("Level depth must be greater than zero");
        }
        WidthX = widthX;
        DepthY = depthY;
        InitLevel();
    }
    private void InitLevel()
    {
        for (var x = 0; x < WidthX; x++)
        {
            for (var y = 0; y < DepthY; y++) {
                _rooms.Add(new Room(new System.Drawing.Point(x,y)));
            }
        }
    }
}
