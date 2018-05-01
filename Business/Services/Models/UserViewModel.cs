using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Services.Models
{
    public class UserViewModel
    {
        public int? UserID { get; set; }

        public string UserFullName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public string Mobile { get; set; }

        public string Nationality { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        //public int? Result { get; set; }

    }
}