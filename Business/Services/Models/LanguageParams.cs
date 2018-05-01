using Business.BaseSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Services.Models
{
    public class LanguageParams : IBaseSearch
    {
        public int LanguageId { get; set; }
    }
}