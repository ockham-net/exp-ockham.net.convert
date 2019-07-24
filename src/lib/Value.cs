using System;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Ockham.Data
{
    /// <summary>
    /// Static method for inspecting values
    /// </summary>
    public static class Value
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
        /// Determine if the value represents the default value (Nothing in Visual Basic) for the value's type. 
        /// A value of null (Nothing in Visual Basic) will always return true.
        /// </summary> 
        public static bool IsDefault(object value)
        {
            if (value == null) return true;
            Type type = value.GetType();
            if (type.GetTypeInfo().IsValueType)
            {
                object defaultValue = Activator.CreateInstance(type);
                return object.Equals(value, defaultValue);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Returns true if the object is null or DBNull
        /// </summary>
        /// <param name="value">A value of any type</param> 
        public static bool IsNull(object value)
        {
            return value == null || value is DBNull;
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

        /// <summary>
        /// Returns true if the object is null, DBNull, or an empty string
        /// </summary>
        /// <param name="value">A value of any type</param> 
        public static bool IsNullOrEmpty(object value)
        {
            return value == null || value is DBNull || (value is string && ((string)value == string.Empty));
        }

        /// <summary>
        /// Returns true if the object is null, DBNull, or an empty or whitespace string
        /// </summary>
        /// <param name="value">A value of any type</param> 
        public static bool IsNullOrWhitespace(object value)
        {
            if (value == null) return true;
            if (value is DBNull) return true;
            if (value is string) return string.IsNullOrWhiteSpace((string)value);
            return false;
        }

    }
}
