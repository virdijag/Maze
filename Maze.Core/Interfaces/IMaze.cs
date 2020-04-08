
namespace Maze.Common
{
    public interface IMaze
    {
        string[,] Grid { get; }

        string DisplayCellValue(Position position);

        string[] DisplayGrid();
              
        Position DisplayStartPoint();
    }
}
