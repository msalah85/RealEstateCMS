using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
    public static class SqlDataReaderExtension
    {
        public static string ConvertToDateString(this SqlDataReader _DataRow, string CoulmnName)
        {
            object value = _DataRow[CoulmnName];

            if (value == null)
                return string.Empty;

            return value == null ? string.Empty : Convert.ToDateTime(value).ConvertDate();
        }

        public static string ConvertToString(this SqlDataReader _DataRow, string CoulmnName)
        {
            object value = _DataRow[CoulmnName];
            return Convert.ToString(ReturnEmptyIfNull(value));
        }

        #region Integ
        public static int ConvertToInt(this SqlDataReader _DataRow, string CoulmnName)
        {
            object value = _DataRow[CoulmnName];
            return Convert.ToInt32(ReturnZeroIfNull(value));
        }
        public static int? ConvertToNullableInt(this SqlDataReader _DataRow, string CoulmnName)
        {
            object value = _DataRow[CoulmnName];
            object ret = ReturNullIfNull(value);
            if (ret == null)
            {
                return null;
            }
            else
            {
                return Convert.ToInt32(ret);
            }
        }
        #endregion

        #region Short
        public static short ConvertToShort(this SqlDataReader _DataRow, string CoulmnName)
        {
            object value = _DataRow[CoulmnName];
            return short.Parse(ReturnZeroIfNull(value).ToString());
        }
        public static short? ConvertToNullableShort(this SqlDataReader _DataRow, string CoulmnName)
        {
            object value = _DataRow[CoulmnName];
            object ret = ReturNullIfNull(value);
            if (ret == null)
            {
                return null;
            }
            else
            {
                return short.Parse(ret.ToString());
            }
        }
        #endregion

        #region Byte
        public static byte ConvertToByte(this SqlDataReader _DataRow, string CoulmnName)
        {
            object value = _DataRow[CoulmnName];
            return Convert.ToByte(ReturnZeroIfNull(value));
        }
        public static byte? ConvertToNullableByte(this SqlDataReader _DataRow, string CoulmnName)
        {
            object value = _DataRow[CoulmnName];
            object ret = ReturNullIfNull(value);
            if (ret == null)
            {
                return null;
            }
            else
            {
                return Convert.ToByte(ret);
            }
        }
        #endregion



        public static long ConvertToLong(this SqlDataReader _DataRow, string CoulmnName)
        {
            object value = _DataRow[CoulmnName];
            return Convert.ToInt64(ReturnZeroIfNull(value));
        }

        public static decimal? ConvertToDecimal(this SqlDataReader _DataRow, string CoulmnName)
        {
            object value = _DataRow[CoulmnName];
            object ret = ReturNullIfNull(value);
            if (ret == null)
            {
                return null;
            }
            else
            {
                return Convert.ToDecimal(ret);
            }
        }
        public static decimal ConvertToNullableDecimal(this SqlDataReader _DataRow, string CoulmnName)
        {
            object value = _DataRow[CoulmnName];
            return Convert.ToDecimal(ReturnZeroIfNull(value));
        }
        public static bool ConvertToNullableBool(this SqlDataReader _DataRow, string CoulmnName)
        {
            object value = _DataRow[CoulmnName];
            return Convert.ToBoolean(ReturnZeroIfNull(value));
        }
        
        public static float? ConvertToFloat(this SqlDataReader _DataRow, string CoulmnName)
        {
            object value = _DataRow[CoulmnName];
            object ret = ReturNullIfNull(value);
            if (ret == null)
            {
                return null;
            }
            else
            {
                return Convert.ToSingle(ret);
            }
        }
        public static float ConvertToNullableFloat(this SqlDataReader _DataRow, string CoulmnName)
        {
            object value = _DataRow[CoulmnName];
            return Convert.ToSingle(ReturnZeroIfNull(value));
        }

        public static DateTime convertToDateTime(this SqlDataReader _DataRow, string CoulmnName)
        {
            object value = _DataRow[CoulmnName];
            return Convert.ToDateTime(ReturnDateTimeMinIfNull(value));
        }

       
        private static object ReturnEmptyIfNull(object value)
        {
            if (value == DBNull.Value)
                return string.Empty;
            if (value == null)
                return string.Empty;
            return value;
        }
        public static object ReturnZeroIfNull(object value)
        {
            if (value == DBNull.Value)
                return 0;
            if (value == null)
                return 0;
            return value;
        }
        public static object ReturnDateTimeMinIfNull(object value)
        {
            if (value == DBNull.Value)
                return DateTime.MinValue;
            if (value == null)
                return DateTime.MinValue;
            return value;
        }
        public static object ReturNullIfNull(object value)
        {
            if (value == DBNull.Value)
                return null;
            if (value == null)
                return null;
            return value;
        }
    }
}
