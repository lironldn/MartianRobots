namespace MartianRobots;

public class Direction
{
    public string Name { get; }
    public int XDiff { get; }
    public int YDiff { get; }

    public Direction(string name, int xDiff, int yDiff)
    {
        this.Name = name;
        this.XDiff = xDiff;
        this.YDiff = yDiff;
    }
}
