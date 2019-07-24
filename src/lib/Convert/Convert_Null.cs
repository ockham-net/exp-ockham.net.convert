using System;

namespace Ockham.Data
{
    // Methods for detecting empty values, and converting to or from empty value types
    public static partial class Convert
    {
        /// <summary>
        /// Converts null, DBNull, or an empty string to null
        /// </summary>
        /// <param name="value">A value of any type</param>
        /// <param name="emptyStringAsNull">Whether to treat empty strings as null</param> 
        public static object ToNull(object value, bool emptyStringAsNull = true)
        {
            return (ValueInspection.IsNull(value, emptyStringAsNull) ? null : value);
        }

        /// <summary>
        /// Converts null, DBNull, or an empty string to DBNull
        /// </summary>
        /// <param name="value">A value of any type</param>
        /// <param name="emptyStringAsNull">Whether to treat empty strings as null</param> 
        public static object ToDBNull(object value, bool emptyStringAsNull = true)
        {
            return (ValueInspection.IsNull(value, emptyStringAsNull) ? DBNull.Value : value);
        }

        /// <summary>
        /// Converts the default value of a type to DBNull
        /// </summary> 
        public static object DefaultToDBNull<T>(T value) where T : struct
        {
            T defaultValue = default(T);
            if (object.Equals(value, defaultValue))
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Converts the explicitly provided default value of a value type to DBNull
        /// </summary> 
        public static object DefaultToDBNull<T>(T value, T defaultValue) where T : struct
        {
            if (object.Equals(value, defaultValue))
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Converts a null reference or default value of a nullable value type to DBNull
        /// </summary> 
        /// <remarks>This will return DBNull if <paramref name="value"/>.<see cref="Nullable{T}.HasValue"/> is false,
        /// or if <paramref name="value"/>.<see cref="Nullable{T}.HasValue"/> is true and <paramref name="value"/>.<see cref="Nullable{T}.Value"/> equals default(<typeparamref name="T"/>) </remarks>
        public static object DefaultToDBNull<T>(T? value) where T : struct
        {
            if (!value.HasValue) return DBNull.Value;
            return DefaultToDBNull(value.Value);
        }

        /// <summary>
        /// Converts a null reference or default value of a nullable value type to DBNull
        /// </summary> 
        /// <remarks>This will return DBNull if <paramref name="value"/>.<see cref="Nullable{T}.HasValue"/> is false,
        /// or if <paramref name="value"/>.<see cref="Nullable{T}.HasValue"/> is true and <paramref name="value"/>.<see cref="Nullable{T}.Value"/> equals <paramref name="defaultValue"/></remarks>
        public static object DefaultToDBNull<T>(T? value, T defaultValue) where T : struct
        {
            if (!value.HasValue) return DBNull.Value;
            return DefaultToDBNull(value.Value, defaultValue);
        }
    }
}