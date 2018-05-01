using Business.Enums;
using Business.Extenions;
using Business.Globalization;
using Business.Services;
using Business.Services.Models;
using Business.SessionImpl;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Share.CMS.MaskanWebSite.Areas.Core.Controllers
{
    public class PropertyController : Controller
    {
        // GET: Core/Property
        public ActionResult Index()
        {
            // Set Language Information.
            ManageUserLanguage(GetActiveLanguage());
            return View();
        }


        public int GetActiveLanguage()
        {
            try
            {
                LanguageService _languageService = new LanguageService();
                List<LanguagesViewModel> langs = new List<LanguagesViewModel>();
                langs = _languageService.Find();
                if (langs.Count > 0)
                    return langs[0].LanguageId;
                else
                    return -1;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private DataTable tb_GUI_Lang = new DataTable();
        private void ManageUserLanguage(int userLangID)
        {
            try
            {
                string direction = "RTL";
                if (userLangID == 2) direction = "LTR";
                GlobalizationManager _GlobalizationManager;

                SessionHandler.Instance.Remove(SessionEnum.Language_Info);

                if (userLangID != LocalizationService.GetLanguageID("Default"))
                {
                    string module = (ApplicationService.GetByID(Apps.MaskanWeb)).ApplicationName;
                    DataSet ds_ModuleWL = LocalizationService.GetModule(Convert.ToInt32(userLangID), module, true);

                    Session["loginISRTL"] = false;

                    if (ds_ModuleWL != null)
                    {
                        _GlobalizationManager = new GlobalizationManager(ds_ModuleWL, direction);
                    }
                    else
                    {
                        _GlobalizationManager = new GlobalizationManager(tb_GUI_Lang);
                    }
                    SessionHandler.Instance.Set(_GlobalizationManager, SessionEnum.Language_Info);
                }
                else
                {
                    _GlobalizationManager = new GlobalizationManager(tb_GUI_Lang);
                    SessionHandler.Instance.Set(_GlobalizationManager, SessionEnum.Language_Info);
                }
            }
            catch (Exception ex)
            {
                Session["ds_Language_WL"] = null;
            }
        }

    }
}