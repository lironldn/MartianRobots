namespace MartianRobots.AcceptanceTests;
using MartianRobots;

[TestFixture]
public class AccTests
{
    [Test]
    public void RobotsOnMars()
    {
        var parser = new FileParser(".\\AccTest.txt");
        var sut = new MartianRobotsRunner(parser);
        sut.Run();
    }
}