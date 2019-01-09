using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GPAOPortal.Controllers
{
    public class RegisterController : Controller
    {
        private SGBDEntities sgbd = new SGBDEntities();

        public ActionResult Create()
        {
            ViewBag.RoleID = new SelectList(sgbd.Roles, "RoleID", "RoleName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,FullName,Mobile,Address,Username,Password,RoleID")] UserLogin userLogin)
        {
            if (ModelState.IsValid)
            {
                sgbd.UserLogin.Add(userLogin);
                sgbd.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleID = new SelectList(sgbd.Roles, "RoleID", "RoleName", userLogin.RoleID);
            return View(userLogin);
        }
    }
}