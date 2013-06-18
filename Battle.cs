using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenTableRobots {

    public class Battle {

        readonly Config config;

        public Battle(Config config) {
            this.config = config;
        }

        public List<Robot> Run() {
            return config.Missions.Select(mission => RunMission(mission)).ToList();
        }

        private Robot RunMission(Mission mission) {
            foreach (char c in mission.Commands) {
                mission.Robot.ExecuteCommand(c.ToString(), config.Grid);
            }
            return mission.Robot;
        }
    }
}

