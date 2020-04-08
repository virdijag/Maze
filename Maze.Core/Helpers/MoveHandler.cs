using System;

namespace Maze.Common
{
    public sealed class MoveHandler : IMoveHandler
    {
        private readonly IExplorerPosition explorerPosition;

        public MoveHandler(IExplorerPosition explorerPosition) => this.explorerPosition = explorerPosition.CheckIfNull(nameof(explorerPosition));
        
        public Position MoveForward(Facing facing, Position currentPosition)
        {
            return this.UpdateCurrentPosition(facing, currentPosition);
        }
               
        public Facing TurnLeft(Facing currentlyFacing)
        {
            int value = (int)currentlyFacing - 1;
            return (value != -1 ? this.GetFacingEnumValue(value) : Facing.West);           
        }

        public Facing TurnRight(Facing currentlyFacing)
        {
            int value = (int)currentlyFacing + 1;
            return (value != 4 ? this.GetFacingEnumValue(value) : Facing.North);                 
        }

        // internal for testing
        internal Facing GetFacingEnumValue(int value) => (Facing)Enum.Parse(typeof(Facing), value.ToString());
        
        // internal for testing
        internal Position UpdateCurrentPosition(Facing facing, Position currentPosition)
        {
            switch (facing)
            {
                case Facing.North:
                    return this.explorerPosition.North(currentPosition);
                case Facing.East:
                    return this.explorerPosition.East(currentPosition);
                case Facing.South:
                    return this.explorerPosition.South(currentPosition);
                case Facing.West:
                    return this.explorerPosition.West(currentPosition);
                default:
                    throw new ArgumentException("Invalid value provided.");
            }
        }
    }
}
