using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FluentAssertions;
using  Maze.Common;
using Maze.Tests.Test_Values;

namespace Maze.Tests.Unit_Tests
{
    [TestClass]
    public class MazeGridGeneratorTests
    {
        private Mock<IMazeLoader> mazeLoaderMock;
        private Mock<IMazeValidator> mazeValidatorMock;
        private Mock<IMazePositionFinder> mazePositionFinder;
        private IMazeGridGenerator mazeGridGenerator;

        [TestInitialize]
        public void Init()
        {
            this.mazeLoaderMock = new Mock<IMazeLoader>();
            this.mazeValidatorMock = new Mock<IMazeValidator>();
            this.mazePositionFinder = new Mock<IMazePositionFinder>();
            this.mazeGridGenerator = new MazeGridGenerator(this.mazeLoaderMock.Object, this.mazeValidatorMock.Object, this.mazePositionFinder.Object);
        }

        [TestMethod]
        public void Check_Contructors_For_Null_Parameters() => AssertionHelper.CheckContructorForNullParameters<MazeGridGenerator>();
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_Throw_Argument_Exception_When_Maze_Is_Not_Valid_Expect_Argument_Exception_Thrown()
        {
            this.mazeLoaderMock.Setup(x => x.LoadMaze()).Returns(MazeTestValues.InValidMazeExample);
            this.mazeValidatorMock.Setup(x => x.IsMazeValid(It.IsAny<string[]>())).Returns(false);

            var mazeGrid = this.mazeGridGenerator.CreateGrid();
        }

        [TestMethod]
        public void Should_Be_Able_To_Create_Maze_Grid_When_Maze_Loaded_IsValid_Expect_Maze_Grid_To_Be_Created()
        {           
            this.mazeLoaderMock.Setup(x => x.LoadMaze()).Returns(MazeTestValues.ValidMazeExample());
            this.mazeValidatorMock.Setup(x => x.IsMazeValid(It.IsAny<string[]>())).Returns(true);
            
            var mazeGrid = this.mazeGridGenerator.CreateGrid();
            mazeGrid.Should().NotBeNull();           
        }  
     
        [TestMethod]
        public void Should_Be_Able_To_DisplayGrid_when_Maze_Loaded_IsValid_Expect_Maze_To_Be_Displayed()
        {
            this.mazeLoaderMock.Setup(x => x.LoadMaze()).Returns(MazeTestValues.ValidMazeExample());
            this.mazeValidatorMock.Setup(x => x.IsMazeValid(It.IsAny<string[]>())).Returns(true);

            var mazeGrid = this.mazeGridGenerator.DisplayGrid();
            mazeGrid.Should().NotBeNull();
            mazeGrid.Should().BeEquivalentTo(MazeTestValues.ValidMazeExample());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_Throw_Argument_Exception_When_Invalid_Maze_Loaded_Expect_Maze_Not_To_Be_Displayed_As_ArgumentExceptionThrown()
        {
            this.mazeLoaderMock.Setup(x => x.LoadMaze()).Returns(MazeTestValues.ValidMazeExample());
            this.mazeValidatorMock.Setup(x => x.IsMazeValid(It.IsAny<string[]>())).Returns(false);

            var mazeGrid = this.mazeGridGenerator.DisplayGrid();         
        }

        [TestMethod]
        public void Should_Be_Able_To_Get_Maze_Start_Point_Expect_Start_Point_To_Be_Returned()
        {
            this.mazePositionFinder.Setup(i => i.FindStart(It.IsAny<string[,]>())).Returns(new Position(11, 3));
            this.mazeValidatorMock.Setup(i => i.IsMazeValid(It.IsAny<string[]>())).Returns(true);
            this.mazeLoaderMock.Setup(i => i.LoadMaze()).Returns(MazeTestValues.ValidMazeExample());

            int x = 11;
            int y = 3;
            var expectedLocation = new Position(x, y);
            this.mazeGridGenerator.CreateGrid();

            var result = this.mazeGridGenerator.GetStartPoint();
            result.Should().Be(expectedLocation);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_Throw_ArgumentException_When_No_Grid_Is_Created_Expect_ArgumentException_To_Be_Thrown()
        {
            this.mazeLoaderMock.Setup(x => x.LoadMaze()).Returns(MazeTestValues.InValidMazeNoStartExample());
            this.mazeValidatorMock.Setup(x => x.IsMazeValid(It.IsAny<string[]>())).Returns(false);

            this.mazeGridGenerator.CreateGrid();
            this.mazeGridGenerator.GetStartPoint();
        }
    }
}
