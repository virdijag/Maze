
namespace Maze.Common
{
    public interface IMovementAnalyser
    {
        MovementOption GetMovementAhead(Facing facing, Position position);

        MovementOption[] GetAllPossibleMovements(Facing facing, Position position);
    }
}
