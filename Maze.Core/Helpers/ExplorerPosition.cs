
namespace Maze.Common
{
    public sealed class ExplorerPosition : IExplorerPosition
    {
        public Position North(Position currentPosition) =>  new Position(currentPosition.xCoordinate, currentPosition.yCoordinate + 1);
        
        public Position East(Position currentPosition) =>  new Position(currentPosition.xCoordinate + 1, currentPosition.yCoordinate);
        
        public Position South(Position currentPosition) => new Position(currentPosition.xCoordinate, currentPosition.yCoordinate - 1);
        
        public Position West(Position currentPosition) => new Position(currentPosition.xCoordinate - 1, currentPosition.yCoordinate);        
    }
}
