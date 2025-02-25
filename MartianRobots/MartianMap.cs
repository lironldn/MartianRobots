using MartianRobots.Interfaces;

namespace MartianRobots;

public class MartianMap<T>(int xDimension, int yDimension) : IMartianMap<T>
    where T : IRobot
{
    private readonly IList<T>[,] map = new IList<T>[xDimension, yDimension];

    public void Add(T item)
    {
        if (!IsInsideMap(item.X, item.Y))
        {
            throw new InvalidOperationException("Adding robot outside of map");
        }
        map[item.X, item.Y] ??= [];
        map[item.X, item.Y].Add(item);
    }

    public bool IsInsideMap(int x, int y)
    {
        return x >= 0 && x < xDimension && y >= 0 && y < yDimension;
    }

    public bool HeavenScent(int x, int y) => map[x, y].Any(r => r.IsLost);

    public bool Move(T robot, int toX, int toY)
    {
        if (IsInsideMap(toX, toY))
        {
            map[robot.X, robot.Y].Remove(robot);
            map[toX, toY] ??= [];
            map[toX, toY].Add(robot);
            return true;
        }

        return false;
    }
}
