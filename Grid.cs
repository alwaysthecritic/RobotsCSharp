using System;

namespace OpenTableRobots {

    public class Grid {

        public int MaxX { get; private set; }
        public int MaxY { get; private set; }

        public Grid (int maxX, int maxY) {
            MaxX = maxX;
            MaxY = maxY;
        }

        public bool IsInBounds(int x, int y) {
            return x >= 0 && y >= 0 && x <= MaxX && y <= MaxY;
        }
    }
}

