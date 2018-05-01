using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Services.Models
{
    public class RegisterViewModel
    {
        public int? UserID { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }

        public string Mobile { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }
    }
}
