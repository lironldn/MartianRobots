using MartianRobots;
using FluentAssertions;

namespace MartianRobotsTests
{
    [TestFixture]
    public class MartianMapTests
    {
        [TestCase(3, 5, 0, 0, true)]
        [TestCase(3, 5, 1, 1, true)]
        [TestCase(3, 5, 2, 4, true)]
        [TestCase(3, 5, 2, 5, false)]
        [TestCase(3, 5, 3, 4, false)]
        [TestCase(3, 5, -1, 4, false)]
        [TestCase(3, 5, 0, -1, false)]
        public void IsInsideMap(int dimX, int dimY, int x, int y, bool expected)
        {
            var map = new MartianMap<Robot>(dimX, dimY);
            map.IsInsideMap(x, y).Should().Be(expected);
        }
    }
}