using Business.Extenions;
using Business.Services;
using Business.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Share.CMS.WebApi._0.Controllers
{
    public class UsersAPIController : ApiController
    {

        [HttpPost]
        [Route("api/UsersService/LogIn")]
        public HttpResponseMessage LogIn(LogInParams _LogInViewModel)
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
                return Request.CreateResponse(HttpStatusCode.OK, User_List);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,ex.Message);
            }
        }


        [HttpPost]
        [Route("api/UsersService/Register")]
        public HttpResponseMessage Register(UserViewModel model)
        {
            try
            {
                UserService _userService = new UserService();
                string _pass = EncryptDecryptString.Decrypt(model.Password, "Taj$$Key");
                var _paramters = new UserViewModel()
                {
                    Username = model.Username,
                    UserFullName=model.Username,
                    Password= _pass,
                    Email = model.Email,
                    Phone = model.Phone,
                    Address = model.Address,
                    Country = model.Country
                };
                _paramters.UserID = null;
                _paramters.IsActive = null;
                _paramters.IsDeleted = null;

                int Result = _userService.Insert(_paramters);

                if (Result == -1)
                    return Request.CreateResponse(HttpStatusCode.OK, "User with this Email or Username Already Exists");
                if (Result < 0)
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, Result);
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,ex.Message);
            }
        }


        [HttpPost]
        [Route("api/PropertyService/Properties_List")]
        public HttpResponseMessage Properties_List(propertyParams _propertyParams)
        {
            try
            {
                propertyService _propertyService = new propertyService();
                var _paramters = new propertyParams()
                {
                    DisplayStart = _propertyParams.DisplayStart,
                    DisplayLength = _propertyParams.DisplayLength
                };
                List<propertyViewModel> Properties_List = new List<propertyViewModel>();
                Properties_List = _propertyService.Find(_paramters);
                return Request.CreateResponse(HttpStatusCode.OK, Properties_List);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,ex.Message);
            }
        }


    }
}
