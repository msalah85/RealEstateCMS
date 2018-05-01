using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.AutoMapper;
using System.Data;

namespace Business.AutoMapper
{
    public class SqlParametersGenerator : ISqlParametersGenerator
    {
        public bool CheckForNull { get; set; }
        public SqlParametersGenerator()
        {
            this.CheckForNull = true;
        }

        public List<SqlParameter> Generate<T>(T model)
        {

            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            var FieldNames = model.GetType().GetProperties().Cast<System.Reflection.PropertyInfo>();


            foreach (var item in FieldNames)
            {
                if (Attribute.GetCustomAttribute(item, typeof(NonSqlParameterAttribute)) == null)
                {


                    object currentProperty = model.GetType().GetProperty(item.Name).GetValue(model, null);
                    if (currentProperty != null && !string.IsNullOrEmpty(currentProperty.ToString()))
                    {
                        if (item.PropertyType == typeof(DateTime))
                        {
                            sqlParameters.Add(new SqlParameter("@" + item.Name, SqlDbType.Float) { Value = ((DateTime)currentProperty).ToOADate() });
                        }
                        else if (item.PropertyType == typeof(DateTime?))
                        {
                            sqlParameters.Add(new SqlParameter("@" + item.Name, SqlDbType.Float) { Value = ((DateTime)currentProperty).ToOADate() });
                        }
                        else if (item.PropertyType == typeof(string))
                        {
                            if (!string.IsNullOrEmpty(currentProperty.ToString().Trim()))
                            {
                                sqlParameters.Add(new SqlParameter("@" + item.Name, currentProperty.ToString().Trim()));
                            }
                        }
                        else if (!string.IsNullOrEmpty(currentProperty.ToString()))
                        {
                            sqlParameters.Add(new SqlParameter("@" + item.Name, currentProperty));
                        }
                    }
                    else
                    {
                        if (CheckForNull)
                        {
                            if (Attribute.GetCustomAttribute(item, typeof(NonNullableSqlAttribute)) != null)

                            {
                                var _NonNullableSql_item = (NonNullableSqlAttribute)Attribute.GetCustomAttribute(item, typeof(NonNullableSqlAttribute));
                                if (_NonNullableSql_item.HasDefaultValue)
                                {
                                    sqlParameters.Add(new SqlParameter("@" + item.Name, _NonNullableSql_item.Default_Value));
                                }
                                else
                                {
                                    sqlParameters.Add(new SqlParameter("@" + item.Name, currentProperty));
                                }
                            }
                        }
                    }
                }
            }



            return sqlParameters;
        }
        public List<SqlParameter> GenerateInsertUpdateParameters<T>(T model)
        {

            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            var FieldNames = model.GetType().GetProperties().Cast<System.Reflection.PropertyInfo>();


            foreach (var item in FieldNames)
            {
                if (Attribute.GetCustomAttribute(item, typeof(NonSqlParameterAttribute)) == null && Attribute.GetCustomAttribute(item, typeof(KeyAttribute)) == null)
                {
                    object currentProperty = model.GetType().GetProperty(item.Name).GetValue(model, null);
                    if (currentProperty != null && !string.IsNullOrEmpty(currentProperty.ToString()))
                    {
                        if (item.PropertyType == typeof(DateTime))
                        {
                            sqlParameters.Add(new SqlParameter("@" + item.Name, SqlDbType.Float) { Value = ((DateTime)currentProperty).ToOADate() });
                        }
                        else if (item.PropertyType == typeof(DateTime?))
                        {
                            sqlParameters.Add(new SqlParameter("@" + item.Name, SqlDbType.Float) { Value = ((DateTime)currentProperty).ToOADate() });
                        }
                        else if (item.PropertyType == typeof(string))
                        {
                            if (!string.IsNullOrEmpty(currentProperty.ToString().Trim()))
                            {
                                sqlParameters.Add(new SqlParameter("@" + item.Name, currentProperty.ToString().Trim()));
                            }
                        }
                        else if (!string.IsNullOrEmpty(currentProperty.ToString()))
                        {
                            sqlParameters.Add(new SqlParameter("@" + item.Name, currentProperty));
                        }
                    }
                }
                else
                {
                    if (CheckForNull)
                    {
                        if (Attribute.GetCustomAttribute(item, typeof(NonNullableSqlAttribute)) != null)

                        {
                            var _NonNullableSql_item = (NonNullableSqlAttribute)Attribute.GetCustomAttribute(item, typeof(NonNullableSqlAttribute));
                            if (_NonNullableSql_item.HasDefaultValue)
                            {
                                sqlParameters.Add(new SqlParameter("@" + item.Name, _NonNullableSql_item.Default_Value));
                            }
                            else
                            {
                                sqlParameters.Add(new SqlParameter("@" + item.Name, null));
                            }
                        }
                    }
                }
            }



            return sqlParameters;
        }
    }
}
