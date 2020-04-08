using System;

namespace Maze.Common
{
    public static class NullGuarder
    {
        public static T CheckIfNull<T>(this T objectToCheckForNull, string variableName) where T : class
        {
            if (objectToCheckForNull == null)
            {
                throw new ArgumentNullException(variableName);
            }

            return objectToCheckForNull;
        }
    }
}
