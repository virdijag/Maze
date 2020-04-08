
namespace Maze.Common
{
    public interface IMazePositionFinder
    {
        Position FindStart(string[,] grid);
    }
}
