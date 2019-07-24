using System;

namespace Ockham.Data
{
    // ------------------------------------------------------------------
    // ** HEY, YOU, DEVELOPER! **
    // 
    //  Do not modify this file directly!
    //  
    //  Update and rerun the code generating script Generate_Convert_Aliases_CSharp.ps1 with $instance = $false
    // ------------------------------------------------------------------

    // Type-specific conversion wrappers for underlying To and Force methods.  
    public static partial class Convert
    {

        /// <summary>
        /// Convert any input value to an equivalent boolean value. Attempting to convert
        /// a value that has no meaningful boolean equivalent, including an empty value,
        /// will cause an <see cref="System.InvalidCastException" /> to be raised.
        /// </summary>
        /// <param name="value">Any value</param>
        /// <seealso cref="Ockham.Data.Convert.To{T}(Object)"/>
        public static bool ToBool(object value)
        {
            if (value is bool) { return (bool)value; }
            return To<bool>(value);
        }

        /// <summary>
        /// Convert any input value to an equivalent date time value. Attempting to convert
        /// a value that has no meaningful date or time equivalent, including an empty value,
        /// will cause an <see cref="System.InvalidCastException" /> to be raised.
        /// </summary>
        /// <param name="value">Any value</param>
        /// <seealso cref="Ockham.Data.Convert.To{T}(Object)"/>
        public static DateTime ToDate(object value)
        {
            if (value is DateTime) { return (DateTime)value; }
            return To<DateTime>(value);
        }

        /// <summary>
        /// Convert any input value to an equivalent exact decimal value. Attempting to convert
        /// a value that has no meaningful decimal equivalent, including an empty value,
        /// will cause an <see cref="System.InvalidCastException" /> to be raised.
        /// </summary>
        /// <param name="value">Any value</param>
        /// <seealso cref="Ockham.Data.Convert.To{T}(Object)"/>
        public static decimal ToDec(object value)
        {
            if (value is decimal) { return (decimal)value; }
            return To<decimal>(value);
        }

        /// <summary>
        /// Convert any input value to an equivalent double-precision floating point number value. Attempting to convert
        /// a value that has no meaningful floating point equivalent, including an empty value,
        /// will cause an <see cref="System.InvalidCastException" /> to be raised.
        /// </summary>
        /// <param name="value">Any value</param>
        /// <seealso cref="Ockham.Data.Convert.To{T}(Object)"/>
        public static double ToDbl(object value)
        {
            if (value is double) { return (double)value; }
            return To<double>(value);
        }

        /// <summary>
        /// Convert any input value to an equivalent 128-bit globally unique identifier value. Attempting to convert
        /// a value that has no meaningful GUID equivalent, including an empty value,
        /// will cause an <see cref="System.InvalidCastException" /> to be raised.
        /// </summary>
        /// <param name="value">Any value</param>
        /// <seealso cref="Ockham.Data.Convert.To{T}(Object)"/>
        public static Guid ToGuid(object value)
        {
            if (value is Guid) { return (Guid)value; }
            return To<Guid>(value);
        }

        /// <summary>
        /// Convert any input value to an equivalent 32-bit signed integer value. Attempting to convert
        /// a value that has no meaningful integer equivalent, including an empty value,
        /// will cause an <see cref="System.InvalidCastException" /> to be raised.
        /// </summary>
        /// <param name="value">Any value</param>
        /// <seealso cref="Ockham.Data.Convert.To{T}(Object)"/>
        public static int ToInt(object value)
        {
            if (value is int) { return (int)value; }
            return To<int>(value);
        }

        /// <summary>
        /// Convert any input value to an equivalent 64-bit signed integer value. Attempting to convert
        /// a value that has no meaningful integer equivalent, including an empty value,
        /// will cause an <see cref="System.InvalidCastException" /> to be raised.
        /// </summary>
        /// <param name="value">Any value</param>
        /// <seealso cref="Ockham.Data.Convert.To{T}(Object)"/>
        public static long ToLng(object value)
        {
            if (value is long) { return (long)value; }
            return To<long>(value);
        }

        /// <summary>
        /// Convert any input value to an equivalent string value. Attempting to convert
        /// a value that has no meaningful string equivalent, including an empty value,
        /// will cause an <see cref="System.InvalidCastException" /> to be raised.
        /// </summary>
        /// <param name="value">Any value</param>
        /// <seealso cref="Ockham.Data.Convert.To{T}(Object)"/>
        public static string ToStr(object value)
        {
            if (value is string) { return (string)value; }
            return To<string>(value);
        }

        /// <summary>
        /// Convert any input value to an equivalent timespan value. Attempting to convert
        /// a value that has no meaningful timespan equivalent, including an empty value,
        /// will cause an <see cref="System.InvalidCastException" /> to be raised.
        /// </summary>
        /// <param name="value">Any value</param>
        /// <seealso cref="Ockham.Data.Convert.To{T}(Object)"/>
        public static TimeSpan ToTimeSpan(object value)
        {
            if (value is TimeSpan) { return (TimeSpan)value; }
            return To<TimeSpan>(value);
        }

        /// <summary>
        /// Convert any input value to an equivalent boolean value. If the input is empty
        /// or has no meaningful boolean equivalent, False is returned.
        /// </summary>
        /// <param name="value">Any value</param>
        /// <seealso cref="Ockham.Data.Convert.Force{T}(Object)"/>
        public static bool ForceBool(object value)
        {
            if (value is bool) { return (bool)value; }
            return Force<bool>(value);
        }

        /// <summary>
        /// Convert any input value to an equivalent date time value. If the input is empty
        /// or has no meaningful date or time equivalent, DateTime.MinValue is returned.
        /// </summary>
        /// <param name="value">Any value</param>
        /// <seealso cref="Ockham.Data.Convert.Force{T}(Object)"/>
        public static DateTime ForceDate(object value)
        {
            if (value is DateTime) { return (DateTime)value; }
            return Force<DateTime>(value);
        }

        /// <summary>
        /// Convert any input value to an equivalent exact decimal value. If the input is empty
        /// or has no meaningful decimal equivalent, 0 is returned.
        /// </summary>
        /// <param name="value">Any value</param>
        /// <seealso cref="Ockham.Data.Convert.Force{T}(Object)"/>
        public static decimal ForceDec(object value)
        {
            if (value is decimal) { return (decimal)value; }
            return Force<decimal>(value);
        }

        /// <summary>
        /// Convert any input value to an equivalent double-precision floating point number value. If the input is empty
        /// or has no meaningful floating point equivalent, 0 is returned.
        /// </summary>
        /// <param name="value">Any value</param>
        /// <seealso cref="Ockham.Data.Convert.Force{T}(Object)"/>
        public static double ForceDbl(object value)
        {
            if (value is double) { return (double)value; }
            return Force<double>(value);
        }

        /// <summary>
        /// Convert any input value to an equivalent 128-bit globally unique identifier value. If the input is empty
        /// or has no meaningful GUID equivalent, Guid.Empty is returned.
        /// </summary>
        /// <param name="value">Any value</param>
        /// <seealso cref="Ockham.Data.Convert.Force{T}(Object)"/>
        public static Guid ForceGuid(object value)
        {
            if (value is Guid) { return (Guid)value; }
            return Force<Guid>(value);
        }

        /// <summary>
        /// Convert any input value to an equivalent 32-bit signed integer value. If the input is empty
        /// or has no meaningful integer equivalent, 0 is returned.
        /// </summary>
        /// <param name="value">Any value</param>
        /// <seealso cref="Ockham.Data.Convert.Force{T}(Object)"/>
        public static int ForceInt(object value)
        {
            if (value is int) { return (int)value; }
            return Force<int>(value);
        }

        /// <summary>
        /// Convert any input value to an equivalent 64-bit signed integer value. If the input is empty
        /// or has no meaningful integer equivalent, 0 is returned.
        /// </summary>
        /// <param name="value">Any value</param>
        /// <seealso cref="Ockham.Data.Convert.Force{T}(Object)"/>
        public static long ForceLng(object value)
        {
            if (value is long) { return (long)value; }
            return Force<long>(value);
        }

        /// <summary>
        /// Convert any input value to an equivalent string value. If the input is empty
        /// or has no meaningful string equivalent, null is returned.
        /// </summary>
        /// <param name="value">Any value</param>
        /// <seealso cref="Ockham.Data.Convert.Force{T}(Object)"/>
        public static string ForceStr(object value)
        {
            if (value is string) { return (string)value; }
            return Force<string>(value);
        }

        /// <summary>
        /// Convert any input value to an equivalent timespan value. If the input is empty
        /// or has no meaningful timespan equivalent, Timespan.zero is returned.
        /// </summary>
        /// <param name="value">Any value</param>
        /// <seealso cref="Ockham.Data.Convert.Force{T}(Object)"/>
        public static TimeSpan ForceTimeSpan(object value)
        {
            if (value is TimeSpan) { return (TimeSpan)value; }
            return Force<TimeSpan>(value);
        }

        /// <summary>
        /// Convert any input value to an equivalent boolean value. If the input is empty
        /// or has no meaningful boolean equivalent the provided default value is returned.
        /// </summary>
        /// <param name="value">Any value</param>
        /// <param name="defaultValue">A value to return if the input is empty or cannot be converted</param>
        /// <seealso cref="Ockham.Data.Convert.Force{T}(Object, T)"/>
        public static bool ForceBool(object value, bool defaultValue)
        {
            if (value is bool) { return (bool)value; }
            return Force<bool>(value, defaultValue);
        }

        /// <summary>
        /// Convert any input value to an equivalent date time value. If the input is empty
        /// or has no meaningful date or time equivalent the provided default value is returned.
        /// </summary>
        /// <param name="value">Any value</param>
        /// <param name="defaultValue">A value to return if the input is empty or cannot be converted</param>
        /// <seealso cref="Ockham.Data.Convert.Force{T}(Object, T)"/>
        public static DateTime ForceDate(object value, DateTime defaultValue)
        {
            if (value is DateTime) { return (DateTime)value; }
            return Force<DateTime>(value, defaultValue);
        }

        /// <summary>
        /// Convert any input value to an equivalent exact decimal value. If the input is empty
        /// or has no meaningful decimal equivalent the provided default value is returned.
        /// </summary>
        /// <param name="value">Any value</param>
        /// <param name="defaultValue">A value to return if the input is empty or cannot be converted</param>
        /// <seealso cref="Ockham.Data.Convert.Force{T}(Object, T)"/>
        public static decimal ForceDec(object value, decimal defaultValue)
        {
            if (value is decimal) { return (decimal)value; }
            return Force<decimal>(value, defaultValue);
        }

        /// <summary>
        /// Convert any input value to an equivalent double-precision floating point number value. If the input is empty
        /// or has no meaningful floating point equivalent the provided default value is returned.
        /// </summary>
        /// <param name="value">Any value</param>
        /// <param name="defaultValue">A value to return if the input is empty or cannot be converted</param>
        /// <seealso cref="Ockham.Data.Convert.Force{T}(Object, T)"/>
        public static double ForceDbl(object value, double defaultValue)
        {
            if (value is double) { return (double)value; }
            return Force<double>(value, defaultValue);
        }

        /// <summary>
        /// Convert any input value to an equivalent 128-bit globally unique identifier value. If the input is empty
        /// or has no meaningful GUID equivalent the provided default value is returned.
        /// </summary>
        /// <param name="value">Any value</param>
        /// <param name="defaultValue">A value to return if the input is empty or cannot be converted</param>
        /// <seealso cref="Ockham.Data.Convert.Force{T}(Object, T)"/>
        public static Guid ForceGuid(object value, Guid defaultValue)
        {
            if (value is Guid) { return (Guid)value; }
            return Force<Guid>(value, defaultValue);
        }

        /// <summary>
        /// Convert any input value to an equivalent 32-bit signed integer value. If the input is empty
        /// or has no meaningful integer equivalent the provided default value is returned.
        /// </summary>
        /// <param name="value">Any value</param>
        /// <param name="defaultValue">A value to return if the input is empty or cannot be converted</param>
        /// <seealso cref="Ockham.Data.Convert.Force{T}(Object, T)"/>
        public static int ForceInt(object value, int defaultValue)
        {
            if (value is int) { return (int)value; }
            return Force<int>(value, defaultValue);
        }

        /// <summary>
        /// Convert any input value to an equivalent 64-bit signed integer value. If the input is empty
        /// or has no meaningful integer equivalent the provided default value is returned.
        /// </summary>
        /// <param name="value">Any value</param>
        /// <param name="defaultValue">A value to return if the input is empty or cannot be converted</param>
        /// <seealso cref="Ockham.Data.Convert.Force{T}(Object, T)"/>
        public static long ForceLng(object value, long defaultValue)
        {
            if (value is long) { return (long)value; }
            return Force<long>(value, defaultValue);
        }

        /// <summary>
        /// Convert any input value to an equivalent string value. If the input is empty
        /// or has no meaningful string equivalent the provided default value is returned.
        /// </summary>
        /// <param name="value">Any value</param>
        /// <param name="defaultValue">A value to return if the input is empty or cannot be converted</param>
        /// <seealso cref="Ockham.Data.Convert.Force{T}(Object, T)"/>
        public static string ForceStr(object value, string defaultValue)
        {
            if (value is string) { return (string)value; }
            return Force<string>(value, defaultValue);
        }

        /// <summary>
        /// Convert any input value to an equivalent timespan value. If the input is empty
        /// or has no meaningful timespan equivalent the provided default value is returned.
        /// </summary>
        /// <param name="value">Any value</param>
        /// <param name="defaultValue">A value to return if the input is empty or cannot be converted</param>
        /// <seealso cref="Ockham.Data.Convert.Force{T}(Object, T)"/>
        public static TimeSpan ForceTimeSpan(object value, TimeSpan defaultValue)
        {
            if (value is TimeSpan) { return (TimeSpan)value; }
            return Force<TimeSpan>(value, defaultValue);
        }

    }
}
