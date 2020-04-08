
namespace Maze.Common
{
    public interface IMoveHandler
    {
        Position MoveForward(Facing facing, Position currentPosition);

        Facing TurnLeft(Facing currentlyFacing);

        Facing TurnRight(Facing currentlyFacing);
    }
}
