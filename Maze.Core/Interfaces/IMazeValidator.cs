
namespace Maze.Common
{
    public interface IMazeValidator
    {
        bool HasOnlyOneStart(string mazeCellElements);

        bool HasOnlyOneExit(string mazeCellElements);

        bool IsMazeValid(string[] mazeRows);
    }
}
