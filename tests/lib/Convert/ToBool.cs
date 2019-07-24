using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Ockham.Data.Tests
{
    public class ToBool
    {
        private static readonly string[] TRUTHY_STRINGS = new[]
            {
                "x",
                "t",
                "y",
                "yes",
                "true",
                "1",
                "-1",
                "yea",
                "aye",
                "on",
                "checked"
            };

        private static readonly string[] FALSY_STRINGS = new[]
            {
               "f",
               "n",
               "no",
               "false",
               "0",
               "nay",
               "off",
               "unchecked"
            };

        public static IEnumerable<object[]> TruthyStrings() => TRUTHY_STRINGS.AsObjectArray();

        public static IEnumerable<object[]> FalsyStrings() => FALSY_STRINGS.AsObjectArray();

        public static IEnumerable<object[]> NonZeroNumbers() => Enumerable.Range(1, 5).Concat(Enumerable.Range(-6, 5)).AsObjectArray();

        public static IEnumerable<object[]> Bools() => (new[] { false, true }).AsObjectArray();

        [Theory(DisplayName = "Convert.ToBool:Truthy strings convert to true")]
        [MemberData(nameof(TruthyStrings))]
        public void StringToTrue(string input)
        {
            ConvertAssert.Equal(true, Convert.ToBool(input));
        }

        [Theory(DisplayName = "Convert.ToBool:Falsy strings convert to false")]
        [MemberData(nameof(FalsyStrings))]
        public void StringToFalse(string input)
        {
            ConvertAssert.Equal(false, Convert.ToBool(input));
        }

        [Theory(DisplayName = "Convert.ToBool:Non zero integers convert to true")]
        [MemberData(nameof(NonZeroNumbers))]
        public void NonZeroToTrue(int input)
        {
            ConvertAssert.Equal(true, Convert.ToBool(input));
        }

        [Theory(DisplayName = "Convert.ToBool:0 converts to false")]
        [MemberData(nameof(TestPrimitives.Zeros), MemberType = typeof(TestPrimitives))]
        public void ZeroToFalse(object input)
        {
            ConvertAssert.Equal(false, Convert.ToBool(input));
        }

        [Theory(DisplayName = "Convert.ToBool:Boolean values preserved")]
        [MemberData(nameof(Bools))]
        public void BoolsPreserved(bool input)
        {
            ConvertAssert.Equal(input, Convert.ToBool(input));
        }

        [Theory(DisplayName = "Convert.ToBool:Unconvertible throws exception")]
        [MemberData(nameof(TestPrimitives.Unconvertible), MemberType = typeof(TestPrimitives))]
        public void GarbageInThrows(object input)
        {
            Assert.Throws<InvalidCastException>(() => Convert.ToBool(input));
        }

    }
}
