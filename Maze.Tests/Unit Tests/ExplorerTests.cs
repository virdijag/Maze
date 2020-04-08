using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FluentAssertions;
using  Maze.Common;
using System.Collections.Generic;
using Maze.Tests.Test_Values;
using Moq.Language.Flow;

namespace Maze.Tests.Unit_Tests
{
    [TestClass]
    public class ExplorerTests
    {
        private Mock<IMaze> mazeMock;
        private Mock<IMovementAnalyser> movementAnalyserMock;
        private Mock<IMoveHandler> moveHandlerMock;

        private string wall = "X";
        private string noWall = " ";

        private IExplorer explorer;
        
        [TestInitialize]
        public void Init()
        {
            this.mazeMock = new Mock<IMaze>();
            this.movementAnalyserMock = new Mock<IMovementAnalyser>();
            this.moveHandlerMock = new Mock<IMoveHandler>();
            this.explorer = new Explorer(this.mazeMock.Object, this.movementAnalyserMock.Object, this.moveHandlerMock.Object);
        }

        [TestMethod]
        public void Check_Contructors_For_Null_Parameters()
        {
            AssertionHelper.CheckContructorForNullParameters<Explorer>();
        }

        [TestMethod]
        public void Should_Drop_Explorer_At_Start_Point_Expect_Explorer_To_Be_At_Start_Coordinate_3_11()
        {
            this.mazeMock.Setup(i => i.DisplayStartPoint()).Returns(MazeTestValues.GetCurrentPositionMock());

            var explorerPosition = explorer.DropAtStartPoint();
            var expectedPosition = MazeTestValues.GetCurrentPositionMock();

            explorerPosition.Should().Be(expectedPosition);
            explorerPosition.xCoordinate.Should().Be(3);
            explorerPosition.yCoordinate.Should().Be(11);
        }

        [TestMethod]
        public void Should_Be_Able_To_Understand_All_Possible_MovementOptions_From_Position_Expect_List_Of_Options_To_Be_Provided()
        {                           
            this.movementAnalyserMock.Setup(i => i.GetAllPossibleMovements(It.IsAny<Facing>(), It.IsAny<Position>()))
            .Returns(this.GetAllMovementOptionMock());
                       
            var movementOptions = this.explorer.GetAllMovementOptions();

            movementOptions[0].Position.Should().Be(new Position(3, 12));
            movementOptions[0].Value.Should().Be(wall);
            movementOptions[1].Position.Should().Be(new Position(4, 11));
            movementOptions[1].Value.Should().Be(noWall);
            movementOptions[2].Position.Should().Be(new Position(3, 10));
            movementOptions[2].Value.Should().Be(wall);
            movementOptions[3].Position.Should().Be(new Position(2, 11));
            movementOptions[3].Value.Should().Be(wall);
        }

        [TestMethod]
        public void Should_UnderStand_What_Is_Ahead_Infront_Of_Explorer_When_Faced_With_Wall_Expect_Wall_To_Detected()
        {         
            this.movementAnalyserMock.Setup(i => i.GetMovementAhead(It.IsAny<Facing>(), It.IsAny<Position>()))
                .Returns(new MovementOption() { Position = MazeTestValues.GetCurrentPositionMock(), Value = wall });
          
            var movementOption = this.explorer.GetMovementAheadOption();

            var expectedPosition = MazeTestValues.GetCurrentPositionMock();
            movementOption.Position.Should().Be(expectedPosition);

            string expectWall = wall;
            movementOption.Value.Should().Be(expectWall);
        }

        [TestMethod]
        public void Should_UnderStand_What_Is_Ahead_Infront_Of_Explorer_When_Faced_With_NoWall_Expect_NoWall_Detected()
        {        
            this.movementAnalyserMock.Setup(i => i.GetMovementAhead(It.IsAny<Facing>(), It.IsAny<Position>()))
                .Returns(new MovementOption() { Position = MazeTestValues.GetCurrentPositionMock(), Value = noWall });

            var movementOption = this.explorer.GetMovementAheadOption();

            var expectedPosition = MazeTestValues.GetCurrentPositionMock();
            movementOption.Position.Should().Be(expectedPosition);

            string expectnoWall = noWall;
            movementOption.Value.Should().Be(expectnoWall);
        }

        [TestMethod]
        public void Should_Be_Able_To_View_Recorded_Moves_Made_By_Explorer_When_Travelling_East_Three_Positions_Expect_Moves_To_Be_Recorded()
        {
            this.SetUpExplorerRecordedMovesMock();

            this.explorer.DropAtStartPoint();
            this.explorer.MoveForward();
            this.explorer.MoveForward();
            this.explorer.MoveForward();
            var movesMade = this.explorer.RecordedMoves();

            movesMade[0].Should().Be("Explorer Moved Forward to position (4,11).");
            movesMade[1].Should().Be("Explorer Moved Forward to position (5,11).");
            movesMade[2].Should().Be("Explorer Moved Forward to position (6,11).");
        }
                        
        [TestMethod]
        public void Should_Be_Able_To_View_Recorded_Moves_Made_By_Explorer_When_Exit_Found_Expect_A_Recoreded_List_Of_Moves()
        {
            this.SetUpExplorerRecordedMovesMock();

            this.explorer.DropAtStartPoint();
            this.explorer.MoveForward();
            this.explorer.MoveForward();
            this.explorer.MoveForward();
            this.explorer.TurnRight();
            this.explorer.TurnLeft();
            var movesMade = this.explorer.ExitMaze(MazeTestValues.GetCurrentPositionMock());

            movesMade[0].Should().Be("Explorer Moved Forward to position (4,11).");
            movesMade[1].Should().Be("Explorer Moved Forward to position (5,11).");
            movesMade[2].Should().Be("Explorer Moved Forward to position (6,11).");
            movesMade[3].Should().Be("Explorer Turned Right now facing North.");
            movesMade[4].Should().Be("Explorer Turned Left now facing North.");
            movesMade[5].Should().Be("Explorer has Exit the Maze at position (3,11).");
        }

        private MovementOption[] GetAllMovementOptionMock()
        {
            return new MovementOption[] { 
            new MovementOption() { Position = new Position(3, 12), Value = wall },
            new MovementOption() { Position = new Position(4, 11), Value = noWall },
            new MovementOption() { Position = new Position(3, 10), Value = wall },
            new MovementOption() { Position = new Position(2, 11), Value = wall },
            };
        }

        private void SetUpExplorerRecordedMovesMock()
        {
            this.mazeMock.Setup(x => x.DisplayStartPoint()).Returns(MazeTestValues.GetCurrentPositionMock());
            this.moveHandlerMock.Setup(x => x.MoveForward(It.IsAny<Facing>(), It.IsAny<Position>()))
                .ReturnsInOrder(new Position(4, 11), new Position(5, 11), new Position(6, 11));
            this.movementAnalyserMock.Setup(x => x.GetAllPossibleMovements(It.IsAny<Facing>(), It.IsAny<Position>()))
                .Returns(this.GetAllMovementOptionMock());
        }
    }       
} 
