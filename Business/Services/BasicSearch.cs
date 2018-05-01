using Business.AutoMapper;
using Business.BaseSearch;
using Business.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Business.Services
{
    public abstract class BaseSearchService<T, U>
    where U : IBaseSearch
    where T : new()
    {
        protected virtual string Delete_SP { get; set; }
        protected virtual string Update_SP { get; set; }
        protected virtual string Insert_SP { get; set; }
        protected abstract string Find_SP { get; }
        public List<T> Find(U _Search_VM, string ConnectionString)
        {
            DataTable temp = null;
            GenericDataTableMapper<T> _fillMachine = new GenericDataTableMapper<T>();
            try
            {
                SqlParametersGenerator _SqlParametersGenerator = new SqlParametersGenerator();
                List<SqlParameter> sqlParameters = _SqlParametersGenerator.Generate<U>(_Search_VM);
                List<T> lst = new StartUp().ExecuteQuery<T>(Find_SP, sqlParameters);
                return lst;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (temp != null)
                {
                    temp.Dispose();
                }
            }
        }

        public int Insert(T _Search_VM)
        {
            DataTable temp = null;
            GenericDataTableMapper<T> _fillMachine = new GenericDataTableMapper<T>();
            try
            {
                SqlParametersGenerator _SqlParametersGenerator = new SqlParametersGenerator();
                List<SqlParameter> sqlParameters = _SqlParametersGenerator.GenerateInsertUpdateParameters<T>(_Search_VM);
                return new StartUp().ExecuteNonQuery(Insert_SP, sqlParameters);
            }
            catch (Exception ex)
            {
                return -2;
            }
            finally
            {
                if (temp != null)
                {
                    temp.Dispose();
                }
            }
        }
        public int InsertWithResult(T _Search_VM)
        {
            DataTable temp = null;
            GenericDataTableMapper<T> _fillMachine = new GenericDataTableMapper<T>();
            try
            {
                SqlParameter result = new SqlParameter("@Result", SqlDbType.Int);
                result.Direction = ParameterDirection.Output;
                result.Value = 0;
                SqlParametersGenerator _SqlParametersGenerator = new SqlParametersGenerator();
                List<SqlParameter> sqlParameters = _SqlParametersGenerator.GenerateInsertUpdateParameters<T>(_Search_VM);
                sqlParameters.Add(result);
                int Result = 0;
                new StartUp().ExecuteNonQuery(Insert_SP, sqlParameters);
                int.TryParse(result.Value.ToString(), out Result);
                return Result;
            }
            catch (Exception ex)
            {
                return -2;
            }
            finally
            {
                if (temp != null)
                {
                    temp.Dispose();
                }
            }
        }


        public int InsertWithResult(T _Search_VM, out int inserted_Inc)
        {
            DataTable temp = null;
            GenericDataTableMapper<T> _fillMachine = new GenericDataTableMapper<T>();
            try
            {
                SqlParameter result = new SqlParameter("@Result", SqlDbType.Int);
                SqlParameter inserted_Inc_ID = new SqlParameter("@Inserted_Inc_ID", SqlDbType.Int);
                result.Direction = ParameterDirection.Output;
                result.Value = 0;
                inserted_Inc_ID.Direction = ParameterDirection.Output;
                inserted_Inc_ID.Value = 0;
                SqlParametersGenerator _SqlParametersGenerator = new SqlParametersGenerator();
                List<SqlParameter> sqlParameters = _SqlParametersGenerator.GenerateInsertUpdateParameters<T>(_Search_VM);
                sqlParameters.Add(result);
                sqlParameters.Add(inserted_Inc_ID);
                int Result = 0;
                inserted_Inc = 0;
                new StartUp().ExecuteNonQuery(Insert_SP, sqlParameters);
                int.TryParse(result.Value.ToString(), out Result);
                int.TryParse(inserted_Inc_ID.Value.ToString(), out inserted_Inc);
                return Result;
            }
            catch (Exception ex)
            {
                inserted_Inc = 0;
                return -2;
            }
            finally
            {
                if (temp != null)
                {
                    temp.Dispose();
                }
            }
        }
        public int UpdateWithResult(T _Search_VM)
        {
            DataTable temp = null;
            GenericDataTableMapper<T> _fillMachine = new GenericDataTableMapper<T>();
            try
            {
                SqlParameter result = new SqlParameter("@Result", SqlDbType.Int);
                result.Direction = ParameterDirection.Output;
                result.Value = 0;
                SqlParametersGenerator _SqlParametersGenerator = new SqlParametersGenerator();
                List<SqlParameter> sqlParameters = _SqlParametersGenerator.Generate<T>(_Search_VM);
                sqlParameters.Add(result);
                new StartUp().ExecuteNonQuery(Update_SP, sqlParameters);
                int Result = 0;
                int.TryParse(result.Value.ToString(), out Result);
                return Result;
            }
            catch (Exception ex)
            {
                return -2;
            }
            finally
            {
                if (temp != null)
                {
                    temp.Dispose();
                }
            }
        }
        public int Update(T _Search_VM)
        {
            DataTable temp = null;
            GenericDataTableMapper<T> _fillMachine = new GenericDataTableMapper<T>();
            try
            {
                //SqlParameter result = new SqlParameter("@Result", SqlDbType.Int);
                //result.Direction = ParameterDirection.Output;
                SqlParametersGenerator _SqlParametersGenerator = new SqlParametersGenerator();
                List<SqlParameter> sqlParameters = _SqlParametersGenerator.Generate<T>(_Search_VM);
                // sqlParameters.Add(result);
                return new StartUp().ExecuteNonQuery(Update_SP, sqlParameters);
            }
            catch (Exception ex)
            {
                return -2;
            }
            finally
            {
                if (temp != null)
                {
                    temp.Dispose();
                }
            }
        }
        public int Delete(T _Search_VM)
        {
            DataTable temp = null;
            int Result = 0;
            GenericDataTableMapper<T> _fillMachine = new GenericDataTableMapper<T>();
            try
            {
                SqlParametersGenerator _SqlParametersGenerator = new SqlParametersGenerator() { CheckForNull = false };
                List<SqlParameter> sqlParameters = _SqlParametersGenerator.Generate<T>(_Search_VM);
                return new StartUp().ExecuteNonQuery(Delete_SP, sqlParameters);
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                if (temp != null)
                {
                    temp.Dispose();
                }
            }
        }
        public int DeleteWithResult(T _Search_VM)
        {
            DataTable temp = null;
            int Result = 0;
            GenericDataTableMapper<T> _fillMachine = new GenericDataTableMapper<T>();
            try
            {
                SqlParameter result = new SqlParameter("@Result", SqlDbType.Int);
                result.Direction = ParameterDirection.Output;
                result.Value = 0;
                SqlParametersGenerator _SqlParametersGenerator = new SqlParametersGenerator() { CheckForNull = false };
                List<SqlParameter> sqlParameters = _SqlParametersGenerator.Generate<T>(_Search_VM);
                sqlParameters.Add(result);
                new StartUp().ExecuteNonQuery(Delete_SP, sqlParameters);
                int.TryParse(result.Value.ToString(), out Result);
                return Result;
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                if (temp != null)
                {
                    temp.Dispose();
                }
            }
        }


        public List<T> Find(U _Search_VM)
        {
            DataTable temp = null;
            GenericDataTableMapper<T> _fillMachine = new GenericDataTableMapper<T>();
            try
            {
                SqlParametersGenerator _SqlParametersGenerator = new SqlParametersGenerator();
                List<SqlParameter> sqlParameters = _SqlParametersGenerator.Generate<U>(_Search_VM);
                List<T> lst = new StartUp().ExecuteQuery<T>(Find_SP, sqlParameters);
                if (lst == null)
                {
                    return new List<T>();
                }
                return lst;
            }
            catch (Exception ex)
            {
                return new List<T>();
            }
            finally
            {
                if (temp != null)
                {
                    temp.Dispose();
                }
            }
        }

        public List<T> Find()
        {
            GenericDataTableMapper<T> _fillMachine = new GenericDataTableMapper<T>();
            try
            {
                List<T> lst = new StartUp().ExecuteQuery<T>(Find_SP);
                return lst;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public List<T> FindList(U _RadiologistSearch_VM)
        {

            GenericDataTableMapper<T> _fillMachine = new GenericDataTableMapper<T>();
            try
            {
                SqlParametersGenerator _SqlParametersGenerator = new SqlParametersGenerator();
                List<SqlParameter> sqlParameters = _SqlParametersGenerator.Generate<U>(_RadiologistSearch_VM);
                List<T> lst = new StartUp().ExecuteQuery<T>(Find_SP, sqlParameters);
                return lst;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {

            }
        }
    }
}