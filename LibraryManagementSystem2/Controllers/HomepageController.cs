using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem2.Models.Entity;

namespace LibraryManagementSystem2.Controllers
{
    public class HomepageController : Controller
    {
        // GET: Homepage
        DBLIBRARY2Entities db = new DBLIBRARY2Entities();
        public ActionResult Index()
        {
            var value1 = db.TBLMEMBERS.Count();
            var value2 = db.TBLBOOK.Count();
            var value3 = db.TBLBOOK.Where(x => x.STATUS == false).Count();
            var value4 = db.TBLPENALTIES.Sum(x => x.MONEY);
            ViewBag.vle1 = value1;
            ViewBag.vle2 = value2;
            ViewBag.vle3 = value3;
            ViewBag.vle4 = value4;
            return View();
        }
    }
}