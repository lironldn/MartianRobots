namespace MartianRobots
{
    public interface IMartianMap<T> where T : IRobot
    {
        void Add(T item);
        bool IsInsideMap(int x, int y);
        bool Move(T robot, int toX, int toY);
    }
}