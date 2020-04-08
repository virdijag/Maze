namespace Maze.Common
{ 
    public sealed class Maze : IMaze
    {
        private readonly IMazeGridGenerator mazeGridGenerator;
        private string[,] grid = null;

        public Maze(IMazeGridGenerator mazeGridGenerator) =>  this.mazeGridGenerator = mazeGridGenerator.CheckIfNull(nameof(mazeGridGenerator));
        
        public string[,] Grid
        {
            get
            {
                if (grid == null)
                {
                    return this.mazeGridGenerator.CreateGrid();
                }
                return grid;
            }
        }

        public string DisplayCellValue(Position position) => this.Grid[position.xCoordinate, position.yCoordinate];
        
        public string[] DisplayGrid() => this.mazeGridGenerator.DisplayGrid();
                
        public Position DisplayStartPoint() => this.mazeGridGenerator.GetStartPoint();
    }
}
