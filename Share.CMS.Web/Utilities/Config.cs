using System;
using System.Configuration;
using System.Web.Security;

namespace Share.CMS.Web.Utilities
{
    public static class Config
    {
        // private
        static string user_item = "eng.msalah.abdullah@gmailcom";

        // public
        public static string AdminUrl = "sys",
            connString = ConfigurationManager.ConnectionStrings["Share.CMS.ConnStr"].ConnectionString,
        FacePageAppID = ConfigurationManager.AppSettings["FaceAppID"],
        FacePageAppSecret = ConfigurationManager.AppSettings["FaceAppSecret"],
        FacePageName = ConfigurationManager.AppSettings["FacePageName"],

        InstPageAppID = ConfigurationManager.AppSettings["instagram.clientid"],
        InstAppSecret = ConfigurationManager.AppSettings["instagram.redirecturi"],
        InstUrl = ConfigurationManager.AppSettings["FacePageName"],

        // cookie keys
        encrypptKey = "cok$4Key", _cookName = "share-web-design.com", /*EncryptDecryptString.Encrypt("Share.UserInfo", encrypptKey),*/
        cookieID = "Share.ID", cookieUsername = "Share.Name",
        cookieLevel = "Share.Level",

        _encrypted_ticket = FormsAuthentication.Encrypt(new FormsAuthenticationTicket(1, " Share Web Design ", DateTime.Now, DateTime.Now.AddDays(1), false, user_item));
    }
}