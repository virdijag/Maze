using System;

namespace Maze.Common
{
    public sealed class MovementAnalyser : IMovementAnalyser
    {
        private readonly IExplorerPosition explorerPosition;
        private readonly IMaze maze;

        public MovementAnalyser(IExplorerPosition explorerPosition, IMaze maze)
        {
            this.explorerPosition = explorerPosition.CheckIfNull(nameof(explorerPosition));
            this.maze = maze.CheckIfNull(nameof(maze));
        }

        public MovementOption GetMovementAhead(Facing facing, Position fromCurrentPosition)
        {
            switch (facing)
            {
                case Facing.North:
                    return new MovementOption() { Position = fromCurrentPosition, Value = this.DisplayNorthCellValue(fromCurrentPosition) };
                case Facing.East:
                    return new MovementOption() { Position = fromCurrentPosition, Value = this.DisplayEastCellValue(fromCurrentPosition) };
                case Facing.South:
                    return new MovementOption() { Position = fromCurrentPosition, Value = this.DisplaySouthCellValue(fromCurrentPosition) };
                case Facing.West:
                    return new MovementOption() { Position = fromCurrentPosition, Value = this.DisplayWestCellValue(fromCurrentPosition) };
                default:
                    throw new ArgumentException("invalid explorer facing option provided.");
            }
        }

        public MovementOption[] GetAllPossibleMovements(Facing facing, Position fromCurrentPosition)
        {            
            var north = this.explorerPosition.North(fromCurrentPosition);
            var east = this.explorerPosition.East(fromCurrentPosition);
            var south = this.explorerPosition.South(fromCurrentPosition);
            var west = this.explorerPosition.West(fromCurrentPosition);
                      
            return new MovementOption[] { 
               new MovementOption() { Position = north, Value = this.maze.DisplayCellValue(north) },
               new MovementOption() { Position = east, Value = this.maze.DisplayCellValue(east) },
               new MovementOption() { Position = south, Value = this.maze.DisplayCellValue(south) },
               new MovementOption() { Position = west, Value = this.maze.DisplayCellValue(west) }
            };
        }

        // internal for testing
        internal string DisplayNorthCellValue(Position fromCurrentPosition) => this.maze.DisplayCellValue(this.explorerPosition.North(fromCurrentPosition));
        
        // internal for testing
        internal string DisplayEastCellValue(Position fromCurrentPosition) => this.maze.DisplayCellValue(this.explorerPosition.East(fromCurrentPosition));
        
        // internal for testing
        internal string DisplaySouthCellValue(Position fromCurrentPosition) => this.maze.DisplayCellValue(this.explorerPosition.South(fromCurrentPosition));
        
        // internal for testing
        internal string DisplayWestCellValue(Position fromCurrentPosition) => this.maze.DisplayCellValue(this.explorerPosition.West(fromCurrentPosition));        
    }
}
