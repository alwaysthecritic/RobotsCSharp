using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenTableRobots {

	public class Robot {

        private static readonly Dictionary<Direction, Direction> LeftTurnMap = new Dictionary<Direction, Direction> {
            {Direction.N, Direction.W},
            {Direction.E, Direction.N},
            {Direction.S, Direction.E},
            {Direction.W, Direction.S}
        };
        // Invert the mapping for turning the other way.
        private static readonly Dictionary<Direction, Direction> RightTurnMap = LeftTurnMap.ToDictionary(x => x.Value, x => x.Key);

        public Direction Facing { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        public Robot(int x, int y, Direction facing) {
            X = x;
            Y = y;
            Facing = facing;
		}

        public void ExecuteCommand(string command, Grid grid) {
            switch (command) {
                case "L": Left(); break;
                case "R": Right(); break;
                case "M": Move(grid); break;
                default: throw new ArgumentOutOfRangeException("Unknown command: " + command);
            }
        }

        private void Left() {
            Facing = LeftTurnMap[Facing];
        }

        private void Right() {
            Facing = RightTurnMap[Facing];
        }

        // The robot will ignore a Move that would take it off the edge of the grid.
        private void Move(Grid grid) {
            int newX = X, newY = Y;
            switch (Facing) {
                case Direction.N: newY += 1; break;
                case Direction.S: newY -= 1; break;
                case Direction.E: newX += 1; break;
                case Direction.W: newX -= 1; break;
            }
            if (grid.IsInBounds(newX, newY)) {
                X = newX;
                Y = newY;
            }
        }
	}
}

