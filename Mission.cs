using System;

namespace Robots {

    public class Mission {

        public Robot Robot { get; private set; }
        public string Commands { get; private set; }

        public Mission(Robot robot, string commands) {
            Robot = robot;
            Commands = commands;
        }
    }
}

