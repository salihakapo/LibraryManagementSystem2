using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem2.Models.Entity;
using System.Web.Security;
namespace LibraryManagementSystem2.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        DBLIBRARY2Entities db = new DBLIBRARY2Entities();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(TBLMEMBERS p)
        {
            var informations = db.TBLMEMBERS.FirstOrDefault(x => x.EMAIL == p.EMAIL && x.PASSWORD == p.PASSWORD);
            if (informations != null)
            {
                FormsAuthentication.SetAuthCookie(informations.EMAIL, false);
                Session["Mail"] = informations.EMAIL.ToString();
                Session["Name"] = informations.NAME.ToString();
                Session["Surname"] = informations.SURNAME.ToString();
                //TempData["Id"] = informations.ID.ToString();
                //TempData["Name"] = informations.NAME.ToString();
                //TempData["Surname"] = informations.SURNAME.ToString();
                //TempData["Username"] = informations.USERNAME.ToString();
                //TempData["Password"] = informations.PASSWORD.ToString();
                //TempData["School"] = informations.SCHOOL.ToString();
                return RedirectToAction("Index", "MyPanel");
            }
            else
            {
                return View();
            }
        }
    }
}