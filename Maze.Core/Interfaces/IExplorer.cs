using System.Collections.Generic;

namespace Maze.Common
{
    public interface IExplorer : IExplorerMoves, IExplorerMovementOptions
    {
        Position Position { get; set; }

        Facing Facing { get; set; }

        Position DropAtStartPoint();
                     
        List<string> ExitMaze(Position position);

        List<string> RecordedMoves();
    }
}
