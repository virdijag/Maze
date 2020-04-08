using FluentAssertions;
using Moq;
using System;
using System.Linq;
using System.Reflection;

namespace Maze.Tests
{
    public class AssertionHelper
    {
        public static void CheckContructorForNullParameters<T>()
        {
            var ctor = typeof(T).GetConstructors().First();
            var parameters = ctor.GetParameters();

            ParametersHaveToBeInterfaces(parameters);

            for (int i = 0; i < parameters.Length; i++)
            {
                var mocks = parameters.Select((prm, idx) => idx == i ? null : GetMockedParameter(prm.ParameterType)).ToArray();
                Action ctorInocation = () => ctor.Invoke(mocks);

                var expectedInnerMessage = string.Format("Value cannot be null.\r\nParameter name: {0}", parameters.ElementAt(i).Name);
                ctorInocation.ShouldThrow<TargetInvocationException>().WithInnerException<ArgumentNullException>().WithInnerMessage(expectedInnerMessage);
            }
        }

        private static void ParametersHaveToBeInterfaces(ParameterInfo[] parameters)
        {
            parameters.All(x => x.ParameterType.IsInterface || x.ParameterType.IsClass).Should().BeTrue("All parameters should be interfaces or classes to use CheckContructorForNullParameters");
        }

        private static object GetMockedParameter(Type parameterType)
        {
            return ((dynamic)Activator.CreateInstance(typeof(Mock<>).MakeGenericType(parameterType))).Object;
        }
    }
}
