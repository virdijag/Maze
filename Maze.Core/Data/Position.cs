using System;

namespace Maze.Common
{
    public struct Position
    {
        public int xCoordinate, yCoordinate;

        public Position(int xCoordinate, int yCoordinate)
        {
            this.xCoordinate = xCoordinate;
            this.yCoordinate = yCoordinate;
        }

        public override string ToString() => $"({xCoordinate},{yCoordinate})";
    }
}
