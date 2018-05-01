using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
    public class GenericDataTableMapper<T> : IDataTableMappper<T> where T :new()
    {
        public List<T> ToList(DataTable dataTable)
        {
            var dataList = new List<T>();

            //Define what attributes to be read from the class
            const System.Reflection.BindingFlags flags = System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance;

            //Read Attribute Names and Types
            var objFieldNames = typeof(T).GetProperties(flags).Cast<System.Reflection.PropertyInfo>().
                Select(item => new
                {
                    Name = item.Name,
                    Type = Nullable.GetUnderlyingType(item.PropertyType) ?? item.PropertyType
                }).ToList();

            //Read Datatable column names and types
            var dtlFieldNames = dataTable.Columns.Cast<DataColumn>().
                Select(item => new
                {
                    Name = item.ColumnName,
                    Type = item.DataType
                }).ToList();
            DataRow dataRow;
            for (int rows = 0; rows < dataTable.Rows.Count; rows++)
            {
                dataRow = dataTable.Rows[rows];
                var classObj = new T();

                foreach (var dtField in dtlFieldNames)
                {
                    System.Reflection.PropertyInfo propertyInfos = classObj.GetType().GetProperty(dtField.Name);

                    var field = objFieldNames.Find(x => x.Name == dtField.Name);

                    if (field != null)
                    {

                        if (propertyInfos.PropertyType == typeof(DateTime))
                        {
                            propertyInfos.SetValue
                            (classObj, dataRow.convertToDateTime(dtField.Name), null);
                        }
                        else if (propertyInfos.PropertyType == typeof(Nullable<DateTime>))
                        {
                            propertyInfos.SetValue
                            (classObj, dataRow.convertToNullableDateTime(dtField.Name), null);
                        }
                        else if (propertyInfos.PropertyType == typeof(int))
                        {
                            propertyInfos.SetValue
                            (classObj, dataRow.ConvertToInt(dtField.Name), null);
                        }
                        else if (propertyInfos.PropertyType == typeof(int?))
                        {
                            propertyInfos.SetValue
                            (classObj, dataRow.ConvertToNullableInt(dtField.Name), null);
                        }
                        else if (propertyInfos.PropertyType == typeof(byte))
                        {
                            propertyInfos.SetValue
                            (classObj, dataRow.ConvertToByte(dtField.Name), null);
                        }
                        else if (propertyInfos.PropertyType == typeof(byte?))
                        {
                            propertyInfos.SetValue
                            (classObj, dataRow.ConvertToNullableByte(dtField.Name), null);
                        }
                        else if (propertyInfos.PropertyType == typeof(short))
                        {
                            propertyInfos.SetValue
                            (classObj, dataRow.ConvertToNullableShort(dtField.Name), null);
                        }
                        else if (propertyInfos.PropertyType == typeof(short?))
                        {
                            propertyInfos.SetValue
                            (classObj, dataRow.ConvertToNullableShort(dtField.Name), null);
                        }
                        else if (propertyInfos.PropertyType == typeof(long))
                        {
                            propertyInfos.SetValue
                            (classObj, dataRow.ConvertToLong(dtField.Name), null);
                        }
                        else if (propertyInfos.PropertyType == typeof(decimal))
                        {
                            propertyInfos.SetValue
                            (classObj, dataRow.ConvertToDecimal(dtField.Name), null);
                        }
                        else if (propertyInfos.PropertyType == typeof(float?))
                        {
                            propertyInfos.SetValue
                            (classObj, dataRow.ConvertToNullableFloat(dtField.Name), null);
                        }
                        else if (propertyInfos.PropertyType == typeof(float))
                        {
                            propertyInfos.SetValue
                            (classObj, dataRow.ConvertToFloat(dtField.Name), null);
                        }
                        else if (propertyInfos.PropertyType == typeof(decimal?))
                        {
                            propertyInfos.SetValue
                            (classObj, dataRow.ConvertToNullableDecimal(dtField.Name), null);
                        }
                        else if (propertyInfos.PropertyType == typeof(bool?))
                        {
                            propertyInfos.SetValue
                            (classObj, dataRow.ConvertToBoolean(dtField.Name), null);
                        }
                        else if (propertyInfos.PropertyType == typeof(String))
                        {
                            if (dataRow[dtField.Name].GetType() == typeof(DateTime))
                            {
                                propertyInfos.SetValue
                                (classObj, dataRow.ConvertToDateString(dtField.Name), null);
                            }
                            else
                            {
                                propertyInfos.SetValue
                                (classObj, dataRow.ConvertToString(dtField.Name), null);
                            }
                        }
                        else
                        {

                            propertyInfos.SetValue
                                (classObj, Convert.ChangeType(dataRow[dtField.Name], propertyInfos.PropertyType), null);

                        }
                    }
                }
                dataList.Add(classObj);
      
            }
            return dataList;
        }
    }
}
