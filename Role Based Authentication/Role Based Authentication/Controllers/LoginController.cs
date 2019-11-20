using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Role_Based_Authentication.Models;

namespace Role_Based_Authentication.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user, string ReturnUrl)
        {
            SampleDBEntities1 DbContext = new SampleDBEntities1();
            User data = DbContext.Users.FirstOrDefault(x => x.userName == user.userName && x.password == user.password);
            if (data != null)
            {
                FormsAuthentication.SetAuthCookie(user.userName, false);
                return RedirectToAction("Index", "Home");

                // return Redirect(ReturnUrl);
            }
            else
            {
                ModelState.AddModelError("password", "please enter correct user name or password");
                return View(user);
            }

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }
    }
}