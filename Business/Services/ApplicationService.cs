using Business.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Services
{

    public enum Apps
    {
        MaskanWeb = 1,
        MaskanAdmin = 2
    }

    public class ApplicationService
    {
        //1 ApplicationID
        //2 ApplicationName
        //3 ApplicationDisplayName
        //4 ApplicationLanguageFile
        public static Application_Info[] APPLICATIONS =
            new Application_Info[1]
            {
                new Application_Info((int)Apps.MaskanWeb, "MaskanWeb" , "MaskanWeb" , "Maskan.jsn")
            };

        /// <summary>
        /// Get Application information by application ID
        /// </summary>
        /// <param name="app"> Application</param>
        /// <returns>Application_Info Object</returns>
        public static Application_Info GetByID(Apps app)
        {
            try
            {
                Application_Info result = APPLICATIONS.OfType<Application_Info>()
                         .SingleOrDefault(e => e.ApplicationID == (int)app);

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Get List of Applications information by application ID(s)
        /// </summary>
        /// <param name="apps">Applications</param>
        /// <returns>List of Application_Info objects</returns>
        public static List<Application_Info> GetByID(Apps[] apps)
        {
            try
            {
                int[] appValues = new int[apps.Length];
                for (int i = 0; i < apps.Length; i++)
                {
                    appValues[i] = (int)apps[i];
                }
                List<Application_Info> result = (APPLICATIONS.OfType<Application_Info>()
                         .Where(e => appValues.Contains(e.ApplicationID)).ToList<Application_Info>());

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Get Application information by application name
        /// </summary>
        /// <param name="application_name">Application Name</param>
        /// <returns>Application_Info Object</returns>
        public static Application_Info GetByName(string application_name)
        {
            try
            {
                Application_Info result = APPLICATIONS.OfType<Application_Info>()
                         .SingleOrDefault(e => e.ApplicationName == application_name);

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Get All applications
        /// </summary>
        /// <returns>List of Application_Info objects</returns>
        public static List<Application_Info> GetAll()
        {
            try
            {
                List<Application_Info> result = APPLICATIONS.OfType<Application_Info>().ToList<Application_Info>();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}