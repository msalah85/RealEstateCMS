using Business.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Services
{
    public class LanguageService : BaseSearchService<LanguagesViewModel, LanguageParams>
    {

        protected override string Find_SP
        {
            get
            {
                return "Get_Active_lang";
            }
        }

        protected override string Update_SP
        {
            get
            {
                return "Set_Active_lang";
            }
        }


    }
}