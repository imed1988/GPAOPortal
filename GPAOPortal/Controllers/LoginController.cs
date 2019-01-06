using GPAOPortal.Models;
using GPAOPortal.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GPAOPortal.Controllers
{
    public class LoginController : Controller
    {
        private SGBDEntities sgbd = new SGBDEntities();

        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.MenuLevel1 = this.sgbd.Menus.ToList();
            ViewBag.LoginFailed = null;
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            using (SGBDEntities sgbd = new SGBDEntities())
            {
                var validator = new LoginModelValidation();
                var errors = validator.Validate(model);
                if (errors.Errors.Count > 0)
                {
                    foreach (var item in errors.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage + "</br>");
                    }
                }
                else
                {

                    var user = sgbd.UserLogin.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password && u.RoleID == u.Roles.RoleID);
                    if (user != null)
                    {
                        var lstMenu = sgbd.Menus.Where(x => x.AccessTo == user.RoleID && x.AccessTo==x.Roles.RoleID).ToList();
                        return View("Dashboard",lstMenu);
                    }
                }
                ViewBag.LoginFailed = true;
                return View();

            }
          
        }


        [HttpGet]
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}