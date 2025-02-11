namespace MartianRobots;

public interface IRobot
{
    Guid Id { get; }
    int X { get; }
    int Y { get; }
    bool IsLost { get; }
    bool MoveForward(MartianMap<IRobot> map);
    void TurnLeft(MartianMap<IRobot> map);
    void TurnRight(MartianMap<IRobot> map);
}
