using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using  Maze.Common;
using Maze.Tests.Test_Values;
using FluentAssertions;

namespace Maze.Tests.Unit_Tests
{
    [TestClass]
    public class MazePositionFinderTests
    {
        private IMazePositionFinder mazePositionFinder;

        [TestInitialize]
        public void Init() => this.mazePositionFinder = new MazePositionFinder();
        
        [TestMethod]
        public void Should_Be_Able_To_Find_Maze_Start_Point_Expect_Start_Point_To_Be_Returned()
        {           
            int x = 0;
            int y = 8;
            var expectedLocation = new Position(x, y);

            var result = this.mazePositionFinder.FindStart(MazeTestValues.GetValidMazeGrid());
            result.Should().Be(expectedLocation);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_Throw_ArgumentException_When_Grid_Has_No_Start_Point_Expect_ArgumentException_To_Be_Thrown()
        {
            var result = this.mazePositionFinder.FindStart(MazeTestValues.GetInValidMazeGrid());         
        }
    }
}
