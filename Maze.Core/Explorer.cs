using System.Collections.Generic;

namespace Maze.Common
{
    public sealed class Explorer : IExplorer
    {
        private readonly IMaze maze;
        private readonly IMovementAnalyser movementAnalyser;
        private readonly IMoveHandler moveHandler;

        private List<string> recordedMoves;

        public Explorer(
            IMaze maze,
            IMovementAnalyser movementAnalyser,
            IMoveHandler moveHandler)
        {
            this.maze = maze.CheckIfNull(nameof(maze));
            this.movementAnalyser = movementAnalyser.CheckIfNull(nameof(movementAnalyser));
            this.moveHandler = moveHandler.CheckIfNull(nameof(moveHandler));
            this.Facing = Facing.East;
            this.recordedMoves = new List<string>();
        }

        public Facing Facing { get; set; }
        public Position Position { get; set; }

        public Position DropAtStartPoint()
        {
            this.Position = this.maze.DisplayStartPoint();
            return this.Position;
        }

        public MovementOption[] GetAllMovementOptions() => this.movementAnalyser.GetAllPossibleMovements(this.Facing, this.Position);
        
        public MovementOption GetMovementAheadOption() => this.movementAnalyser.GetMovementAhead(this.Facing, this.Position);
        
        public void MoveForward()
        {             
            foreach (var movementOption in this.GetAllMovementOptions())
            {
                this.WhenNoWallMoveForwardAndRecord(movementOption);
                this.WhenAtFinishExitMazeAndRecord(movementOption);
            }
        }
        
        public void TurnRight()
        {
            var facing = this.moveHandler.TurnRight(this.Facing);
            this.Facing = facing;
            this.recordedMoves.Add(string.Format("Explorer Turned Right now facing {0}.", facing));
        }

        public void TurnLeft()
        {
            var facing = this.moveHandler.TurnLeft(this.Facing);
            this.Facing = facing;
            this.recordedMoves.Add(string.Format("Explorer Turned Left now facing {0}.", facing));
        }

        public List<string> RecordedMoves() => this.recordedMoves;
               
        public List<string> ExitMaze(Position position)
        {
            this.Position = position;
            this.recordedMoves.Add(string.Format("Explorer has Exit the Maze at position {0}.", position));
            return this.recordedMoves;
        }

        private void WhenNoWallMoveForwardAndRecord(MovementOption movementOption)
        {
            string noWall = " ";

            if (movementOption.Value == noWall)
            {
                var newPosition = this.moveHandler.MoveForward(this.Facing, this.Position);
                Position = newPosition;
                this.recordedMoves.Add(string.Format("Explorer Moved Forward to position {0}.", newPosition));
            }
        }

        private void WhenAtFinishExitMazeAndRecord(MovementOption movementOption)
        {
            string finish = "F";
            if (movementOption.Value == finish)
            {
                var newPosition = this.moveHandler.MoveForward(this.Facing, this.Position);
                this.ExitMaze(newPosition);
            }
        }      
    }
}
