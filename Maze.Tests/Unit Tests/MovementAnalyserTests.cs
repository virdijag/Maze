using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using  Maze.Common;
using Moq;
using FluentAssertions;
using Maze.Tests.Test_Values;

namespace Maze.Tests.Unit_Tests
{
    [TestClass]
    public class MovementAnalyserTests
    {
        private IMovementAnalyser movementAnalyser;
        private Mock<IExplorerPosition> explorerPositionMock;
        private Mock<IMaze> mazeMock;
        private string wall = "X";
        private string noWall = string.Empty;    

        [TestInitialize]
        public void Init()
        {
            this.explorerPositionMock = new Mock<IExplorerPosition>();
            this.mazeMock = new Mock<IMaze>();
            this.movementAnalyser = new MovementAnalyser(this.explorerPositionMock.Object, this.mazeMock.Object);
        }

        [TestMethod]
        public void Check_Contructors_For_Null_Parameters() => AssertionHelper.CheckContructorForNullParameters<MovementAnalyser>();
        
        [TestMethod]
        public void Should_Understand_All_Options_Of_Movement_Before_Explorer_Moves_At_Position_Expect_List_Of_Options_To_Be_Provided()
        {
            this.mazeMock.Setup(x => x.DisplayCellValue(It.IsAny<Position>())).ReturnsInOrder(wall, noWall, wall, wall);
            this.SetUpExplorerPositionMock();

            var movementOptions = this.movementAnalyser.GetAllPossibleMovements(Facing.East, MazeTestValues.GetCurrentPositionMock());

            movementOptions[0].Position.Should().Be(new Position(3, 12));
            movementOptions[0].Value.Should().Be(wall);
            movementOptions[1].Position.Should().Be(new Position(4, 11));
            movementOptions[1].Value.Should().Be(string.Empty);
            movementOptions[2].Position.Should().Be(new Position(3, 10));
            movementOptions[2].Value.Should().Be(wall);
            movementOptions[3].Position.Should().Be(new Position(2, 11));
            movementOptions[3].Value.Should().Be(wall);
        }
              
        [TestMethod]
        public void Should_UnderStand_What_Is_Infront_Of_Explorer_When_Faced_With_Wall_Expect_Wall_To_Detected()
        {             
            this.mazeMock.Setup(x => x.DisplayCellValue(It.IsAny<Position>())).Returns(wall);

            var movementOption = this.movementAnalyser.GetMovementAhead(Facing.North, MazeTestValues.GetCurrentPositionMock());
            var expectedPosition = new Position(3, 11);
            movementOption.Position.Should().Be(expectedPosition);

            string expectWall = "X";
            movementOption.Value.Should().Be(expectWall);
        }

        [TestMethod]
        public void Should_UnderStand_What_Is_Infront_Of_Explorer_When_Faced_With_NoWall_Expect_NoWall_Detected()
        {            
            this.mazeMock.Setup(x => x.DisplayCellValue(It.IsAny<Position>())).Returns(noWall);

            var movementOption = this.movementAnalyser.GetMovementAhead(Facing.North, MazeTestValues.GetCurrentPositionMock());
            var expectedPosition = new Position(3,11);
            movementOption.Position.Should().Be(expectedPosition);

            string expectNoWall = string.Empty;
            movementOption.Value.Should().Be(expectNoWall);
        }

        private void SetUpExplorerPositionMock()
        {
            this.explorerPositionMock.Setup(x => x.North(It.IsAny<Position>())).Returns(new Position(3, 12));
            this.explorerPositionMock.Setup(x => x.East(It.IsAny<Position>())).Returns(new Position(4, 11));
            this.explorerPositionMock.Setup(x => x.South(It.IsAny<Position>())).Returns(new Position(3, 10));
            this.explorerPositionMock.Setup(x => x.West(It.IsAny<Position>())).Returns(new Position(2, 11));
        }
    }
}
