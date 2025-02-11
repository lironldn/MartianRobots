namespace MartianRobots;

public class ConsoleParser : IParser
{
    public string? ReadLine()
    {
        return Console.ReadLine();
    }

    public string WriteLine(string line)
    {
        Console.WriteLine(line);
        return line;
    }
}
