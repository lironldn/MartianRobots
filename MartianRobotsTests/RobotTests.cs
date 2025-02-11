using FluentAssertions;
using MartianRobots;
using Moq;

[TestFixture]
public class RobotTests
{
    [TestCase("N", "W")]
    [TestCase("W", "S")]
    [TestCase("S", "E")]
    [TestCase("E", "N")]
    public void TurnLeft(string curr, string expected)
    {
        Robot robot = new Robot(new Mock<IMartianMap<IRobot>>().Object, 0, 0, curr);
        robot.TurnLeft();
        robot.Direction.Name.Should().Be(expected);
    }

    [TestCase("N", "E")]
    [TestCase("E", "S")]
    [TestCase("S", "W")]
    [TestCase("W", "N")]
    public void TurnRight(string curr, string expected)
    {
        Robot robot = new Robot(new Mock<IMartianMap<IRobot>>().Object, 0, 0, curr);
        robot.TurnRight();
        robot.Direction.Name.Should().Be(expected);
    }
}
