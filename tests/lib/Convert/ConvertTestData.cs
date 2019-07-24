using System;
using System.Collections.Generic;
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

    internal class OptionsPermutation
    {
        public OptionsPermutation(ConvertOptions pOptions, bool pIgnoreError, object pDefaultValue)
        {
            this.ConvertOptions = pOptions;
            this.IgnoreError = pIgnoreError;
            this.DefaultValue = pDefaultValue;
        }

        public ConvertOptions ConvertOptions { get; set; }
        public bool IgnoreError { get; set; }
        public object DefaultValue { get; set; }

        /// <summary>
        /// Generate a list of all 12 permutations of convert options, ignore error, and default value
        /// </summary> 
        public static List<OptionsPermutation> GetAll(object pDefaultValue)
        {
            return new List<OptionsPermutation>()
            {
                new OptionsPermutation(ConvertOptions.None, false, null),
                new OptionsPermutation(ConvertOptions.EmptyStringAsNull, false, null),
                new OptionsPermutation(ConvertOptions.NullToValueDefault, false, null),

                new OptionsPermutation(ConvertOptions.None, true, null),
                new OptionsPermutation(ConvertOptions.EmptyStringAsNull, true, null),
                new OptionsPermutation(ConvertOptions.NullToValueDefault, true, null),

                new OptionsPermutation(ConvertOptions.None, false, pDefaultValue),
                new OptionsPermutation(ConvertOptions.EmptyStringAsNull, false, pDefaultValue),
                new OptionsPermutation(ConvertOptions.NullToValueDefault, false, pDefaultValue),

                new OptionsPermutation(ConvertOptions.None, true, pDefaultValue),
                new OptionsPermutation(ConvertOptions.EmptyStringAsNull, true, pDefaultValue),
                new OptionsPermutation(ConvertOptions.NullToValueDefault, true, pDefaultValue)
            };
        }


    }

    public enum TestShortEnum : short
    {
        One = 1,
        FortyNine = 49
    }
     
    public static class ConvertTestData
    {

        public static readonly List<object> Int49Inputs = new List<object>()
        {
            49m,            // decimal
            (byte)49,       // byte
            (ushort)49,     // ushort
            49L,            // long
            49D,            // double
            "49",           // simple string
            //"0x31",         // C# hex string
            //" &h31\r\n",    // VB hex string with whitespace
            "4.9e+1",       // Scientific
            TestShortEnum.FortyNine  // Enum
        };

        public static readonly List<object> Int49Numbers = new List<object>()
        {
            49m,            // decimal
            (byte)49,       // byte
            (ushort)49,     // ushort
            49L,            // long
            49D,            // double
            TestShortEnum.FortyNine  // Enum
        };

        public static readonly List<object> EmptyInputs = new List<object>() { null, DBNull.Value };

    }
}
