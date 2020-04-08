using System;

namespace Maze.Common
{
    public sealed class MazePositionFinder : IMazePositionFinder
    {
        private const string Start = "S";

        public Position FindStart(string[,] grid)
        {            
            int rows = grid.GetLength(0); 
            int columns = grid.GetLength(1);

            for (int x = 0; x < rows; ++x)
            {
                for (int y = 0; y < columns; ++y)
                {
                    if (grid[x, y].Equals(Start))
                    {
                        return new Position(x, y);
                    }
                }
            }

            throw new ArgumentException("Invalid grid no start point found.");
        }       
    }
}
