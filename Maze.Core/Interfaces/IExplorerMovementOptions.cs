
namespace Maze.Common
{
    public interface IExplorerMovementOptions
    {
        MovementOption[] GetAllMovementOptions();

        MovementOption GetMovementAheadOption();
    }
}
