namespace MartianRobots.Interfaces;

public interface IRobot
{
    Guid Id { get; }
    int X { get; }
    int Y { get; }
    bool IsLost { get; }
    bool MoveForward();
    void TurnLeft();
    void TurnRight();
}
