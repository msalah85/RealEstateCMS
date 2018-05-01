using Business.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Services
{
    public class UserService : BaseSearchService<UserViewModel, LogInParams>
    {
        protected override string Find_SP
        {
            get
            {
                return "Users_Login";
            }
        }

        protected override string Insert_SP
        {
            get
            {
                return "Users_Register";
            }
        }


    }
}
