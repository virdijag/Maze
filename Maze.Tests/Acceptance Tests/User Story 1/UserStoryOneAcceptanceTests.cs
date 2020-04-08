using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using  Maze.Common;
using core =  Maze.Common;
using FluentAssertions;
using System.Collections.Generic;

namespace Maze.Tests.Acceptance_Tests
{
    [TestClass]
    public class UserStoryOneAcceptanceTests
    {         
        IMazeLoader mazeLoader;
        IMazeValidator mazeValidtor;
        IMazePositionFinder mazePositionFinder;
        IMazeGridGenerator mazeGridGenerator;
        IMaze maze;

        [TestInitialize]
        public void Init()
        {
            string mazeFileName = "ExampleMaze.txt";
            this.mazeLoader = new MazeFileLoader(mazeFileName);
            this.mazeValidtor = new MazeValidator();
            this.mazePositionFinder = new MazePositionFinder();
            this.mazeGridGenerator = new MazeGridGenerator(mazeLoader, mazeValidtor, mazePositionFinder);
            this.maze = new core.Maze(mazeGridGenerator);
        }

        [TestMethod]
        public void Given_A_Maze_Is_Loaded_When_Created_Successfully_Then_The_Maze_Should_Contain_One_Start_And_Exit()
        {
            this.maze.Grid.Should().NotBeNull();

            CountGridValues("S", maze.Grid).Should().Be(1);
            CountGridValues("F", maze.Grid).Should().Be(1);
        }

        [TestMethod]
        public void Given_A_Maze_Is_Loaded_When_Created_Successfully_Then_A_Number_Walls_And_NoWalls_Should_Be_Available()
        {
            this.maze.Grid.Should().NotBeNull();

            CountGridValues(" ", maze.Grid).Should().BeGreaterThan(1);
            CountGridValues("X", maze.Grid).Should().BeGreaterThan(1);
        }

        [TestMethod]
        public void Given_A_Maze_Is_Created_When_Coordinates_Are_Provided_For_Start_Then_The_Value_S_Should_Be_Returned()
        {
            this.maze = new core.Maze(mazeGridGenerator);
            var value = maze.DisplayCellValue(new Position(3, 11));
            value.Should().Be("S");          
        }

        private int CountGridValues(string value, string[,] grid)
        {
           int counter = 0;
            
            int rows = grid.GetLength(0);
            int columns = grid.GetLength(1);

            for (int x = 0; x < rows; ++x)
            {
                for (int y = 0; y < columns; ++y)
                {
                    if (grid[x, y].Equals(value))
                    {
                        counter++;
                    }
                }
            }

            return counter;         
        }       
    }
}
