using Business.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace Business.Services
{
    public class LocalizationService
    {

        //public static string pthRoot = HttpContext.Current.Server.MapPath("~");
        //public static string LangFilePth_ViewerSite =
        //    new DirectoryInfo(pthRoot).Name.ToLower() == "viewersite" ? pthRoot : Path.GetDirectoryName(pthRoot);
        //public static string LangFilePthfinl = Path.Combine(LangFilePth_ViewerSite, "PXAdmin");
        public static string LangFilePthfinl = Path.Combine("~/Languages/Default/ar/Maskan.jsn");

        public static DataSet GetModule(int userLanguageID, string module, bool getDefault)
        {
            DataSet ds_Module = new DataSet();
            JObject jo_Module;
            string langAbbr = "";
            string Lang_Direction = "";
            try
            {
                //string filePath = GetFilePath(
                //    userLanguageID,
                //    (ApplicationService.GetByName(module)).ApplicationLanguageFile,
                //    out langAbbr, out Lang_Direction);

                string filePath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "/Languages/Default/ar/Maskan.jsn";

                using (StreamReader file = File.OpenText(filePath))
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    jo_Module = (JObject)JToken.ReadFrom(reader);
                }
                if (jo_Module.HasValues)
                {
                    ds_Module = (DataSet)JsonConvert.DeserializeObject(jo_Module.ToString(), (typeof(DataSet)));
                }
                else
                {

                }

                //// add datatable contains user language abbreviation &direction
                //DataTable dt_usrLangInfo = new DataTable();
                //dt_usrLangInfo.TableName = "UserLangInfo";

                //DataColumn dc = new DataColumn("LangAbb", typeof(String));
                //dt_usrLangInfo.Columns.Add(dc);
                //dc = new DataColumn("LangDirection", typeof(String));
                //dt_usrLangInfo.Columns.Add(dc);

                //DataRow dr = dt_usrLangInfo.NewRow();
                //dr["LangAbb"] = "Default";
                //dr["LangDirection"] = "RTL";
                //dt_usrLangInfo.Rows.Add(dr);

                //ds_Module.Tables.Add(dt_usrLangInfo);
                //ds_Module.DataSetName = "Default";

            }
            catch (Exception ex)
            {
                throw;
                return null;
            }
            return ds_Module;
        }

       
        public static string GetFilePath(string customerName, string langAbbreviation, string module, out string Lang_Direction)
        {
            string path = "";
            Lang_Direction = "LTR";
            DataTable tb_CustomerDetails = new DataTable();

            // language abbreviation from datatbase
            string dbLangAbbreviation = "";
            try
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                sqlParameters.Add(new SqlParameter("@Customer_Name", customerName));

                //Call SP that return all not supported language for specefic customer name.
                tb_CustomerDetails = new StartUp().ExecuteQuery("Ult_Sp_Lang_Customer_Get", sqlParameters);

                if (tb_CustomerDetails.Rows.Count != 0)
                {
                    foreach (DataRow row in tb_CustomerDetails.Rows) // Loop over the rows.
                    {
                        dbLangAbbreviation = row["Language_abbreviation"].ToString();
                        // it used in case of check if this customer has aspecefic language or not , (used in import  module).

                        if (dbLangAbbreviation.ToLower() == langAbbreviation.ToLower())
                        {

                            if (module == "")
                            {
                                path = Path.Combine(LangFilePthfinl, row["LanguageFilePath"].ToString());
                                return path;
                            }
                            string fileName = (ApplicationService.GetByName(module)).ApplicationLanguageFile;

                            //path = @"~\Languages\" + customerName + "\\" + abbreviation + "\\" + fileName;
                            path = Path.Combine(LangFilePthfinl, row["LanguageFilePath"].ToString() + "\\" + fileName);
                            Lang_Direction = row["Language_Direction"].ToString();
                            return path;
                        }
                    }
                }

                return path;
            }
            catch (Exception ex)
            {
                throw;
                return null;
            }
        }

        /// <summary>
        ///  Using To Get Customer language Path In Server Through It's localization id and module.
        ///  for get request only .
        ///  int type must add to used it in update request
        /// </summary>
        /// <param name="userLanguageID"></param>
        /// <param name="module"></param>
        /// <param name="is_FullPath"> indicates whether to concatenate file path with filename & lang directory on the server </param>
        /// <returns>
        /// [string]
        /// </returns>
        public static string GetFilePath(int userLanguageID, string fileName, out string langAbbriviation, out string Lang_Direction, bool is_FullPath = true)
        {
            string path = "";
            langAbbriviation = "";
            Lang_Direction = "LTR";
            DataTable tb_CustomerDetails = new DataTable();

            // language abbreviation from datatbase
            try
            {
                path = "";
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                sqlParameters.Add(new SqlParameter("@Userlang_ID", userLanguageID));

                //Call SP that return all not supported language for specefic customer name.
                tb_CustomerDetails = new StartUp().ExecuteQuery("Ult_Sp_Lang_Customer_Get", sqlParameters);

                if (tb_CustomerDetails.Rows.Count != 0)
                {
                    foreach (DataRow row in tb_CustomerDetails.Rows) // Loop over the rows.
                    {
                        path = row["LanguageFilePath"].ToString();
                        if (path != "")
                        {
                            langAbbriviation = path.Split('\\').Last();
                            Lang_Direction = row["Language_Direction"].ToString();
                            if (is_FullPath) // require full path inculding filename & lang files directory on the server
                                path = LangFilePthfinl + "\\" + path + "\\" + fileName;

                            return path;
                        }
                    }

                    //if (path == "")
                    //{
                    //    // customer not supported this language return default file for this language .
                    //    //path = @"~\Languages\"+Enum_PX_Constants.DefaultLang+@"\" + lang + @"\" + module + ".js";
                    //}
                }
            }
            catch (Exception ex)
            {
                throw;
                return path;
            }
            return path;
        }

        
        private static string ToJsonString(string str)
        {
            return str.Replace("\"", @"""") // Escape
                ;
        }

        /// <summary>
        /// [DataTable] Used to return all languages that not supported for a specific customer
        /// </summary>
        /// <param name="customerName">
        /// customer name
        /// </param>
        /// <returns>
        /// DataTable of all not supported language
        /// </returns>
        public static DataTable GetLanguage(string customerName)
        {
            DataTable tb_Language = new DataTable();
            try
            {
                tb_Language = new StartUp().ExecuteQuery("Sp_Language_Get");

            }
            catch (Exception ex)
            {
                throw;
                return tb_Language;
            }
            return tb_Language;
        }

        /// <summary>
        /// return Customer folder path name
        /// </summary>
        /// <param name="customerName">Customer Name</param>
        /// <returns>
        /// string
        
        /// <returns>bool</returns>
        public static bool DeleteFolder(string folderPath)
        {
            bool status = false;
            string path = folderPath;
            try
            {
                string[] files = Directory.GetFiles(path);
                string[] dirs = Directory.GetDirectories(path);

                foreach (string file in files)
                {
                    File.SetAttributes(file, FileAttributes.Normal);
                    File.Delete(file);
                }

                foreach (string dir in dirs)
                {
                    DeleteFolder(dir);
                }

                try
                {
                    //File.SetAttributes(path, FileAttributes.Normal);
                    Directory.Delete(path, true);
                }
                catch (IOException)
                {
                    System.Threading.Thread.Sleep(0);
                    File.SetAttributes(path, FileAttributes.Normal);
                    Directory.Delete(path, true);
                }
                status = true;

                //-----------------------------
                //string customerPath = customerName;
                //try
                //{
                //    if (recursive == false)
                //    {
                //        customerPath = "..\\languages\\" + customerPath;
                //        path = System.Web.HttpContext.Current.Server.MapPath(customerPath);
                //    }
                //    else
                //        path = customerPath;
                //string[] files = Directory.GetFiles(path);
                //string[] dirs = Directory.GetDirectories(path);

                //foreach (string file in files)
                //{
                //    File.SetAttributes(file, FileAttributes.Normal);
                //    File.Delete(file);
                //}

                //foreach (string dir in dirs)
                //{
                //    DeleteCustomerFolder(dir, true);
                //}

                //try
                //{
                //    //File.SetAttributes(path, FileAttributes.Normal);
                //    Directory.Delete(path, true);
                //}
                //catch (IOException)
                //{
                //    System.Threading.Thread.Sleep(0);
                //    File.SetAttributes(path, FileAttributes.Normal);
                //    Directory.Delete(path, true);
                //}
                //status = true;
            }
            catch (Exception ex)
            {
                throw;
                return status;
            }
            return status;
        }

        #region ------------------------------------ Database section ------------------------------------------

        /// <summary>
        /// Adding new language recored to cusotmer into database.
        /// It is used also in activation if there is modification , we have to change it also in activation
        /// on upgrade customer has to have any new lang file
        /// </summary>
        /// <param name="customerName">customerName</param>



        public static DataTable GetCustomerLang(string customerName)
        {
            return GetCustomerLang(customerName, null, null);
        }

        /// <summary>
        /// get all Customer language from database by its name .
        /// </summary>
        /// <param name="customerName">Customer Name</param>
        /// <param name="isActive">(0) language not active (1) language is active</param>
        /// <param name="userLangAbbr">User Language Abbreviation</param>
        /// <returns>DataTable of customer languages</returns>
        public static DataTable GetCustomerLang(string customerName, bool? isActive, string userLangAbbr = null, int? Userlang_ID = null)
        {
            DataTable tb_Language = new DataTable();
            try
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                sqlParameters.Add(new SqlParameter("@Customer_Name", customerName));

                if (!string.IsNullOrEmpty(userLangAbbr))
                    sqlParameters.Add(new SqlParameter("@Language_abbreviation", userLangAbbr));

                if (Userlang_ID != null)
                    sqlParameters.Add(new SqlParameter("@Userlang_ID", Userlang_ID));

                if (isActive != null)
                    sqlParameters.Add(new SqlParameter("@Is_Active", isActive));

                //Call SP that return all not supported language for specefic customer name.
                tb_Language = new StartUp().ExecuteQuery("Ult_Sp_Lang_Customer_Get", sqlParameters);
            }
            catch (Exception ex)
            {
                throw;
                return tb_Language;
            }

            return tb_Language;
        }

        #endregion ------------------------------------ Database section ------------------------------------------

        #region -------------------------------------- Default languages -----------------------------------------

        /// <summary>
        /// Get the default language from physical path and compare it with database and return datatable contains it.
        /// </summary>
        /// <returns>DataTable of the default languages</returns>
        public static DataTable GetDefaultLanguages()
        {
            DataTable tb_DefaultLanguages = new DataTable();
            try
            {
                // create datatabel to hold default languages

                DataColumn dc = new DataColumn("Language_ID", typeof(Int32));
                tb_DefaultLanguages.Columns.Add(dc);

                dc = new DataColumn("Language_Name", typeof(String));
                tb_DefaultLanguages.Columns.Add(dc);

                dc = new DataColumn("Language_Abbreviation", typeof(String));
                tb_DefaultLanguages.Columns.Add(dc);

                dc = new DataColumn("LanguageFilePath", typeof(String));
                tb_DefaultLanguages.Columns.Add(dc);

                dc = new DataColumn("Language_Direction", typeof(String));
                tb_DefaultLanguages.Columns.Add(dc);

                //--------------------------------------------------------------------------------------------------------------------------------
                // Add english to datatable as my default language to all application.
                DataRow dr = tb_DefaultLanguages.NewRow();
                dr["Language_ID"] = "-1";
                dr["Language_Name"] = "Arabic";
                dr["Language_Abbreviation"] = "Default";
                dr["LanguageFilePath"] = LangFilePthfinl;
                dr["Language_Direction"] = "RTL";
                tb_DefaultLanguages.Rows.Add(dr);

                //--------------------------------------------------------------------------------------------------------------------------------
                // get language abbreviation from physical path in default languages.


                //string[] filePaths = Directory.GetDirectories(Path.Combine(LangFilePthfinl, @"languages\Default" + "\\"));
                List<string> langAbbrs = new List<string>();
                //foreach (String langAbbr in filePaths)
                //{
                langAbbrs.Add("ar");
                langAbbrs.Add("en");
                // }

                //--------------------------------------------------------------------------------------------------------------------------------
                // get language abbreviation from database .
                DataTable tb_languages = GetLanguage(null);

                // compare tow data if physical name contains in database add it to tb_defaultlanguages datatable.
                foreach (DataRow dr2 in tb_languages.Rows)
                {
                    // if true its mean the language exist in database and will added to my defautl languages.
                    if (langAbbrs.Contains(dr2["Language_Abbreviation"].ToString()))
                    {
                        //if (dr2["Language_Abbreviation"].ToString().Equals("ar") && (ApplicationHandler.Instance.App!=PX.Data.Enums.Common.Apps.RIS))
                        //    continue;
                        tb_DefaultLanguages.ImportRow(dr2);
                        tb_DefaultLanguages.Rows[tb_DefaultLanguages.Rows.Count - 1]["LanguageFilePath"] = LangFilePthfinl;
                    }
                }

                //--------------------------------------------------------------------------------------------------------------------------------
                // Save the Default languages datatable into session.
                HttpContext.Current.Session["tb_DefaultLanguages"] = tb_DefaultLanguages;
                return tb_DefaultLanguages;
            }
            catch (Exception ex)
            {
                throw;
                return tb_DefaultLanguages;
            }
        }

        /// <summary>
        /// Determined if the language abbreviation in exist in my default languages or not .
        /// </summary>
        /// <param name="langAbbreviation">Language Abbreviation</param>
        /// <returns>bool</returns>
        public static bool LanguageIsDefined(string langAbbreviation)
        {
            bool isDefined = false;
            try
            {
                if (HttpContext.Current.Session["tb_DefaultLanguages"] == null)
                    GetDefaultLanguages();

                // compare data in parameter (langAbbreviation) in exist in My default languages in (tb_DefaultLanguages)
                DataTable tb_DefaultLanguages = HttpContext.Current.Session["tb_DefaultLanguages"] as DataTable;

                // check if language abbreviation is exist in datatable.
                string langAbbri = (from DataRow dr in tb_DefaultLanguages.Rows where (string)dr["Language_Abbreviation"] == langAbbreviation select (string)dr["Language_Abbreviation"]).FirstOrDefault();
                if (langAbbri != null)
                    isDefined = true;
            }
            catch (Exception ex)
            {
                throw;
            }
            return isDefined;
        }

       

        /// <summary>
        /// Get Language id by using language abbreviation .
        /// </summary>
        /// <param name="langAbbreviation">langAbbreviation</param>
        /// <returns>Language id </returns>
        public static int GetLanguageID(string langAbbreviation)
        {
            int langID = -1;
            try
            {
                if (HttpContext.Current.Session["tb_DefaultLanguages"] == null)
                    GetDefaultLanguages();

                // compare data in parameter (langAbbreviation) in exist in My default languages in (tb_DefaultLanguages)
                DataTable tb_DefaultLanguages = HttpContext.Current.Session["tb_DefaultLanguages"] as DataTable;

                // get language id by using languagew abbreviation in datatable.
                int langIID = (
                    from DataRow dr in tb_DefaultLanguages.Rows
                    where (string)dr["Language_Abbreviation"] == langAbbreviation
                    select (int)dr["Language_ID"]).FirstOrDefault();

                if (langIID != -1)
                    return langIID;
            }
            catch (Exception ex)
            {
                throw;
            }
            return langID;
        }
        #endregion -------------------------------------- Default languages -----------------------------------------


    }

}