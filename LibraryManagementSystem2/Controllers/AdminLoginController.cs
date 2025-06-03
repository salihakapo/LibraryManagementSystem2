using LibraryManagementSystem2.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LibraryManagementSystem2.Controllers
{
    [AllowAnonymous]
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        DBLIBRARY2Entities db = new DBLIBRARY2Entities();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(TBLADMIN p)
        {
            var information = db.TBLADMIN.FirstOrDefault(x=>x.USERNAME ==p.USERNAME && x.PASSWORD == p.PASSWORD);
            if (information != null)
            {
                FormsAuthentication.SetAuthCookie(information.USERNAME, false);
                Session["USERNAME"] = information.USERNAME.ToString();
                return RedirectToAction("Index", "Homepage");
            }
            else 
            { 
            return View();
            }
        }
    }
}