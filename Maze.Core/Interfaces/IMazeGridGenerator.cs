
namespace Maze.Common
{
    public interface IMazeGridGenerator : IMazeGridInformation
    {
        string[,] CreateGrid();

        string[] DisplayGrid();       
    }
}
