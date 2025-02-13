using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MartianRobots.Interfaces;

namespace MartianRobots;

public class MartianMap<T> : IMartianMap<T> where T : IRobot
{
    private int xDimension;
    private int yDimension;
    private IList<T>[,] map;

    public MartianMap(int xDimension, int yDimension)
    {
        this.xDimension = xDimension;
        this.yDimension = yDimension;
        map = new List<T>[xDimension, yDimension];
    }

    public void Add(T item)
    {
        if (!IsInsideMap(item.X, item.Y))
        {
            throw new InvalidOperationException("Adding robot outside of map");
        }
        if (map[item.X, item.Y] == null)
        {
            map[item.X, item.Y] = [];
        }
        map[item.X, item.Y].Add(item);
    }

    public bool IsInsideMap(int x, int y)
    {
        return x >= 0 && x < xDimension && y >= 0 && y < yDimension;
    }

    public bool HeavenScent(int x, int y) => map[x, y].Any(x => x.IsLost);

    public bool Move(T robot, int toX, int toY)
    {
        if (IsInsideMap(toX, toY))
        {
            map[robot.X, robot.Y].Remove(robot);
            if (map[toX, toY] == null)
            {
                map[toX, toY] = [];
            }
            map[toX, toY].Add(robot);
            return true;
        }

        return false;
    }
}
