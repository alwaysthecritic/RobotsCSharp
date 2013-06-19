using System;
using NUnit.Framework;
using OpenTableRobots;
using System.Collections.Generic;

namespace OpenTableRobotsTest {

    [TestFixture]
    public class ConfigParserTest {

        [Test]
        public void ConfigParses() {
            string[] lines = { "5 5", "1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM" };
            var config = new ConfigParser().Parse(lines);

            Assert.AreEqual(5, config.Grid.MaxX);
            Assert.AreEqual(5, config.Grid.MaxY);

            Assert.AreEqual(2, config.Missions.Count);

            AssertMission(config.Missions[0], 1, 2, Direction.N, "LMLMLMLMM");
            AssertMission(config.Missions[1], 3, 3, Direction.E, "MMRMMRMRRM");
        }

        private void AssertMission(Mission mission, int x, int y, Direction facing, string commands) {
            Assert.AreEqual(x, mission.Robot.X);
            Assert.AreEqual(y, mission.Robot.Y);
            Assert.AreEqual(facing, mission.Robot.Facing);
            Assert.AreEqual(commands, mission.Commands);
        }
    }
}

