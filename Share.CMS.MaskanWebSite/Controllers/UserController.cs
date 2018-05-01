using Business.Enums;
using Business.Extenions;
using Business.Services;
using Business.Services.Models;
using Business.SessionImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Share.CMS.MaskanWebSite.Controllers
{
    public class UserController : Controller
    {

        [HttpPost]
        public int LogIn(LogInParams _LogInViewModel)
        {
            try
            {
                UserService _userService = new UserService();
                string _pass = EncryptDecryptString.Encrypt(_LogInViewModel.Password, "Taj$$Key");
                var _paramters = new LogInParams()
                {
                    Username = _LogInViewModel.Username,
                    Password = _pass
                };

                List<UserViewModel> User_List = new List<UserViewModel>();
                User_List = _userService.Find(_paramters);
                if (User_List.Count <= 0)
                    return -1;

                SessionHandler.Instance.Set(User_List, SessionEnum.User_Info); // Save User Session.
                return 1;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}