using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace Robots {

    [TestFixture]
    public class ConfigParserTest {

        [Test]
        public void GoodConfigParses() {
            string[] lines = { "5 7", "1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM" };
            var config = new ConfigParser().Parse(lines);

            Assert.AreEqual(5, config.Grid.MaxX);
            Assert.AreEqual(7, config.Grid.MaxY);

            Assert.AreEqual(2, config.Missions.Count);

            AssertMission(config.Missions[0], 1, 2, Direction.N, "LMLMLMLMM");
            AssertMission(config.Missions[1], 3, 3, Direction.E, "MMRMMRMRRM");
        }

        [Test]
        public void TooShortConfigGivesException() {
            ConfigParsingException e = Assert.Throws<ConfigParsingException>(
                delegate { new ConfigParser().Parse(new string[] { "foo", "bar" }); } );

            Assert.AreEqual("Config needs at least 3 lines to be valid.", e.Message);
        }

        [Test]
        public void EvenNumberOfConfigLinesBiggerThanThreeGivesException() {
            ConfigParsingException e = Assert.Throws<ConfigParsingException>(
                delegate { new ConfigParser().Parse(new string[] { "foo", "bar", "woo", "war" }); } );

            Assert.AreEqual("Config is malformed - should have an odd number of lines.", e.Message);
        }

        [Test]
        public void BadGridDimsGivesException() {
            ConfigParsingException e = Assert.Throws<ConfigParsingException>(
                delegate { new ConfigParser().Parse(new string[] { "5 zz", "1 2 N", "LMLMLMLMM" }); } );

            Assert.AreEqual("Couldn't parse grid dimensions from text: 5 zz", e.Message);
        }

        [Test]
        public void BadRobotStartPosGivesException() {
            ConfigParsingException e = Assert.Throws<ConfigParsingException>(
                delegate { new ConfigParser().Parse(new string[] { "5 5", "1 zz N", "LMLMLMLMM" }); } );

            Assert.AreEqual("Couldn't parse robot start position from text: 1 zz N", e.Message);
        }

        [Test]
        public void BadRobotCommandsGivesException() {
            ConfigParsingException e = Assert.Throws<ConfigParsingException>(
                delegate { new ConfigParser().Parse(new string[] { "5 5", "1 2 N", "LMX" }); } );

            Assert.AreEqual("Couldn't parse robot commands from text: LMX", e.Message);
        }

        [Test]
        public void RobotWithTooManyCommandsGivesException() {
            var manyCommands = new String('L', ConfigParser.MaxCommands + 1);
            ConfigParsingException e = Assert.Throws<ConfigParsingException>(
                delegate { new ConfigParser().Parse(new string[] { "5 5", "1 2 N", manyCommands }); } );

            Assert.AreEqual("Couldn't parse robot commands from text: " + manyCommands, e.Message);
        }

        private void AssertMission(Mission mission, int x, int y, Direction facing, string commands) {
            Assert.AreEqual(x, mission.Robot.X);
            Assert.AreEqual(y, mission.Robot.Y);
            Assert.AreEqual(facing, mission.Robot.Facing);
            Assert.AreEqual(commands, mission.Commands);
        }
    }
}

