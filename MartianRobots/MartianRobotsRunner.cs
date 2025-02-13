using MartianRobots.Interfaces;
using MartianRobots.IO;

namespace MartianRobots;

public class MartianRobotsRunner
{
    public MartianRobotsRunner(IParser parser, IWriter writer)
    {
        Parser = parser;
        Writer = writer;
    }

    public IParser Parser { get; }
    public IWriter Writer { get; }

    public void Run()
    {
        var dimline = Parser.ReadLine();
        if (dimline == null)
        {
            return;
        }

        string[] dims = dimline.Split(' ');
        int x = int.Parse(dims[0]) + 1; // the right coordinates of the map
        int y = int.Parse(dims[1]) + 1; // the top coordinates of the map
        var map = new MartianMap<IRobot>(x, y);

        var robots = new List<IRobot>();

        while (true)
        {
            var startPosStr = Parser.ReadLine();
            while (startPosStr?.Trim() == string.Empty) startPosStr = Parser.ReadLine();
            if (startPosStr == null)
            {
                break;
            }
            string[] startPos = startPosStr.Split(' ');
            int xStart = int.Parse(startPos[0].ToString());
            int yStart = int.Parse(startPos[1].ToString());
            string direction = startPos[2].ToString();
            var robot = new Robot(map, xStart, yStart, direction);
            robots.Add(robot);
            var instructions = Parser.ReadLine();
            while (instructions?.Trim() == string.Empty) instructions = Parser.ReadLine();
            if (instructions == null)
            {
                break;
            }

            foreach (char instruction in instructions)
            {
                switch ($"{instruction}".ToUpperInvariant())
                {
                    case "L":
                        robot.TurnLeft();
                        break;
                    case "R":
                        robot.TurnRight();
                        break;
                    case "F":
                        robot.MoveForward();
                        break;
                    default:
                        throw new InvalidOperationException("Invalid instruction");
                }
            }
        }

        foreach (var robot in robots)
        {
            Writer.WriteLine(robot.ToString() ?? "");
        }
    }
}

