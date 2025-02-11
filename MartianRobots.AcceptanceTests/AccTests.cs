namespace MartianRobots.AcceptanceTests;
using MartianRobots;
using MartianRobots.IO;
using Moq;

[TestFixture]
public class AccTests
{
    [Test]
    public void RobotsOnMars()
    {
        var parser = new FileParser(".\\AccTest.txt");
        var writer = Mock.Of<IWriter>();
        var sut = new MartianRobotsRunner(parser, writer);
        sut.Run();
        Mock.Get(writer).Verify(w => w.WriteLine("1 1 E"), Times.Once);
        Mock.Get(writer).Verify(w => w.WriteLine("3 3 N LOST"), Times.Once);
        Mock.Get(writer).Verify(w => w.WriteLine("2 3 S"), Times.Once);
    }
}