using System;
using NUnit.Framework;
using OpenTableRobots;
using System.Collections.Generic;

namespace OpenTableRobotsTest {

    [TestFixture]
    public class Test {

        [Test]
        public void Battle1() {
            var config = new Config(5, 5)
                    .AddMission(1, 2, Direction.N, "LMLMLMLMM")
                    .AddMission(3, 3, Direction.E, "MMRMMRMRRM");

            var battle = new Battle(config);
            var results = battle.Run();

            Assert.AreEqual(2, results.Count);
            AssertRobot(results[0], 1, 3, Direction.N);
            AssertRobot(results[1], 5, 1, Direction.E);
        }

        [Test]
        public void Battle2() {
            var config = new Config(3, 3)
                    .AddMission(0, 0, Direction.E, "MMLMRMLMM")
                    .AddMission(3, 3, Direction.S, "MRMRMLMLMMRRMLMRM");

            var battle = new Battle(config);
            var results = battle.Run();

            Assert.AreEqual(2, results.Count);
            AssertRobot(results[0], 3, 3, Direction.N);
            AssertRobot(results[1], 0, 3, Direction.N);
        }

        [Test]
        public void CanUseSameConfigTwice() {
            var config = new Config(3, 3)
                .AddMission(0, 0, Direction.E, "MMLMRMLMM")
                    .AddMission(3, 3, Direction.S, "MRMRMLMLMMRRMLMRM");

            // Use same config twice, expecting that it doesn't affect second run (config is not mutated).
            new Battle(config).Run();
            var battle = new Battle(config);
            var results = battle.Run();

            Assert.AreEqual(2, results.Count);
            AssertRobot(results[0], 3, 3, Direction.N);
            AssertRobot(results[1], 0, 3, Direction.N);
        }

        [Test]
        public void RobotCannotFallOffInAnyDirection() {
            var config = new Config(1, 1)
                    .AddMission(0, 0, Direction.N, "MMMM")
                    .AddMission(0, 0, Direction.E, "MMMM")
                    .AddMission(0, 0, Direction.S, "MMMM")
                    .AddMission(0, 0, Direction.W, "MMMM");

            var battle = new Battle(config);
            var results = battle.Run();

            Assert.AreEqual(4, results.Count);
            AssertRobot(results[0], 0, 1, Direction.N);
            AssertRobot(results[1], 1, 0, Direction.E);
            AssertRobot(results[2], 0, 0, Direction.S);
            AssertRobot(results[3], 0, 0, Direction.W);
        }

        private void AssertRobot(Robot robot, int x, int y, Direction facing) {
            Assert.AreEqual(x, robot.X);
            Assert.AreEqual(y, robot.Y);
            Assert.AreEqual(facing, robot.Facing);
        }
    }
}

