using Business.AutoMapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Business.DAL
{
    public class StartUp
    {
        private SqlConnection sqlconn;
        private SqlCommand sqlcmd;
        private DataTable dt = new DataTable();
        private SqlDataReader dr;
        private DataSet ds = new DataSet();

        public StartUp(string connection)
        {
            sqlconn = new SqlConnection(connection);
            sqlcmd = new SqlCommand("", sqlconn);
            sqlcmd.CommandTimeout = 240;
        }

        public StartUp()
        {
            sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            sqlcmd = new SqlCommand("", sqlconn);
            sqlcmd.CommandTimeout = 120;
        }

        public StartUp(SqlConnection sqlconn)
        {
            sqlcmd = new SqlCommand("", sqlconn);
            sqlcmd.CommandTimeout = 120;
        }

        public DataTable ExecuteQuery(string _Select_SP, List<SqlParameter> _Param)
        {
            try
            {
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _Select_SP;
                sqlcmd.Parameters.Clear();

                if (_Param != null)
                {
                    foreach (SqlParameter sp in _Param)
                    {
                        sqlcmd.Parameters.Add(sp);
                    }
                }

                if (sqlconn.State == ConnectionState.Closed)
                    sqlconn.Open();

                dr = sqlcmd.ExecuteReader(CommandBehavior.CloseConnection);
                dt.Load(dr);

                if (!dr.IsClosed)
                    dr.Close();

                return dt;
            }
            catch (Exception ex)
            {

                return null;
            }
            finally
            {
                try
                {
                    if (sqlconn.State == ConnectionState.Open)
                        sqlconn.Close();

                    if (sqlcmd != null)
                        sqlcmd.Dispose();

                    if (!dr.IsClosed)
                        dr.Close();
                }
                catch { }
            }
        }


        public List<T> ExecuteQuery<T>(string _Select_SP, List<SqlParameter> _Param) where T : new()
        {
            try
            {
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _Select_SP;
                sqlcmd.Parameters.Clear();

                if (_Param != null)
                {
                    foreach (SqlParameter sp in _Param)
                    {
                        sqlcmd.Parameters.Add(sp);
                    }
                }

                if (sqlconn.State == ConnectionState.Closed)
                    sqlconn.Open();

                dr = sqlcmd.ExecuteReader(CommandBehavior.CloseConnection);

                GenericDataReaderMapper<T> _GenericDataReaderMapper = new GenericDataReaderMapper<T>();
                List<T> lst = _GenericDataReaderMapper.ToList(dr);


                // dt.Load(dr);

                if (!dr.IsClosed)
                    dr.Close();

                return lst;
            }
            catch (Exception ex)
            {
                //LogError.Write_Log(Apps.WorkList, ex, Log_Level.Basic);
                return null;
            }
            finally
            {
                try
                {
                    if (sqlconn.State == ConnectionState.Open)
                        sqlconn.Close();

                    if (sqlcmd != null)
                        sqlcmd.Dispose();

                    if (!dr.IsClosed)
                        dr.Close();
                }
                catch { }
            }
        }

        public List<T> ExecuteQuery<T>(string _SelectStatement) where T : new()
        {
            try
            {
                sqlcmd.CommandType = CommandType.Text;
                sqlcmd.CommandText = _SelectStatement;

                if (sqlconn.State == ConnectionState.Closed)
                    sqlconn.Open();

                dr = sqlcmd.ExecuteReader(CommandBehavior.CloseConnection);

                GenericDataReaderMapper<T> _GenericDataReaderMapper = new GenericDataReaderMapper<T>();
                List<T> lst = _GenericDataReaderMapper.ToList(dr);

                if (!dr.IsClosed)
                    dr.Close();

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                try
                {
                    if (sqlconn.State == ConnectionState.Open)
                        sqlconn.Close();

                    if (sqlcmd != null)
                        sqlcmd.Dispose();

                    if (!dr.IsClosed)
                        dr.Close();
                }
                catch { }
            }
        }
        public DataTable ExecuteQuery(string _SelectStatement)
        {
            try
            {
                sqlcmd.CommandType = CommandType.Text;
                sqlcmd.CommandText = _SelectStatement;

                if (sqlconn.State == ConnectionState.Closed)
                    sqlconn.Open();

                dr = sqlcmd.ExecuteReader(CommandBehavior.CloseConnection);
                dt.Load(dr);

                if (!dr.IsClosed)
                    dr.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                try
                {
                    if (sqlconn.State == ConnectionState.Open)
                        sqlconn.Close();

                    if (sqlcmd != null)
                        sqlcmd.Dispose();

                    if (!dr.IsClosed)
                        dr.Close();
                }
                catch { }
            }
        }

        public DataSet ExecuteQuery_DataSet(string _Select_SP, List<SqlParameter> _Param)
        {
            try
            {
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _Select_SP;
                sqlcmd.Parameters.Clear();

                if (_Param != null)
                {
                    foreach (SqlParameter sp in _Param)
                    {
                        sqlcmd.Parameters.Add(sp);
                    }
                }

                if (sqlconn.State == ConnectionState.Closed)
                    sqlconn.Open();
                IDataAdapter adapter = new SqlDataAdapter(sqlcmd);
                adapter.Fill(ds);
                sqlconn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                //LogError.Write_Log(Apps.WorkList, ex, Log_Level.Basic);
                return null;
            }
            finally
            {
                try
                {
                    if (sqlconn.State == ConnectionState.Open)
                        sqlconn.Close();

                    if (sqlcmd != null)
                        sqlcmd.Dispose();
                }
                catch { }
            }
        }

        public string Execute_Scaler(string select_sp, List<SqlParameter> _Param)
        {
            try
            {
                object outputvalue = new object();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = select_sp;
                sqlcmd.Parameters.Clear();

                foreach (SqlParameter sp in _Param)
                {
                    sqlcmd.Parameters.Add(sp);
                }

                sqlconn.Open();
                outputvalue = sqlcmd.ExecuteScalar();
                sqlconn.Close();

                if (outputvalue != null)
                {
                    return outputvalue.ToString();
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                //LogError.Write_Log(Apps.WorkList, ex, Log_Level.Basic);
                throw ex;
            }
            finally
            {
                if (sqlconn.State == ConnectionState.Open)
                    sqlconn.Close();

                if (sqlcmd != null)
                    sqlcmd.Dispose();
            }
        }

        public string Execute_Scaler(string select_statement)
        {
            try
            {
                object outputvalue = new object();
                sqlcmd.CommandType = CommandType.Text;
                sqlcmd.CommandText = select_statement;
                sqlcmd.Parameters.Clear();

                sqlconn.Open();
                outputvalue = sqlcmd.ExecuteScalar();
                sqlconn.Close();

                if (outputvalue != null)
                {
                    return outputvalue.ToString();
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                //LogError.Write_Log(Apps.WorkList, ex, Log_Level.Basic);
                throw ex;
            }
            finally
            {
                if (sqlconn.State == ConnectionState.Open)
                    sqlconn.Close();

                if (sqlcmd != null)
                    sqlcmd.Dispose();
            }
        }

        public int ExecuteNonQuery(string _DML_SP, List<SqlParameter> _Param)
        {
            try
            {
                int stmtRet = 0;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = _DML_SP;
                sqlcmd.Parameters.Clear();

                foreach (SqlParameter sp in _Param)
                {
                    sqlcmd.Parameters.Add(sp);
                }

                sqlconn.Open();
                stmtRet = sqlcmd.ExecuteNonQuery();
                sqlconn.Close();

                return stmtRet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlconn.State == ConnectionState.Open)
                    sqlconn.Close();

                if (sqlcmd != null)
                    sqlcmd.Dispose();
            }
        }

        public int ExecuteNonQuery(string _DML_Statment)
        {
            try
            {
                int stmtRet = 0;
                sqlcmd.CommandType = CommandType.Text;
                sqlcmd.CommandText = _DML_Statment;
                sqlcmd.Parameters.Clear();

                sqlconn.Open();
                stmtRet = sqlcmd.ExecuteNonQuery();
                sqlconn.Close();

                return stmtRet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlconn.State == ConnectionState.Open)
                    sqlconn.Close();

                if (sqlcmd != null)
                    sqlcmd.Dispose();
            }
        }

        public static string Read_ConnectionString()
        {
                return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public static string MakeConnectionString(string server_IP, string loginName, string password, string dataBase)
        {
            DbConnectionStringBuilder con = new DbConnectionStringBuilder();
            con.Add("Data Source", server_IP);
            con.Add("Initial Catalog", dataBase);
            con.Add("uid", loginName);
            con.Add("pwd", password);

            return con.ConnectionString;
        }


    }
}