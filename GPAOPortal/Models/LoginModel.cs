using FluentValidation.Attributes;
using GPAOPortal.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        [NotMapped]
        public int RoleID { get; set; }
       

        public IEnumerable<SelectListItem> userLogins { get; set; }

    }
}