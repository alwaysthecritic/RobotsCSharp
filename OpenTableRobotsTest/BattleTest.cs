using System;
using NUnit.Framework;
using OpenTableRobots;
using System.Collections.Generic;

namespace OpenTableRobotsTest {

    [TestFixture]
    public class Test {

        [Test]
        public void BattleRunsCorrectly() {
            var config = new Config(new Grid(5, 5),
                                    new List<Mission> {
                                        new Mission(new Robot(1, 2, Direction.N), "LMLMLMLMM"),
                                        new Mission(new Robot(3, 3, Direction.E), "MMRMMRMRRM")
                                    });

            var battle = new Battle(config);
            var results = battle.Run();

            Assert.AreEqual(2, results.Count);

            Assert.AreEqual(1, results[0].X);
            Assert.AreEqual(3, results[0].Y);
            Assert.AreEqual(Direction.N, results[0].Facing);


            Assert.AreEqual(5, results[1].X);
            Assert.AreEqual(1, results[1].Y);
            Assert.AreEqual(Direction.E, results[1].Facing);
        }
    }
}

