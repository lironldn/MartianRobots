namespace MartianRobots;

public class Robot : IRobot
{
    public Guid Id { get; } = Guid.NewGuid();
    public int X { get; }
    public int Y { get; }
    public bool IsLost { get; } = false;

    public Robot(MartianMap<IRobot> map, int x, int y)
    {
        X = x;
        Y = y;
        map.Add(this);
    }

    public bool MoveForward(MartianMap<IRobot> map)
    {
        throw new NotImplementedException();
    }

    public void TurnLeft(MartianMap<IRobot> map)
    {
        throw new NotImplementedException();
    }

    public void TurnRight(MartianMap<IRobot> map)
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        throw new NotImplementedException();
    }
}
