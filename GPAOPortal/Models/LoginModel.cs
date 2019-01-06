using FluentValidation.Attributes;
using GPAOPortal.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GPAOPortal.Models
{
    [Validator(typeof(LoginModelValidation))]
    public class LoginModel
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }

        
    }
}