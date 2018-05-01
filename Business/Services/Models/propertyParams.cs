using Business.AutoMapper;
using Business.BaseSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Services.Models
{
    public class propertyParams :  IBaseSearch
    {
        public int DisplayStart { get; set; }

        public int DisplayLength { get; set; }

        public string SearchParam { get; set; }

        public string SortColumn { get; set; }

        public string SortDirection { get; set; }

    }
}