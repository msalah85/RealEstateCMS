using Business.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Services
{
    public class propertyService : BaseSearchService<propertyViewModel, propertyParams>
    {
        protected override string Find_SP
        {
            get
            {
                return "Properties_List";
            }
        }
    }
}