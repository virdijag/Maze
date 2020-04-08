using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using  Maze.Common;
using core =  Maze.Common;

namespace Maze.Tests.Acceptance_Tests
{    
    [TestClass]
    public class UserStoryTwoAcceptancePartTwoTests
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
        
        [TestInitialize]
        public void Init()
        {
            string mazeFileName = "ExampleMazeSmall.txt";
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
        public void Given_The_Explorer_Is_At_Start_Point_When_Travelling_Through_The_Maze_Finding_The_Exit_Then_Explorers_Recorded_Movements_Should_Be_Displayed()
        {
            this.explorer.DropAtStartPoint();
        
            this.explorer.TurnLeft();
            this.explorer.MoveForward();
            this.explorer.MoveForward();
            this.explorer.TurnLeft();
            this.explorer.MoveForward();
            this.explorer.TurnLeft();
            this.explorer.MoveForward();
            this.explorer.MoveForward();
                      
            var recordedMoves = this.explorer.RecordedMoves();
            recordedMoves[0].Should().Be("Explorer Turned Left now facing North.");
            recordedMoves[1].Should().Be("Explorer Moved Forward to position (3,2).");
            recordedMoves[2].Should().Be("Explorer Moved Forward to position (3,3).");
            recordedMoves[3].Should().Be("Explorer Turned Left now facing West.");
            recordedMoves[4].Should().Be("Explorer Moved Forward to position (2,3).");
            recordedMoves[5].Should().Be("Explorer Moved Forward to position (1,3).");
            recordedMoves[6].Should().Be("Explorer Turned Left now facing South.");
            recordedMoves[7].Should().Be("Explorer Moved Forward to position (1,2).");
            recordedMoves[8].Should().Be("Explorer Moved Forward to position (1,1).");
            recordedMoves[9].Should().Be("Explorer Moved Forward to position (1,0).");
            recordedMoves[10].Should().Be("Explorer has Exit the Maze at position (1,-1).");                      
        }
    }
}
