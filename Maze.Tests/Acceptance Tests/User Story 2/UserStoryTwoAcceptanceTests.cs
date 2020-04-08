using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using  Maze.Common;
using core =  Maze.Common;
using FluentAssertions;

namespace Maze.Tests.Acceptance_Tests
{
    [TestClass]
    public class UserStoryTwoAcceptanceTests
    {
        IMazeLoader mazeLoader;
        IMazeValidator mazeValidtor;
        IMazePositionFinder mazePositionFinder;
        IMazeGridGenerator mazeGridGenerator;
        IMaze maze;
        IExplorer explorer;
        IMovementAnalyser movementAnalyser;
        IExplorerPosition explorerPosition;
        IMoveHandler moveHandler;

        string wall = "X";
        string noWall = " ";

        [TestInitialize]
        public void Init()
        {
            string mazeFileName = "ExampleMaze.txt";
            this.mazeLoader = new MazeFileLoader(mazeFileName);
            this.mazeValidtor = new MazeValidator();
            this.mazePositionFinder = new MazePositionFinder();
            this.mazeGridGenerator = new MazeGridGenerator(mazeLoader, mazeValidtor, mazePositionFinder);
            this.maze = new core.Maze(mazeGridGenerator);
            this.explorerPosition = new ExplorerPosition();
            this.movementAnalyser = new MovementAnalyser(this.explorerPosition, this.maze);
            this.moveHandler = new MoveHandler(this.explorerPosition);
            this.explorer = new Explorer(this.maze, this.movementAnalyser, this.moveHandler);
        }

        [TestMethod]
        public void Given_A_Maze_Is_Loaded_When_Created_Successfully_Then_The_Explorer_Should_Dropped_At_StartPoint()
        {
            var startPoint = new Position(3, 11);
            this.explorer.DropAtStartPoint().Should().Be(startPoint);
            this.explorer.Position.Should().Be(startPoint);
        }

        [TestMethod]
        public void Given_A_Maze_Is_Loaded_When_Explorer_Moves_Forward_From_Start_Then_The_Explorer_Position_Should_Be_Updated_To_New_Position()
        {
            this.explorer.DropAtStartPoint();
            this.explorer.MoveForward();
            var newPosition = new Position(4, 11);
            this.explorer.Position.Should().Be(newPosition);
        }

        [TestMethod]
        public void Given_The_Explorer_Facing_East_When_Explorer_Turns_Left_From_Start_Then_The_Explorer_Should_Facing_North()
        {
            this.explorer.DropAtStartPoint();
            this.explorer.TurnLeft();
            this.explorer.Facing.Should().Be(Facing.North);
        }

        [TestMethod]
        public void Given_The_Explorer_Facing_North_When_Explorer_Turns_Left_From_Start_Then_The_Explorer_Should_Facing_West()
        {
            this.explorer.DropAtStartPoint();
            this.explorer.Facing = Facing.North;
            this.explorer.TurnLeft();
            this.explorer.Facing.Should().Be(Facing.West);
        }

        [TestMethod]
        public void Given_The_Explorer_Facing_West_When_Explorer_Turns_Left_From_Start_Then_The_Explorer_Should_Facing_South()
        {
            this.explorer.DropAtStartPoint();
            this.explorer.Facing = Facing.West;
            this.explorer.TurnLeft();
            this.explorer.Facing.Should().Be(Facing.South);
        }

        [TestMethod]
        public void Given_The_Explorer_Facing_South_When_Explorer_Turns_Left_From_Start_Then_The_Explorer_Should_Facing_East()
        {
            this.explorer.DropAtStartPoint();
            this.explorer.Facing = Facing.South;
            this.explorer.TurnLeft();
            this.explorer.Facing.Should().Be(Facing.East);
        }

        [TestMethod]
        public void Given_The_Explorer_Facing_East_When_Explorer_Turns_Right_From_Start_Then_The_Explorer_Should_Facing_South()
        {
            this.explorer.DropAtStartPoint();
            this.explorer.TurnRight();
            this.explorer.Facing.Should().Be(Facing.South);
        }

        [TestMethod]
        public void Given_The_Explorer_Facing_South_When_Explorer_Turns_Right_From_Start_Then_The_Explorer_Should_Facing_West()
        {
            this.explorer.DropAtStartPoint();
            this.explorer.Facing = Facing.South;
            this.explorer.TurnRight();
            this.explorer.Facing.Should().Be(Facing.West);
        }

        [TestMethod]
        public void Given_The_Explorer_Facing_West_When_Explorer_Turns_Right_From_Start_Then_The_Explorer_Should_Facing_North()
        {
            this.explorer.DropAtStartPoint();
            this.explorer.Facing = Facing.West;
            this.explorer.TurnRight();
            this.explorer.Facing.Should().Be(Facing.North);
        }

        [TestMethod]
        public void Given_The_Explorer_Facing_North_When_Explorer_Turns_Right_From_Start_Then_The_Explorer_Should_Facing_East()
        {
            this.explorer.DropAtStartPoint();
            this.explorer.Facing = Facing.North;
            this.explorer.TurnRight();
            this.explorer.Facing.Should().Be(Facing.East);
        }

        [TestMethod]
        public void Given_The_Explorer_Facing_North_From_Start_Point_When_Explorer_Looks_Ahead_Then_Explorer_Should_See_A_Wall()
        {
            this.explorer.DropAtStartPoint();
            this.explorer.Facing = Facing.North;
            var movementOption = this.explorer.GetMovementAheadOption();

            movementOption.Value.Should().Be(wall);
        }

        [TestMethod]
        public void Given_The_Explorer_Facing_East_From_Start_Point_When_Explorer_Looks_Ahead_Then_Explorer_Should_See_NoWall()
        {
            this.explorer.DropAtStartPoint();
            this.explorer.Facing = Facing.East;
            var movementOption = this.explorer.GetMovementAheadOption();

            movementOption.Value.Should().Be(noWall);
        }

        [TestMethod]
        public void Given_The_Explorer_Facing_East_From_Start_Point_When_Explorer_Looks_Around_Then_Explorer_Should_See_All_Possible_MovementOptions()
        {
            this.explorer.DropAtStartPoint();
            this.explorer.Facing = Facing.East;
            var movementOption = this.explorer.GetAllMovementOptions();

            movementOption[0].Value.Should().Be(wall);
            movementOption[0].Position.Should().Be(new Position(3,12));
            movementOption[1].Value.Should().Be(noWall);
            movementOption[1].Position.Should().Be(new Position(4, 11));
            movementOption[2].Value.Should().Be(wall);
            movementOption[2].Position.Should().Be(new Position(3, 10));
            movementOption[3].Value.Should().Be(wall);
            movementOption[3].Position.Should().Be(new Position(2, 11));
        }

        [TestMethod]
        public void Given_The_Explorer_Is_At_Start_Point_When_Travelling_East_Three_Positions_Then_Explorers_Movements_Should_Be_Recorded()
        {
            this.explorer.DropAtStartPoint();
            this.explorer.MoveForward();
            this.explorer.MoveForward();
            this.explorer.MoveForward();

            var recordedMoves = this.explorer.RecordedMoves();
            recordedMoves[0].Should().Be("Explorer Moved Forward to position (4,11).");
            recordedMoves[1].Should().Be("Explorer Moved Forward to position (5,11).");
            recordedMoves[2].Should().Be("Explorer Moved Forward to position (6,11).");
        }
    }
}
