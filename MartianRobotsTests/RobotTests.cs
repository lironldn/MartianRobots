using FluentAssertions;
using MartianRobots;
using MartianRobots.Interfaces;
using Moq;

namespace RobotTests;

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

    [TestCase(0, 0, "N", "0 1 N")]
    [TestCase(0, 0, "E", "1 0 E")]
    [TestCase(1, 1, "S", "1 0 S")]
    [TestCase(1, 1, "W", "0 1 W")]
    public void MoveInsideMapSucceeds(int x, int y, string direction, string newLoc)
    {
        var map = new Mock<IMartianMap<IRobot>>();
        map.Setup(m => m.IsInsideMap(It.IsAny<int>(), It.IsAny<int>())).Returns(true);
        map.Setup(m => m.Move(It.IsAny<IRobot>(), It.IsAny<int>(), It.IsAny<int>())).Returns(true);
        Robot robot = new Robot(map.Object, x, y, direction);
        robot.MoveForward().Should().BeTrue();
        robot.ToString().Should().Be(newLoc);
    }

    [TestCase(0, 0, "N", "0 0 N LOST")]
    [TestCase(0, 0, "E", "0 0 E LOST")]
    [TestCase(1, 1, "S", "1 1 S LOST")]
    [TestCase(1, 1, "W", "1 1 W LOST")]
    public void MoveOutsideMapRobotIsLost(int x, int y, string direction, string newLoc)
    {
        var map = new Mock<IMartianMap<IRobot>>();
        map.Setup(m => m.IsInsideMap(It.IsAny<int>(), It.IsAny<int>())).Returns(false);
        map.Setup(m => m.HeavenScent(It.IsAny<int>(), It.IsAny<int>())).Returns(false);
        map.Setup(m => m.Move(It.IsAny<IRobot>(), It.IsAny<int>(), It.IsAny<int>())).Returns(false);
        Robot robot = new Robot(map.Object, x, y, direction);
        robot.MoveForward().Should().BeFalse();
        robot.IsLost.Should().BeTrue();
        robot.ToString().Should().Be(newLoc);
    }

    [TestCase(0, 0, "N", "0 0 N")]
    [TestCase(0, 0, "E", "0 0 E")]
    [TestCase(1, 1, "S", "1 1 S")]
    [TestCase(1, 1, "W", "1 1 W")]
    public void MoveOutsideMapWithScentRobotStaysPut(int x, int y, string direction, string newLoc)
    {
        var map = new Mock<IMartianMap<IRobot>>();
        map.Setup(m => m.IsInsideMap(It.IsAny<int>(), It.IsAny<int>())).Returns(false);
        map.Setup(m => m.HeavenScent(It.IsAny<int>(), It.IsAny<int>())).Returns(true);
        map.Setup(m => m.Move(It.IsAny<IRobot>(), It.IsAny<int>(), It.IsAny<int>())).Returns(false);
        Robot robot = new Robot(map.Object, x, y, direction);
        robot.MoveForward().Should().BeFalse();
        robot.IsLost.Should().BeFalse();
        robot.ToString().Should().Be(newLoc);
    }

    [Test]
    public void LostRobotStaysPut()
    {
        var map = new Mock<IMartianMap<IRobot>>();
        map.Setup(m => m.IsInsideMap(It.IsAny<int>(), It.IsAny<int>())).Returns(false);
        map.Setup(m => m.HeavenScent(It.IsAny<int>(), It.IsAny<int>())).Returns(false);
        map.Setup(m => m.Move(It.IsAny<IRobot>(), It.IsAny<int>(), It.IsAny<int>())).Returns(false);
        Robot robot = new Robot(map.Object, 0, 0, "N");
        robot.MoveForward().Should().BeFalse();
        robot.IsLost.Should().BeTrue();
        robot.ToString().Should().Be("0 0 N LOST");
        robot.MoveForward().Should().BeFalse();
    }
}
