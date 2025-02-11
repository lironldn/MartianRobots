namespace MartianRobots;

public class Direction
{
    public string Name { get; }
    public int xDiff { get; }
    public int yDiff { get; }

    public Direction(string name, int xDiff, int yDiff)
    {
        this.Name = name;
        this.xDiff = xDiff;
        this.yDiff = yDiff;
    }
}
