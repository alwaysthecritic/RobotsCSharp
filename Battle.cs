using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenTableRobots {

    /// <summary>
    /// Runs a full set of robot missions, given config describing the grid and those missions.
    /// </summary>
    public class Battle {

        private readonly Config config;

        public Battle(Config config) {
            this.config = config;
        }

        public List<Robot> Run() {
            return config.Missions.Select(mission => RunMission(mission)).ToList();
        }

        private Robot RunMission(Mission mission) {
            // We will run the commands with a copy of the mission's robot, so the original is untouched.
            Robot robot = new Robot(mission.Robot);
            // mission.Commands is a string where each character will be interpreted by the robot as a command.
            foreach (char c in mission.Commands) {
                robot.ExecuteCommand(c.ToString(), config.Grid);
            }
            return robot;
        }
    }
}

