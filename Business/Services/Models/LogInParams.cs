using Business.AutoMapper;
using Business.BaseSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Services.Models
{
    public class LogInParams : IBaseSearch
    {
        public string Username { get; set; }

        public string Password { get; set; }

    }
}