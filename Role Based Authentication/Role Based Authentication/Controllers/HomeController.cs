using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Role_Based_Authentication.Models;

namespace Role_Based_Authentication.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            SampleDBEntities1 DbContext = new SampleDBEntities1();
            string username = User.Identity.Name;
            string role= DbContext.Users.FirstOrDefault(x => x.userName == username).role;
            ViewData["role"] = role;
            return View();
        }
        [Authorize(Roles ="Manager")]
        public ActionResult ManagerPage()
        {
            return View();
        }
        [Authorize(Roles ="Employee,Manager")]
        public ActionResult EmployeePage()
        {
            return View();
        }

    }
}