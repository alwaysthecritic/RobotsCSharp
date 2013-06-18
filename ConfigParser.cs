using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace OpenTableRobots {

    public class ConfigParsingException : Exception {
        public ConfigParsingException(string message) : base(message) {}
    }

    public class ConfigParser {

        public const int MaxCommands = 10000;

        // Allow up to nine digits for anything we're going to treat as an int, so it won't overflow.
        Regex GridDimensionsRegex = new Regex(@"^(\d{1-9}) (\d{1-9})$");
        Regex MissionStartRegex = new Regex(@"^(\d{1-9}) (\d{1-9}) ([NSEW])$");
        // Allow zero commands in case someone simply wants to place a static robot.
        Regex MissionCommandsRegex = new Regex(string.Format (@"^[LRF]{0-{0}}$", MaxCommands));

        // qq this duplicates what's in the Config object - but maybe that's OK?
        Grid grid;
        List<Mission> missions;

        public Config Parse(string[] lines) {
            if (lines.Length < 3)
                throw new ConfigParsingException("Config needs at least 3 lines to be valid.");
            if (lines.Length % 2 != 1)
                throw new ConfigParsingException("Config is malformed - should have an odd number of lines.");

            grid = parseGridDimensions(lines[0]);
            missions = new List<Mission>();
            for (int i = 1; i < lines.Length; i += 2) {
                Robot robot = parseRobot(lines[i]);
                string commands = parseCommands(lines[i + 1]);
                missions.Add(new Mission(robot, commands));
            }

            return new Config(grid, missions);
        }

        private Grid parseGridDimensions(string line) {
            var match = GridDimensionsRegex.Match(line);
            if (!match.Success)
                throw new ConfigParsingException("Couldn't parse grid dimensions from text" + line);
            int maxX = int.Parse(match.Groups[0].Value);
            int maxY = int.Parse(match.Groups[1].Value);
            return new Grid(maxX, maxY);
        }

        private Robot parseRobot(string line) {
            var match = MissionStartRegex.Match(line);
            if (!match.Success)
                throw new ConfigParsingException("Couldn't parse robot start position from text" + line);
            int x = int.Parse(match.Groups[0].Value);
            int y = int.Parse(match.Groups[1].Value);
            Direction facing = (Direction)Enum.Parse(typeof(Direction), match.Groups[2].Value);
            return new Robot(x, y, facing);
        }

        private string parseCommands(string line) {
            var match = MissionCommandsRegex.Match(line);
            if (!match.Success)
                throw new ConfigParsingException("Couldn't parse robot commands from text" + line);
            return match.Value;
        }
    }
}

