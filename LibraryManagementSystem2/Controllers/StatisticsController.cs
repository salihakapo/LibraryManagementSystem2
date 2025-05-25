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
            var value6 = db.TheMostActiveMember().FirstOrDefault();
            var value7 = db.TheMostReadBook().FirstOrDefault();
            var value8 = db.TheMostBookAuthor().FirstOrDefault();
            var themostbookauthor = db.TBLBOOK.GroupBy(x => x.PUBLISHER).OrderByDescending(z => z.Count()).Select(a => a.Key).FirstOrDefault();
            var value10 = db.TopPerformingStaff().FirstOrDefault();
            var value11 = db.TBLCONTACT.Count();
            var value12 = db.TBLMOVEMENT.Where(x => x.BORROWDATE == DateTime.Today).Select(b => b.BOOK).Count();

            ViewBag.vle1 = value1;
            ViewBag.vle2 = value2;
            ViewBag.vle3 = value3;
            ViewBag.vle4 = value4;
            ViewBag.vle5 = value5;
            ViewBag.vle6 = value6;
            ViewBag.vle7 = value7;
            ViewBag.vle8 = value8;
            ViewBag.vle9 = themostbookauthor;
            ViewBag.vle10 = value10;
            ViewBag.vle11 = value11;
            ViewBag.vle12 = value12;
            return View();
        }
    }
}