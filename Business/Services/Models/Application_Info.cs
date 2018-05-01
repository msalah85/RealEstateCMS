using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Services.Models
{
    public class Application_Info
    {
        public int ApplicationID { set; get; }

        public string ApplicationName { set; get; }

        public string ApplicationDisplayName { set; get; }

        public string ApplicationLanguageFile { set; get; }

        public Application_Info(int applicationID, string applicationName, string applicationDisplayName, string applicationLanguageFile)
        {
            ApplicationID = applicationID;
            ApplicationName = applicationName;
            ApplicationDisplayName = applicationDisplayName;
            ApplicationLanguageFile = applicationLanguageFile;
        }
    }
}