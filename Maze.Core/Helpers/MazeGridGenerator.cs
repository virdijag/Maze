using System;
using System.Linq;
using System.Text;

namespace Maze.Common
{
    public sealed class MazeGridGenerator : IMazeGridGenerator
    {
        private readonly IMazeLoader mazeLoader;
        private readonly IMazeValidator mazeValidator;
        private readonly IMazePositionFinder mazePositionFinder;

        public MazeGridGenerator(
            IMazeLoader mazeLoader,
            IMazeValidator mazeValidator,
            IMazePositionFinder mazePositionFinder)
        {
            this.mazeLoader = mazeLoader.CheckIfNull(nameof(mazeLoader));
            this.mazeValidator = mazeValidator.CheckIfNull(nameof(mazeValidator));
            this.mazePositionFinder = mazePositionFinder.CheckIfNull(nameof(mazePositionFinder));
        }

        public string[] DisplayGrid()
        {
            var maze = this.mazeLoader.LoadMaze();
            if (this.mazeValidator.IsMazeValid(maze))
            {
                return this.mazeLoader.LoadMaze();
            }

            throw this.ThrowArgumentExceptionInvalidMaze();
        }

        public string[,] CreateGrid()
        {
            var maze = this.mazeLoader.LoadMaze();
            if (this.mazeValidator.IsMazeValid(maze))
            {
                return this.PopulateGridWithLoadedMaze(maze);
            }

            throw this.ThrowArgumentExceptionInvalidMaze();            
        }
        
        public int NumberOfRows() => this.mazeLoader.LoadMaze().Count();

        public int NumberOfColumns() =>  this.mazeLoader.LoadMaze()[0].ToCharArray().Count();
                              
        public Position GetStartPoint() => this.mazePositionFinder.FindStart(this.CreateGrid());
       
        private ArgumentException ThrowArgumentExceptionInvalidMaze() => new ArgumentException("Maze loaded is invalid. Please ensure only one start S and exit F is available in maze.");
        
        private string[,] PopulateGridWithLoadedMaze(string[] maze)
        {
            string[,] grid = this.InitialiseGrid();
            int counter = 0;
            foreach (var row in maze)
            {
                int characterCount = this.GetMazeRowCharacterCount(row);
                for (int i = 0; i < characterCount; i++)
                {
                    grid[i, characterCount - 1 - counter] = this.GetMazeCellValue(row, i);

                }
                counter++;
            }

            return grid;
        }

        private string GetMazeCellValue(string row, int characterIndex)
        {
            var cellValue = row.ToCharArray()[characterIndex];
            return cellValue.ToString();
        }

        private int GetMazeRowCharacterCount(string mazeRow) => mazeRow.ToCharArray().GetLength(0);
        
        private string[,] InitialiseGrid() => new string[this.NumberOfRows(), this.NumberOfColumns()];        
    }
}
