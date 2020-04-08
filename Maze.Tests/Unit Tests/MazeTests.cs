using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using  Maze.Common;
using Moq;
using FluentAssertions;
using Maze.Tests.Test_Values;
using core =  Maze.Common;

namespace Maze.Tests.Unit_Tests
{
    [TestClass]
    public class MazeTests
    {
        private Mock<IMazeGridGenerator> mazeGridGeneratorMock;
        private IMaze maze;

        [TestInitialize]
        public void Init()
        {
            this.mazeGridGeneratorMock = new Mock<IMazeGridGenerator>();
            this.maze = new core.Maze(mazeGridGeneratorMock.Object);
            this.mazeGridGeneratorMock.Setup(x => x.CreateGrid()).Returns(MazeTestValues.GetValidMazeGrid());
        }

        [TestMethod]
        public void Check_Contructors_For_Null_Parameters() => AssertionHelper.CheckContructorForNullParameters<core.Maze>();
        
        [TestMethod]
        public void Should_Get_Grid_Of_Loaded_Maze_Expect_Grid_Is_Returned() => this.maze.Grid.Should().NotBeNull();
                
        [TestMethod]
        public void
            Should_Be_Able_To_Display_Cell_Value_When_Start_Position_Is_Provided_Expect_Value_Start_S_To_Be_Returned()
        {
            int x = 0;
            int y = 8;
            var position = new Position(x, y);
            string start = "S";

            var result = this.maze.DisplayCellValue(position);
            result.Should().Be(start);
        }

        [TestMethod]
        public void Should_Be_Able_To_Display_Grid_When_Valid_Maze_Is_Loaded_Expect_Grid_To_Be_Displayed()
        {
            this.mazeGridGeneratorMock.Setup(x => x.DisplayGrid()).Returns(MazeTestValues.ValidMazeExample());
            var result = this.maze.DisplayGrid();
            result.Should().BeEquivalentTo(MazeTestValues.ValidMazeExample());
        }

        [TestMethod]
        public void Should_Be_Able_To_Display_Maze_Start_Point_Expect_Start_Point_To_Be_Returned()
        {
            int x = 0;
            int y = 8;

            this.mazeGridGeneratorMock.Setup(i => i.GetStartPoint()).Returns(new Position(0, 8));                       
            var expectedLocation = new Position(x, y);

            var result = this.maze.DisplayStartPoint();
            result.Should().Be(expectedLocation);
        }
    }
}
