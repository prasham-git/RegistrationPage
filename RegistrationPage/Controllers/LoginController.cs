using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegistrationPage.Models;


namespace RegistrationPage.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(LoginModel user)
        {
            if (ModelState.IsValid)
            {
                if (user.Username == "admin" && user.Password == "admin")
                {
                    Session["userid"] = Guid.NewGuid();
                    return RedirectToAction("Display", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt");
                    return View("Login");
                }
            }
            else
            {
                return View();
            }

        }
        public ActionResult Logout()
        {
            Session["userid"] = null;
            return View();
        }
    }
}