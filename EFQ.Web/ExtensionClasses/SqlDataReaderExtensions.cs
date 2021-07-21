using System;
using System.ComponentModel;
using Microsoft.Data.SqlClient;

namespace JDege.EFQ.Web.Extensions
{
    /// <summary>
    /// Getting data out of a SqlDataReader is far more complicated than it should be
    /// </summary>
    public static class SqlDataReaderExtension
    {
        private static bool isNullableType(Type type)
        {
            return (type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>)));
        }

        /// <summary>
        /// Returns the value of a column from a SqlDataReader, cast to the appropriate type
        /// </summary>
        /// <typeparam name="T">Type to cast to</typeparam>
        /// <param name="rdr">The SqlDataReader object that queried the database</param>
        /// <param name="columnName">The column of data to retrieve a value from</param>
        /// <returns>T, type applied; default value of type if database value is null</returns>
        public static T getValue<T>(this SqlDataReader rdr, string columnName)
        {
            var value = rdr[columnName];

            if (value == DBNull.Value)
                return default(T);

            var type = typeof(T);

            if (!isNullableType(type))
                return (T)Convert.ChangeType(value, type);

            var theNullableConverter = new NullableConverter(type);
            return (T)Convert.ChangeType(value, theNullableConverter.UnderlyingType);
        }
    }
}

