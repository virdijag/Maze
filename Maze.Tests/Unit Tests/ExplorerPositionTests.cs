using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using  Maze.Common;
using Moq;
using FluentAssertions;

namespace Maze.Tests.Unit_Tests
{
    [TestClass]
    public class ExplorerPositionTests
    {
        private IExplorerPosition explorerPosition;

        [TestInitialize]
        public void Init() => this.explorerPosition = new ExplorerPosition();        
        
        [TestMethod]
        public void Should_Be_Able_To_Move_Position_To_North_Expect_YCoord_To_Be_Updated()
        {
            var newPosition = this.explorerPosition.North(MockCurrentExplorerPosition());
            newPosition.xCoordinate.Should().Be(3);
            newPosition.yCoordinate.Should().Be(12);
        }

        [TestMethod]
        public void Should_Be_Able_To_Move_Position_To_East_Expect_XCoord_To_Be_Updated()
        {
            var newPosition = this.explorerPosition.East(MockCurrentExplorerPosition());
            newPosition.xCoordinate.Should().Be(4);
            newPosition.yCoordinate.Should().Be(11);
        }

        [TestMethod]
        public void Should_Be_Able_To_Move_Position_To_South_Expect_YCoord_To_Be_Updated()
        {
            var newPosition = this.explorerPosition.South(MockCurrentExplorerPosition());
            newPosition.xCoordinate.Should().Be(3);
            newPosition.yCoordinate.Should().Be(10);
        }

        [TestMethod]
        public void Should_Be_Able_To_Move_Position_To_West_Expect_XCoord_To_Be_Updated()
        {
            var newPosition = this.explorerPosition.West(MockCurrentExplorerPosition());
            newPosition.xCoordinate.Should().Be(2);
            newPosition.yCoordinate.Should().Be(11);
        }
        private Position MockCurrentExplorerPosition()
        {
            int xCoordinate = 3;
            int yCoordinate = 11;
            return new Position(xCoordinate, yCoordinate);
        }
    }
}
