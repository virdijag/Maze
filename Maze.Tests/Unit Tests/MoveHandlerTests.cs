using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FluentAssertions;
using  Maze.Common;
using Maze.Tests.Test_Values;

namespace Maze.Tests.Unit_Tests
{
    [TestClass]
    public class MoveHandlerTests
    {
        private IMoveHandler moveHandler;
        private Mock<IExplorerPosition> explorerPosition;

        [TestInitialize]
        public void Init()
        {
            this.explorerPosition = new Mock<IExplorerPosition>();
            this.moveHandler = new MoveHandler(this.explorerPosition.Object);
        }

        [TestMethod]
        public void Check_Contructors_For_Null_Parameters() => AssertionHelper.CheckContructorForNullParameters<MoveHandler>();
        
        [TestMethod]
        public void Should_Move_Explorer_Forward_When_Facing_East_Expect_Position_Updated()
        {
            this.explorerPosition.Setup(x => x.East(It.IsAny<Position>())).Returns(new Position(4, 11));
            var newPosition = this.moveHandler.MoveForward(Facing.East, MazeTestValues.GetCurrentPositionMock());

            var expectedPositon = new Position(4,11);
            newPosition.xCoordinate.Should().Be(4);
            newPosition.yCoordinate.Should().Be(11);
        }

        [TestMethod]
        public void Should_Move_Explorer_Forward_When_Facing_North_Expect_Position_Updated()
        {
            this.explorerPosition.Setup(x => x.North(It.IsAny<Position>())).Returns(new Position(3, 12));
            var newPosition = this.moveHandler.MoveForward(Facing.North, MazeTestValues.GetCurrentPositionMock());

            var expectedPositon = new Position(3, 12);
            newPosition.xCoordinate.Should().Be(3);
            newPosition.yCoordinate.Should().Be(12);
        }

        [TestMethod]
        public void Should_Move_Explorer_Forward_When_Facing_South_Expect_Position_Updated()
        {
            this.explorerPosition.Setup(x => x.South(It.IsAny<Position>())).Returns(new Position(3, 10));
            var newPosition = this.moveHandler.MoveForward(Facing.South, MazeTestValues.GetCurrentPositionMock());

            var expectedPositon = new Position(3, 10);
            newPosition.xCoordinate.Should().Be(3);
            newPosition.yCoordinate.Should().Be(10);
        }

        [TestMethod]
        public void Should_Move_Explorer_Forward_When_Facing_West_Expect_Position_Updated()
        {
            this.explorerPosition.Setup(x => x.West(It.IsAny<Position>())).Returns(new Position(2, 11));
            var newPosition = this.moveHandler.MoveForward(Facing.West, MazeTestValues.GetCurrentPositionMock());
            var expectedPositon = new Position(2, 11);
            newPosition.xCoordinate.Should().Be(2);
            newPosition.yCoordinate.Should().Be(11);
        }

        [TestMethod]
        public void Should_Turn_Explorer_Left_When_Facing_East_Expect_Facing_Updated_To_North()
        {           
            var newFacing = this.moveHandler.TurnLeft(Facing.East);           
            newFacing.Should().Be(Facing.North);          
        }

        [TestMethod]
        public void Should_Turn_Explorer_Left_When_Facing_North_Expect_Facing_Updated_To_West()
        {
            var newFacing = this.moveHandler.TurnLeft(Facing.North);
            newFacing.Should().Be(Facing.West);
        }

        [TestMethod]
        public void Should_Turn_Explorer_Left_When_Facing_West_Expect_Facing_Updated_To_South()
        {
            var newFacing = this.moveHandler.TurnLeft(Facing.West);
            newFacing.Should().Be(Facing.South);
        }

        [TestMethod]
        public void Should_Turn_Explorer_Left_When_Facing_South_Expect_Facing_Updated_To_East()
        {
            var newFacing = this.moveHandler.TurnLeft(Facing.South);
            newFacing.Should().Be(Facing.East);
        }

        [TestMethod]
        public void Should_Turn_Explorer_Right_When_Facing_East_Expect_Facing_Updated_To_South()
        {
            var newFacing = this.moveHandler.TurnRight(Facing.East);
            newFacing.Should().Be(Facing.South);
        }

        [TestMethod]
        public void Should_Turn_Explorer_Right_When_Facing_South_Expect_Facing_Updated_To_West()
        {
            var newFacing = this.moveHandler.TurnRight(Facing.South);
            newFacing.Should().Be(Facing.West);
        }

        [TestMethod]
        public void Should_Turn_Explorer_Right_When_Facing_West_Expect_Facing_Updated_To_North()
        {
            var newFacing = this.moveHandler.TurnRight(Facing.West);
            newFacing.Should().Be(Facing.North);
        }

        [TestMethod]
        public void Should_Turn_Explorer_Right_When_Facing_North_Expect_Facing_Updated_To_East()
        {
            var newFacing = this.moveHandler.TurnRight(Facing.North);
            newFacing.Should().Be(Facing.East);
        }       
    }
}
