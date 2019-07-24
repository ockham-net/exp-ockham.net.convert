using System;

namespace Ockham.Data
{
    /// <summary>
    /// Flexible data conversion methods for converting between simple types
    /// </summary>
    public static partial class Convert
    {
        public static object Force(object value, Type targetType) => throw null;
        public static T Force<T>(object value) => throw null;
        public static T Force<T>(object value, T defaultValue) => throw null;
        public static T To<T>(object value) => throw null;
        public static T To<T>(object value, ConvertOptions options) => throw null;
        public static object To(object value, Type targetType) => throw null;
        public static object To(object value, Type targetType, ConvertOptions options) => throw null;
         
        public static object ToNull(object value, bool emptyStringAsNull = true) => throw null;
        public static object ToDBNull(object value, bool emptyStringAsNull = true) => throw null;
        public static object DefaultToDBNull<T>(T value) where T : struct => throw null;
        public static object DefaultToDBNull<T>(T value, T defaultValue) where T : struct => throw null;
        public static object DefaultToDBNull<T>(T? value) where T : struct => throw null;
        public static object DefaultToDBNull<T>(T? value, T defaultValue) where T : struct => throw null;
    }

    public static partial class Convert
    {
        // ------------------------------------------------------------------
        // ** HEY, YOU, DEVELOPER! **
        // 
        //  Do not modify this section directly!
        //  
        //  Update and rerun the code generating script Generate_Convert_Aliases_CSharp.ps1 with $instance = $false and $reference = $true
        // ------------------------------------------------------------------ 
        public static bool ToBool(object value) => throw null;
        public static DateTime ToDate(object value) => throw null;
        public static decimal ToDec(object value) => throw null;
        public static double ToDbl(object value) => throw null;
        public static Guid ToGuid(object value) => throw null;
        public static int ToInt(object value) => throw null;
        public static long ToLng(object value) => throw null;
        public static string ToStr(object value) => throw null;
        public static TimeSpan ToTimeSpan(object value) => throw null;
        public static bool ForceBool(object value) => throw null;
        public static DateTime ForceDate(object value) => throw null;
        public static decimal ForceDec(object value) => throw null;
        public static double ForceDbl(object value) => throw null;
        public static Guid ForceGuid(object value) => throw null;
        public static int ForceInt(object value) => throw null;
        public static long ForceLng(object value) => throw null;
        public static string ForceStr(object value) => throw null;
        public static TimeSpan ForceTimeSpan(object value) => throw null;
        public static bool ForceBool(object value, bool defaultValue) => throw null;
        public static DateTime ForceDate(object value, DateTime defaultValue) => throw null;
        public static decimal ForceDec(object value, decimal defaultValue) => throw null;
        public static double ForceDbl(object value, double defaultValue) => throw null;
        public static Guid ForceGuid(object value, Guid defaultValue) => throw null;
        public static int ForceInt(object value, int defaultValue) => throw null;
        public static long ForceLng(object value, long defaultValue) => throw null;
        public static string ForceStr(object value, string defaultValue) => throw null;
        public static TimeSpan ForceTimeSpan(object value, TimeSpan defaultValue) => throw null;
    }
}
