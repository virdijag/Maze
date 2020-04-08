using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using  Maze.Common;
using FluentAssertions;
using Maze.Tests.Test_Values;

namespace Maze.Tests.Integration_Tests
{
    [TestClass]
    public class MazeFileLoaderTests
    {
        [TestMethod]
        public void Should_Be_Able_To_Load_MazeFile_Expect_MazeFile_Is_Same_When_Loaded()
        {
            string mazeFileName = "ExampleMaze.txt";
            IMazeLoader mazeFileLoader = new MazeFileLoader(mazeFileName);
            mazeFileLoader.LoadMaze().Should().NotBeNull();
            mazeFileLoader.LoadMaze().Should().BeEquivalentTo(MazeTestValues.ValidMazeExample());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Should_Throw_Exception_When_MazeFileName_IsEmpty_Expect_Argument_Null_Exception()
        {
            string mazeFileName = string.Empty;
            IMazeLoader mazeFileLoader = new MazeFileLoader(mazeFileName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Should_Throw_Exception_When_MazeFileName_IsNull_Expect_Argument_Null_Exception()
        {
            string mazeFileName = null;
            IMazeLoader mazeFileLoader = new MazeFileLoader(mazeFileName);
        }      
    }
}
