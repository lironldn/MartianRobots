namespace MartianRobots;

public interface IRobot
{
    bool MoveForward(MartianMap<IRobot> map);
    void TurnLeft(MartianMap<IRobot> map);
    void TurnRight(MartianMap<IRobot> map);
}
