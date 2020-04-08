using System;
using System.IO;

namespace Maze.Common
{
    public sealed class MazeFileLoader : IMazeLoader
    {
        public string MazeFileName { get; private set; }

        public MazeFileLoader(string mazeFileName)
        {
            if (string.IsNullOrEmpty(mazeFileName))
            {
                throw new ArgumentNullException("mazefilename cannot be null or empty.");
            }

            this.MazeFileName = mazeFileName;
        }

        public string[] LoadMaze() => File.ReadAllLines(MazeFileName);
    }
}
