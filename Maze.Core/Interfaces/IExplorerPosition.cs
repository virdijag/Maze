
namespace Maze.Common
{
    public interface IExplorerPosition
    {
        Position North(Position currentPosition);
        Position East(Position currentPosition);
        Position South(Position currentPosition);
        Position West(Position currentPosition);
    }
}
