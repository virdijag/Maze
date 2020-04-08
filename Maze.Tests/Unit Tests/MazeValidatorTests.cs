using  Maze.Common;
using FluentAssertions;
using Maze.Tests.Test_Values;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maze.Tests.Unit_Tests
{
    [TestClass]
    public class MazeValidatorTests
    {
        private IMazeValidator mazeValidator;

        [TestInitialize]
        public void Init() => this.mazeValidator = new MazeValidator();
        
        [TestMethod]
        public void 
            Should_Check_Has_Only_One_Start_S_Exists_When_Loaded_With_Valid_MazeData_Expect_True_To_Be_Returned() =>
            this.mazeValidator.HasOnlyOneStart(MazeTestValues.GetValidMazeCellElements()).Should().BeTrue();
        
        [TestMethod]
        public void 
            Should_Check_Has_MoreThan_One_Start_S_Exists_When_Loaded_With_Invalid_MazeData_Expect_False_To_Be_Returned() =>
            this.mazeValidator.HasOnlyOneStart(MazeTestValues.GetInValidMazeCellElements()).Should().BeFalse();

        [TestMethod]
        public void 
            Should_Check_Has_Only_One_Exit_F_Exists_When_Loaded_With_Valid_MazeData_Expect_True_To_Be_Returned() =>
            this.mazeValidator.HasOnlyOneExit(MazeTestValues.GetValidMazeCellElements()).Should().BeTrue();
        
        [TestMethod]
        public void
            Should_Check_Has_MoreThan_One_Exit_F_Exists_When_Loaded_With_Invalid_MazeData_Expect_False_To_Be_Returned() =>
            this.mazeValidator.HasOnlyOneExit(MazeTestValues.GetInValidMazeCellElements()).Should().BeFalse();
        
        [TestMethod]
        public void
            Should_Check_Is_Maze_Valid_When_Loaded_With_Valid_MazeData_Expect_True_To_Be_Returned() =>
            this.mazeValidator.IsMazeValid(MazeTestValues.ValidMazeExample()).Should().BeTrue();
        
        [TestMethod]
        public void
            Should_Check_Is_Not_Maze_Valid_When_Loaded_With_InValid_MazeData_Expect_False_To_Be_Returned() =>
            this.mazeValidator.IsMazeValid(MazeTestValues.InValidMazeExample()).Should().BeFalse();           
    }
}
