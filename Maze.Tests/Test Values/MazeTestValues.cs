using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using  Maze.Common;

namespace Maze.Tests.Test_Values
{    
    public static class MazeTestValues
    {
        public static string[] ValidMazeExample()
        {
            return new string[] {
             "XXXXXXXXXXXXXXX",
             "X             X",
             "X XXXXXXXXXXX X",
             "X XS        X X",
             "X XXXXXXXXX X X",
             "X XXXXXXXXX X X",
             "X XXXX      X X",
             "X XXXX XXXX X X",
             "X XXXX XXXX X X",
             "X X    XXXXXX X",
             "X X XXXXXXXXX X",
             "X X XXXXXXXXX X",
             "X X         X X",
             "X XXXXXXXXX   X",
             "XFXXXXXXXXXXXXX"           
            };
        }

        public static string[] InValidMazeExample()
        {
            return new string[] {
             "XXXXXXXXXFXXXXX",
             "X             X",
             "X XXXXXXXXXXX X",
             "X XS        X X",
             "X XXXXXXXXX X X",
             "X XXXXXXXXX X X",
             "X XXXX      X X",
             "X XXXX XXXX X X",
             "X XXXX XXXX X X",
             "X X    XXXXXX X",
             "X X XXXXXXXXX X",
             "X X XXXXXXXXX X",
             "X X         X X",
             "X XXXXXXXXX S X",
             "XFXXXXXXXXXXXXX"           
            };
        }

        public static string[] InValidMazeNoStartExample()
        {
            return new string[] {
             "XXXXXXXXXFXXXXX",
             "X             X",
             "X XXXXXXXXXXX X",
             "X X         X X",
             "X XXXXXXXXX X X",
             "X XXXXXXXXX X X",
             "X XXXX      X X",
             "X XXXX XXXX X X",
             "X XXXX XXXX X X",
             "X X    XXXXXX X",
             "X X XXXXXXXXX X",
             "X X XXXXXXXXX X",
             "X X         X X",
             "X XXXXXXXXX   X",
             "XFXXXXXXXXXXXXX"           
            };
        }

        public static string GetValidMazeCellElements()
        {
            StringBuilder builder = new StringBuilder();

            foreach (var row in ValidMazeExample())
            {
                builder.Append(row);
            }

            return builder.ToString();
        }

        public static string GetInValidMazeCellElements()
        {
            StringBuilder builder = new StringBuilder();

            foreach (var row in InValidMazeExample())
            {
                builder.Append(row);
            }

            return builder.ToString();
        }

        public static string[,] GetValidMazeGrid()
        {
            var grid = new string[1,15];
            grid[0, 0] = "X";
            grid[0, 1] = "F";
            grid[0, 2] = "X";
            grid[0, 3] = "X";
            grid[0, 4] = "X";
            grid[0, 5] = "X";
            grid[0, 6] = "X";
            grid[0, 7] = "X";
            grid[0, 8] = "S";
            grid[0, 9] = "X";
            grid[0, 10] = "X";
            grid[0, 11] = "X";
            grid[0, 12] = "X";
            grid[0, 13] = "X";
            grid[0, 14] = "X";
                     
            return grid;            
        }

        public static string[,] GetInValidMazeGrid()
        {
            var grid = new string[1, 15];
            grid[0, 0] = "X";
            grid[0, 1] = "F";
            grid[0, 2] = "X";
            grid[0, 3] = "X";
            grid[0, 4] = "X";
            grid[0, 5] = "X";
            grid[0, 6] = "X";
            grid[0, 7] = "X";
            grid[0, 8] = "X";
            grid[0, 9] = "X";
            grid[0, 10] = "X";
            grid[0, 11] = "X";
            grid[0, 12] = "X";
            grid[0, 13] = "X";
            grid[0, 14] = "X";

            return grid;
        }

        public static Position GetCurrentPositionMock()
        {
            int x = 3;
            int y = 11;
            return new Position(x, y);
        }
    }
}
