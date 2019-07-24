using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using static Ockham.Data.Tests.TestPrimitives;

namespace Ockham.Data.Tests
{
    public class ToTimespan
    {
        public static IEnumerable<object[]> Unconvertible => (new object[]
        {
            "Hello",
            new object(),
            (Func<int>)(() => 42)
        }).AsObjectArray();

        public static IEnumerable<object[]> ComplexStrings => new[]
        {
            Pair("0:02.231", new TimeSpan(0, 0, 0, 2, 231)),
            Pair("5:14", new TimeSpan(0, 0, 5, 14, 0)),
            Pair("5:14.129", new TimeSpan(0, 0, 5, 14, 129)),
            Pair("01:00.010", new TimeSpan(0, 0, 1, 0, 10)),
            Pair("3:12:00.000", new TimeSpan(0, 3, 12, 0, 0)),
            Pair("231.3:12:00.000", new TimeSpan(231, 3, 12, 0, 0))
        };

        public static IEnumerable<object[]> Timespans => ComplexStrings.Select(arr => arr[1]).AsObjectArray();


        [Theory(DisplayName = "Convert.ToTimestamp:Timespans preserved")]
        [MemberData(nameof(Timespans))]
        public void PreserveTimestamp(TimeSpan input)
        {
            ConvertAssert.Equal(input, Convert.ToTimeSpan(input));
        }

        [Theory(DisplayName = "Convert.ToTimestamp:Decimal strings as seconds")]
        [MemberData(nameof(TestPrimitives.DeimalStrings), MemberType = typeof(TestPrimitives))]
        public void DecimalSecondsToTimespan(object input)
        {
            double dblVal = Convert.To<double>(input);
            ConvertAssert.Equal(TimeSpan.FromSeconds(dblVal), Convert.ToTimeSpan(input));
        }

        [Theory(DisplayName = "Convert.ToTimestamp:Numbers as ticks")]
        [MemberData(nameof(TestPrimitives.WholeNumeric), MemberType = typeof(TestPrimitives))]
        public void TicksToTimespan(object input)
        {
            long lngVal = Convert.To<long>(input);
            ConvertAssert.Equal(TimeSpan.FromTicks(lngVal), Convert.ToTimeSpan(input));
        }

        [Theory(DisplayName = "Convert.ToTimestamp:Elapsed time strings")]
        [MemberData(nameof(ComplexStrings))]
        public void TimestringToTimespan(object input, TimeSpan expected)
        {
            ConvertAssert.Equal(expected, Convert.ToTimeSpan(input));
        }

        [Theory(DisplayName = "Convert.ToTimestamp:Unconvertible throws exception")]
        [MemberData(nameof(Unconvertible))]
        public void GarbageInThrows(object input)
        {
            Assert.Throws<InvalidCastException>(() => Convert.ToTimeSpan(input));
        }

    }
}
