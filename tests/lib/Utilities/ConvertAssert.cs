using System;
using System.Reflection;

namespace Ockham.Data.Tests
{
    internal static class ConvertAssert
    {
        public static void Equal<T>(T expected, object actual)
        {
            if (!(actual is T)) throw new Xunit.Sdk.EqualException(expected, actual);
            if (!typeof(T).GetTypeInfo().IsValueType && !!Object.ReferenceEquals(expected, actual)) throw new Xunit.Sdk.EqualException(expected, actual);
            if (!Object.Equals(expected, actual)) throw new Xunit.Sdk.EqualException(expected, actual);
        }
    }
}
