using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
    class DataField
    {
        public string Name { get; set; }
    }
    public class GenericDataReaderMapper<T> : IDataReaderMappper<T> where T : new()
    {
        private Dictionary<string, Type> objFieldNames;
        List<DataField> dtlFieldNames;


        private void Initalize(SqlDataReader datareader)
        {
            
            if (objFieldNames==null)
            {
                //Define what attributes to be read from the class
                const System.Reflection.BindingFlags flags = System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance;

                //Read Attribute Names and Types
               this.objFieldNames = typeof(T).GetProperties(flags).Cast<System.Reflection.PropertyInfo>().
                    Select(item => new
                    {
                        Name = item.Name,
                        Type = Nullable.GetUnderlyingType(item.PropertyType) ?? item.PropertyType
                    }).ToDictionary(x=>x.Name,x=>x.Type);
            }


            if (this.dtlFieldNames == null)
            {
                //Read Datatable column names and types
                this.dtlFieldNames = datareader.GetSchemaTable().Rows.Cast<DataRow>().
                    Select(item => new DataField()
                    {
                        Name = item["ColumnName"].ToString()
                    }).ToList();
            }
        }
        public List<T> ToList(SqlDataReader datareader)
        {
            var dataList = new List<T>();



            //Define what attributes to be read from the class
           // const System.Reflection.BindingFlags flags = System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance;

            this.Initalize(datareader);






            while (datareader.Read())
            {
                var classObj = new T();

                for (int i = 0; i < dtlFieldNames.Count; i++)
                {
                    var dtField = dtlFieldNames[i];
                    if (objFieldNames.ContainsKey(dtField.Name))
                    {
                        var field = objFieldNames[dtField.Name];

                        if (field != null)
                        {
                            System.Reflection.PropertyInfo propertyInfos = classObj.GetType().GetProperty(dtField.Name);
                            if (propertyInfos.PropertyType == typeof(DateTime))
                            {
                                propertyInfos.SetValue
                                (classObj, datareader.convertToDateTime(dtField.Name), null);
                            }
                            else if (propertyInfos.PropertyType == typeof(Nullable<DateTime>))
                            {
                                var col = datareader.GetOrdinal(dtField.Name);
                                propertyInfos.SetValue
                                (classObj, datareader.IsDBNull(col) ? (DateTime?)null : (DateTime?)datareader.GetDateTime(col), null);
                            }
                            else if (propertyInfos.PropertyType == typeof(int))
                            {
                                propertyInfos.SetValue
                                (classObj, datareader.ConvertToInt(dtField.Name), null);
                            }
                            else if (propertyInfos.PropertyType == typeof(int?))
                            {
                                propertyInfos.SetValue
                                (classObj, datareader.ConvertToNullableInt(dtField.Name), null);
                            }
                            else if (propertyInfos.PropertyType == typeof(byte))
                            {
                                propertyInfos.SetValue
                                (classObj, datareader.ConvertToByte(dtField.Name), null);
                            }
                            else if (propertyInfos.PropertyType == typeof(byte?))
                            {
                                propertyInfos.SetValue
                                (classObj, datareader.ConvertToNullableByte(dtField.Name), null);
                            }
                            else if (propertyInfos.PropertyType == typeof(short))
                            {
                                propertyInfos.SetValue
                                (classObj, datareader.ConvertToNullableShort(dtField.Name), null);
                            }
                            else if (propertyInfos.PropertyType == typeof(short?))
                            {
                                propertyInfos.SetValue
                                (classObj, datareader.ConvertToNullableShort(dtField.Name), null);
                            }
                            else if (propertyInfos.PropertyType == typeof(long))
                            {
                                propertyInfos.SetValue
                                (classObj, datareader.ConvertToLong(dtField.Name), null);
                            }
                            else if (propertyInfos.PropertyType == typeof(decimal))
                            {
                                propertyInfos.SetValue
                                (classObj, datareader.ConvertToDecimal(dtField.Name), null);
                            }
                            else if (propertyInfos.PropertyType == typeof(float?))
                            {
                                propertyInfos.SetValue
                                (classObj, datareader.ConvertToNullableFloat(dtField.Name), null);
                            }
                            else if (propertyInfos.PropertyType == typeof(float))
                            {
                                propertyInfos.SetValue
                                (classObj, datareader.ConvertToFloat(dtField.Name), null);
                            }
                            else if (propertyInfos.PropertyType == typeof(decimal?))
                            {
                                propertyInfos.SetValue
                                (classObj, datareader.ConvertToNullableDecimal(dtField.Name), null);
                            }
                            else if (propertyInfos.PropertyType == typeof(bool?))
                            {
                                propertyInfos.SetValue
                                (classObj, datareader.ConvertToNullableBool(dtField.Name), null);
                            }
                            else if (propertyInfos.PropertyType == typeof(String))
                            {
                                if (datareader[dtField.Name].GetType() == typeof(DateTime))
                                {
                                    propertyInfos.SetValue
                                    (classObj, datareader.ConvertToDateString(dtField.Name), null);
                                }
                                else
                                {
                                    propertyInfos.SetValue
                                    (classObj, datareader.ConvertToString(dtField.Name), null);
                                }
                            }
                            else
                            {

                                propertyInfos.SetValue
                                    (classObj, Convert.ChangeType(datareader[dtField.Name], propertyInfos.PropertyType), null);

                            }
                        }
                    }
                }

                dataList.Add(classObj);
            }


            return dataList;
        }
    }
}