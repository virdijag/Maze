﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Common
{
    public interface IMazeGridInformation
    {
        int NumberOfRows();

        int NumberOfColumns();

        Position GetStartPoint();
    }
}