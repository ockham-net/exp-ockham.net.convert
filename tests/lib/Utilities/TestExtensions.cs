using System.Collections.Generic;
using System.Linq;

namespace Ockham.Data.Tests
{
    public static class TestExtensions
    {
        public static IEnumerable<object[]> AsObjectArray<T>(this IEnumerable<T> source)
        {
            return source.Select(x => new object[] { x });
        }

    }
}
