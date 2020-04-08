using System.Linq;
using System.Text;

namespace Maze.Common
{
    public sealed class MazeValidator : IMazeValidator
    {
        private const string Start = "S";
        private const string Exit = "F";

        public MazeValidator()
        {
        }

        public bool HasOnlyOneStart(string mazeCellElements) => this.HasOnlyOne(Start, mazeCellElements);
        
        public bool HasOnlyOneExit(string mazeCellElements) =>  this.HasOnlyOne(Exit, mazeCellElements);
                
        public bool IsMazeValid(string[] mazeRows)
        {
            var mazeCellElements = this.GetMazeCellElements(mazeRows);
            return this.HasOnlyOneExit(mazeCellElements) && this.HasOnlyOneStart(mazeCellElements);
        }

        // internal for testing
        internal bool HasOnlyOne(string cellValue, string mazeCellElements) => mazeCellElements.Where(x => x.ToString() == cellValue).Count() == 1;
        
        // internal for testing
        internal string GetMazeCellElements(string[] mazeRows)
        {
            StringBuilder builder = new StringBuilder();

            foreach (var row in mazeRows)
            {
                builder.Append(row);
            }

            return builder.ToString();
        }
    }
}
