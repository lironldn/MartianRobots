using MartianRobots;
using MartianRobots.IO;

if (Environment.GetCommandLineArgs().Length > 1)
{
    var runner = new MartianRobotsRunner(new FileParser(Environment.GetCommandLineArgs()[1]), new ConsoleWriter());
    runner.Run();
    return;
}
Console.WriteLine("Please provide a file path as an argument.");