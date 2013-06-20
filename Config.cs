using System;
using System.Collections.Generic;

namespace Robots {

    /// <summary>
    /// Config for a battle, with a simple 'builder' style API to make it easy to create
    /// config declaratively, which is especially useful for readable tests.
    /// </summary>
    public class Config {

        public Grid Grid { get; private set; }
        public List<Mission> Missions { get; private set; }

        public Config(Grid grid, List<Mission> missions) {
            Grid = grid;
            Missions = missions;
        }

        public Config(int maxX, int maxY) {
            if (maxX < 0 || maxY < 0) throw new ArgumentOutOfRangeException("Grid bounds must be non-negative");
            Grid = new Grid(maxX, maxY);
            Missions = new List<Mission>();
        }

        public Config AddMission(int x, int y, Direction facing, string commands) {
            return AddMission(new Robot(x, y, facing), commands);
        }

        public Config AddMission(Robot robot, string commands) {
            if (!Grid.IsInBounds(robot.X, robot.Y)) throw new ArgumentOutOfRangeException("Robot cannot start outside the grid");
            Missions.Add(new Mission(robot, commands));
            return this;
        }
    }
}
