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

namespace Share.CMS.MaskanWebSite.Controllers
{
    public class HomeController : Controller
    {

        GlobalizationManager _GlobalizationManager = new GlobalizationManager();
        public ActionResult Index()
        {
            UserViewModel user = new UserViewModel();
            if (SessionHandler.Instance.Get(SessionEnum.Language_Info) == null)
            {
                SessionHandler.Instance.Set(_GlobalizationManager, SessionEnum.Language_Info);
            }

            if (SessionHandler.Instance.Get(SessionEnum.User_Info) == null)
            {
                SessionHandler.Instance.Set(user, SessionEnum.User_Info);
            }
            // Set Language Information.
            ManageUserLanguage(GetActiveLanguage());

            //Fill View Model.
            Models.HomeVM_UI model = new Models.HomeVM_UI();
            var cuurentuser = SessionHandler.Instance.Get(SessionEnum.User_Info);

            return View(model);
        }


        [HttpGet]
        public void SetActiveLanguage()
        {
            try
            {
                LanguageService _languageService = new LanguageService();
                var _paramters = new LanguagesViewModel()
                {
                    LanguageId = (GetActiveLanguage() == 1) ? 2 : 1
                };
                int result = _languageService.Update(_paramters);
            }
            catch (Exception ex)
            {
                throw;
            }
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




        [HttpPost]

        public ActionResult ChangeLanguage(int CurrentLangId)
        {
            if (SessionHandler.Instance.Get(SessionEnum.Language_Info) == null)
            {
                GlobalizationManager _GlobalizationManager = new GlobalizationManager();
                SessionHandler.Instance.Set(_GlobalizationManager, SessionEnum.Language_Info);
            }

            // Set Language Information.
            ManageUserLanguage(CurrentLangId);
            //Fill View Model.
            Models.HomeVM_UI model = new Models.HomeVM_UI();
            model.currentUser = SessionHandler.Instance.Get<UserViewModel>(SessionEnum.User_Info);

            return RedirectToAction("Index", "home", new { LangId = CurrentLangId });
            //
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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }

    public class LangParams
    {
        public int LangId { get; set; }

    }

}