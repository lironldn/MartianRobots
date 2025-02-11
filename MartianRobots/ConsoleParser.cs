namespace MartianRobots;

public class ConsoleParser : IParser
{
    public string? ReadLine()
    {
        return Console.ReadLine();
    }
}
