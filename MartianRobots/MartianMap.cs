using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobots;

public class MartianMap<T> : IMartianMap<T> where T : IRobot
{
    private int xDim;
    private int yDim;
    private IList<T>[,] map;

    public MartianMap(int xDim, int yDim)
    {
        this.xDim = xDim;
        this.yDim = yDim;
        map = new List<T>[xDim, yDim];
    }

    public void Add(T item)
    {
        if (!IsInsideMap(item.X, item.Y))
        {
            throw new InvalidOperationException("Adding robot outside of map");
        }
        if (map[item.X, item.Y] == null)
        {
            map[item.X, item.Y] = new List<T>();
        }
        map[item.X, item.Y].Add(item);
    }

    public bool IsInsideMap(int x, int y)
    {
        return x >= 0 && x < xDim && y >= 0 && y < yDim;
    }

    public bool Move(T robot, int toX, int toY)
    {
        if (IsInsideMap(toX, toY))
        {
            map[robot.X, robot.Y].Remove(robot);
            if (map[toX, toY] == null)
            {
                map[toX, toY] = new List<T>();
            }
            map[toX, toY].Add(robot);
            return true;
        }

        // TODO: handle falling off the map

        return false;
    }
}
