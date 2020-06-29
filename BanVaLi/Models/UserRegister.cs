using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanVaLi.Models
{
    public class UserRegister
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Fullname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}