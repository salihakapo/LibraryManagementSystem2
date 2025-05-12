using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem2.Models.Entity;

namespace LibraryManagementSystem2.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        DBLIBRARY2Entities db = new DBLIBRARY2Entities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Uploadimage(HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                string filepath = Path.Combine(Server.MapPath("~/web2/resimler/"), Path.GetFileName(file.FileName));
                file.SaveAs(filepath);
            }
            return RedirectToAction("Index");
        }
        public ActionResult LinqCard()
        {
            var value1 = db.TBLBOOK.Count();
            var value2 = db.TBLMEMBERS.Count();
            var value3 = db.TBLPENALTIES.Sum(x => x.MONEY);
            var value4 = db.TBLBOOK.Where(x => x.STATUS == false).Count();
            var value5 = db.TBLCATEGORY.Count();
            var value8 = db.TheMostBookAuthor().FirstOrDefault();
            var value9 = db.TBLBOOK.GroupBy(x => x.PUBLISHER).OrderByDescending(z => z.Count()).Select(a => new { a.Key }).FirstOrDefault();
            var value11 = db.TBLCONTACT.Count();

            ViewBag.vle1 = value1;
            ViewBag.vle2 = value2;
            ViewBag.vle3 = value3;
            ViewBag.vle4 = value4;
            ViewBag.vle5 = value5;
            ViewBag.vle8 = value8;
            ViewBag.vle9 = value9;
            ViewBag.vle11 = value11;
            return View();
        }
    }
}