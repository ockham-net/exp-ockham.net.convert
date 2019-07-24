using System;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Ockham.Data
{ 
    internal static class ValueInspection
    {

        /// <summary>
        /// Test if the input value is a non-null numeric type 
        /// or a string that can be parsed as a number. Valid hexadecimal strings
        /// are not treated as numbers.
        /// </summary>
        /// <remarks>To detect valid hexadecimal strings, use <see cref="IsNumeric(object, ConvertOptions)"/></remarks>
        /// <param name="value"></param> 
        public static bool IsNumeric(object value)
        {
            return IsNumeric(value, (ConvertOptions)0);
        }

        /// <summary>
        /// Test if the input value is a non-null numeric type 
        /// or a string that can be parsed as a number, with detection
        /// of hex strings controlled by ConvertOptions flags
        /// </summary>
        /// <param name="value"></param> 
        /// <param name="options"></param>  
        public static bool IsNumeric(object value, ConvertOptions options)
        {
            if (value == null) return false;
            if (value is string sValue)
            {
                if (double.TryParse(sValue, out double d)) return true;
                if (options.HasFlag(ConvertOptions.AllowVBHex) && Regex.IsMatch(sValue, @"^\s*&[hH][0-9a-fA-F]+$")) return true;
                if (options.HasFlag(ConvertOptions.Allow0xHex) && Regex.IsMatch(sValue, @"^\s*0[xX][0-9a-fA-F]+$")) return true;
                return false;
            }
            return TypeInspection.IsNumberType(value.GetType());
        }

        /// <summary>
        /// Test whether the input value is null or DBNull. Will also return true if <paramref name="emptyStringAsNull"/> is true and <paramref name="value"/> is an empty string.
        /// </summary> 
        public static bool IsNull(object value, bool emptyStringAsNull)
        {
            if (value == null) return true;
            if (value is DBNull) return true;
            if (emptyStringAsNull && (value is string) && ((string)value) == string.Empty) return true;
            return false;
        }

        /// <summary>
        /// Test whether the input value is null or DBNull. Will also return true if <paramref name="options"/>
        /// includes the <see cref="ConvertOptions.EmptyStringAsNull"/> flag and <paramref name="value"/> is an empty string.
        /// </summary> 
        public static bool IsNull(object value, ConvertOptions options)
        {
            return IsNull(value, options.HasFlag(ConvertOptions.EmptyStringAsNull));
        }
         
    }
}
