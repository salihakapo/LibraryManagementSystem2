using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem2.Models.Entity;
namespace LibraryManagementSystem2.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        DBLIBRARY2Entities db = new DBLIBRARY2Entities();
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(TBLMEMBERS p)
        {
            if (!ModelState.IsValid)
            {
                return View("Register");
            }
            db.TBLMEMBERS.Add(p);
            db.SaveChanges();
            return View();
        }
    }
}
