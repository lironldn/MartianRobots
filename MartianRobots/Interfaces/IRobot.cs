namespace MartianRobots.Interfaces;

public interface IRobot
{
    Guid Id { get; }
    int X { get; }
    int Y { get; }
    bool IsLost { get; }
    bool MoveForward(IMartianMap<IRobot> map);
    void TurnLeft();
    void TurnRight();
}
