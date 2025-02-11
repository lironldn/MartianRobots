namespace MartianRobots;

public class Robot : IRobot
{

    private static readonly List<Direction> Directions = new List<Direction>
    {
        new Direction("N", 0, 1),
        new Direction("E", 1, 0),
        new Direction("S", 0, -1),
        new Direction("W", -1, 0)
    };

    public Guid Id { get; } = Guid.NewGuid();
    public int X { get; private set; }
    public int Y { get; private set; }
    public Direction Direction { get; private set; }
    public bool IsLost { get; private set; } = false;

    public Robot(IMartianMap<IRobot> map, int x, int y, string direction)
    {
        X = x;
        Y = y;
        Direction = Directions.First(d => d.Name == direction);
        map.Add(this);
    }

    public bool MoveForward(IMartianMap<IRobot> map)
    {
        if (IsLost) return false;

        var newX = X + Direction.XDiff;
        var newY = Y + Direction.YDiff;
        if (map.IsInsideMap(newX, newY))
        {
            map.Move(this, newX, newY);
            X = newX;
            Y = newY;
            return true;
        }
        if (map.HeavenScent(X, Y))
        {
            return false;
        }

        IsLost = true;
        return false;
    }

    public void TurnLeft()
    {
        var currDirectionIndex = Directions.IndexOf(Direction);
        var newDirectionIndex = (currDirectionIndex + 3) % 4;
        Direction = Directions[newDirectionIndex];
    }

    public void TurnRight()
    {
        var currDirectionIndex = Directions.IndexOf(Direction);
        var newDirectionIndex = (currDirectionIndex + 1) % 4;
        Direction = Directions[newDirectionIndex];
    }

    public override string ToString() => $"{X} {Y} {Direction.Name}" + (IsLost ? " LOST" : "");
}
