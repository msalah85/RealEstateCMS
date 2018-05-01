using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
    public static class DataRowExtension
    {
        public static string ConvertToDateString(this DataRow _DataRow, string CoulmnName)
        {
            object value = _DataRow[CoulmnName];

            if (value == null)
                return string.Empty;

            return value == null ? string.Empty : Convert.ToDateTime(value).ConvertDate();
        }

        public static string ConvertToString(this DataRow _DataRow, string CoulmnName)
        {
            object value = _DataRow[CoulmnName];
            return Convert.ToString(ReturnEmptyIfNull(value));
        }

        #region Integ
        public static int ConvertToInt(this DataRow _DataRow, string CoulmnName)
        {
            object value = _DataRow[CoulmnName];
            return Convert.ToInt32(ReturnZeroIfNull(value));
        }
        public static int? ConvertToNullableInt(this DataRow _DataRow, string CoulmnName)
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
        public static short ConvertToShort(this DataRow _DataRow, string CoulmnName)
        {
            object value = _DataRow[CoulmnName];
            return short.Parse(ReturnZeroIfNull(value).ToString());
        }
        public static short? ConvertToNullableShort(this DataRow _DataRow, string CoulmnName)
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
        public static byte ConvertToByte(this DataRow _DataRow, string CoulmnName)
        {
            object value = _DataRow[CoulmnName];
            return Convert.ToByte(ReturnZeroIfNull(value));
        }
        public static byte? ConvertToNullableByte(this DataRow _DataRow, string CoulmnName)
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



        public static long ConvertToLong(this DataRow _DataRow, string CoulmnName)
        {
            object value = _DataRow[CoulmnName];
            return Convert.ToInt64(ReturnZeroIfNull(value));
        }

        public static decimal? ConvertToDecimal(this DataRow _DataRow, string CoulmnName)
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
        public static decimal ConvertToNullableDecimal(this DataRow _DataRow, string CoulmnName)
        {
            object value = _DataRow[CoulmnName];
            return Convert.ToDecimal(ReturnZeroIfNull(value));
        }

        public static float? ConvertToFloat(this DataRow _DataRow, string CoulmnName)
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

        public static bool? ConvertToBoolean(this DataRow _DataRow, string CoulmnName)
        {
            object value = _DataRow[CoulmnName];
            object ret = ReturNullIfNull(value);
            if (ret == null)
            {
                return null;
            }
            else
            {
                return Convert.ToBoolean(ret);
            }
        }
        public static float ConvertToNullableFloat(this DataRow _DataRow, string CoulmnName)
        {
            object value = _DataRow[CoulmnName];
            return Convert.ToSingle(ReturnZeroIfNull(value));
        }

        public static DateTime convertToDateTime(this DataRow _DataRow, string CoulmnName)
        {
            object value = _DataRow[CoulmnName];
            return Convert.ToDateTime(ReturnDateTimeMinIfNull(value));
        }

        public static DateTime? convertToNullableDateTime(this DataRow _DataRow, string CoulmnName)
        {
            object value = _DataRow[CoulmnName];
            object RetValue= ReturnDateTimeMinIfNull(value);
            if (RetValue == null)
            {
                return null;
            }
            return Convert.ToDateTime(RetValue);
        }

        public static string ConvertDate(this DateTime datetTime, bool excludeHoursAndMinutes = false)
        {
            if (datetTime != DateTime.MinValue)
            {
                if (excludeHoursAndMinutes)
                    return datetTime.ToString("yyyy-MM-dd");
                return datetTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
            }
            return null;
        }
        private static object ReturnEmptyIfNull( object value)
        {
            if (value == DBNull.Value)
                return string.Empty;
            if (value == null)
                return string.Empty;
            return value;
        }
        public static object ReturnZeroIfNull( object value)
        {
            if (value == DBNull.Value)
                return 0;
            if (value == null)
                return 0;
            return value;
        }
        public static object ReturnDateTimeMinIfNull( object value)
        {
            if (value == DBNull.Value)
                return null;
            if (value == null)
                return DateTime.MinValue;
            return value;
        }
        public static object ReturNullIfNull( object value)
        {
            if (value == DBNull.Value)
                return null;
            if (value == null)
                return null;
            return value;
        }
    }
}
