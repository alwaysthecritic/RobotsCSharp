using System;
using System.Collections.Generic;

namespace OpenTableRobots {

    public class Config {

        public Grid Grid { get; private set; }
        public List<Mission> Missions { get; private set; }

        public Config(Grid grid, List<Mission> missions) {
            Grid = grid;
            Missions = missions;
        }
    }
}

