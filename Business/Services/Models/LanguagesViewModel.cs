using Business.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Services.Models
{
    public class LanguagesViewModel
    {
        public int LanguageId { get; set; }

        [NonSqlParameter]
        public string LanguageName { get; set; }

        [NonSqlParameter]
        public string LangShortcut { get; set; }

        [NonSqlParameter]
        public string Language_Direction { get; set; }

        [NonSqlParameter]
        public string LanguageFilePath { get; set; }

        [NonSqlParameter]
        public string Language_Abbreviation { get; set; }

        [NonSqlParameter]
        public string IsActive { get; set; }

    }
}