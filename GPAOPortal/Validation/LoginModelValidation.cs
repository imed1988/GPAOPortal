using FluentValidation;
using GPAOPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GPAOPortal.Validation
{
    public class LoginModelValidation:AbstractValidator<LoginModel>
    {

        public LoginModelValidation()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password required");
        }
    }
}