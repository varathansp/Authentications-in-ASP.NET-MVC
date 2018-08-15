using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FormAuthentication.Models;

namespace FormAuthentication.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user, string ReturnUrl)
        {
            SampleDBEntities DbContext = new SampleDBEntities();
            User data = DbContext.Users.FirstOrDefault(x => x.userName == user.userName && x.password == user.password);
            if (data != null)
            {
                FormsAuthentication.SetAuthCookie(user.userName, true);
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