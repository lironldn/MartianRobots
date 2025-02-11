using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobots;

public class MartianMap<T> where T : IRobot
{
    private int xDim;
    private int yDim;
    private T[,] map;

    public MartianMap(int xDim, int yDim)
    {
        this.xDim = xDim;
        this.yDim = yDim;
        map = new T[xDim, yDim];
    }

    public bool IsInsideMap(int x, int y)
    {
        return x >= 0 && x < xDim && y >= 0 && y < yDim;
    }
}
