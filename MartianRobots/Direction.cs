namespace MartianRobots;

public class Direction
{
    public string Name { get; } // this will be 'N', 'E', 'S', or 'W'
    public int XDelta { get; }
    public int YDelta { get; }

    public Direction(string name, int xDelta, int yDelta)
    {
        this.Name = name;
        this.XDelta = xDelta;
        this.YDelta = yDelta;
    }
}
