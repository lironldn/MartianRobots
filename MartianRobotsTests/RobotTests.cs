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

    [TestCase(0, 0, "N")]
    [TestCase(0, 0, "E")]
    [TestCase(1, 1, "S")]
    [TestCase(1, 1, "W")]
    public void MoveInsideMapSucceeds(int x, int y, string direction)
    {
        var map = new Mock<IMartianMap<IRobot>>();
        map.Setup(m => m.IsInsideMap(It.IsAny<int>(), It.IsAny<int>())).Returns(true);
        map.Setup(m => m.Move(It.IsAny<IRobot>(), It.IsAny<int>(), It.IsAny<int>())).Returns(true);
        Robot robot = new Robot(map.Object, x, y, direction);
        robot.MoveForward(map.Object).Should().BeTrue();
    }

    [TestCase(0, 0, "N")]
    [TestCase(0, 0, "E")]
    [TestCase(1, 1, "S")]
    [TestCase(1, 1, "W")]
    public void MoveOutsideMapRobotIsLost(int x, int y, string direction)
    {
        var map = new Mock<IMartianMap<IRobot>>();
        map.Setup(m => m.IsInsideMap(It.IsAny<int>(), It.IsAny<int>())).Returns(false);
        map.Setup(m => m.HeavenScent(It.IsAny<int>(), It.IsAny<int>())).Returns(false);
        map.Setup(m => m.Move(It.IsAny<IRobot>(), It.IsAny<int>(), It.IsAny<int>())).Returns(false);
        Robot robot = new Robot(map.Object, x, y, direction);
        robot.MoveForward(map.Object).Should().BeFalse();
        robot.IsLost.Should().BeTrue();
    }

    [TestCase(0, 0, "N")]
    [TestCase(0, 0, "E")]
    [TestCase(1, 1, "S")]
    [TestCase(1, 1, "W")]
    public void MoveOutsideMapWithScentRobotStaysPut(int x, int y, string direction)
    {
        var map = new Mock<IMartianMap<IRobot>>();
        map.Setup(m => m.IsInsideMap(It.IsAny<int>(), It.IsAny<int>())).Returns(false);
        map.Setup(m => m.HeavenScent(It.IsAny<int>(), It.IsAny<int>())).Returns(true);
        map.Setup(m => m.Move(It.IsAny<IRobot>(), It.IsAny<int>(), It.IsAny<int>())).Returns(false);
        Robot robot = new Robot(map.Object, x, y, direction);
        robot.MoveForward(map.Object).Should().BeFalse();
        robot.IsLost.Should().BeFalse();
    }
}
