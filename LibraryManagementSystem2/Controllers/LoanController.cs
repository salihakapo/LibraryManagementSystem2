using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem2.Models.Entity;
namespace LibraryManagementSystem2.Controllers
{
    public class LoanController : Controller
    {
        // GET: Loan
        DBLIBRARY2Entities db = new DBLIBRARY2Entities();
        public ActionResult Index()
        {
            var value = db.TBLMOVEMENT.Where(x => x.TRANSACTIONSTATUS == false).ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult Lend()
        {
            List<SelectListItem> value1 = (from x in db.TBLMEMBERS.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.NAME + " " + x.SURNAME,
                                               Value = x.ID.ToString()
                                           }).ToList();
            List<SelectListItem> value2 = (from y in db.TBLBOOK.Where(y => y.STATUS == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.NAME,
                                               Value = y.ID.ToString()
                                           }).ToList();
            List<SelectListItem> value3 = (from z in db.TBLSTAFF.ToList()
                                           select new SelectListItem
                                           {
                                               Text = z.STAFF,
                                               Value = z.ID.ToString()
                                           }).ToList();
            ViewBag.vle1 = value1;
            ViewBag.vle2 = value2;
            ViewBag.vle3 = value3;
            return View();
        }
        [HttpPost]
        public ActionResult Lend(TBLMOVEMENT p)
        {
            var v1 = db.TBLMEMBERS.Where(x => x.ID == p.TBLMEMBERS.ID).FirstOrDefault();
            var v2 = db.TBLBOOK.Where(y => y.ID == p.TBLBOOK.ID).FirstOrDefault();
            var v3 = db.TBLSTAFF.Where(z => z.ID == p.TBLSTAFF.ID).FirstOrDefault();
            p.TBLMEMBERS = v1;
            p.TBLBOOK = v2;
            p.TBLSTAFF = v3;
            db.TBLMOVEMENT.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult LoanReturn(TBLMOVEMENT p)
        {
            var loan = db.TBLMOVEMENT.Find(p.ID);
            DateTime d1 = DateTime.Parse(loan.RETURNDATE.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;
            ViewBag.vlue = d3.TotalDays;
            return View("LoanReturn", loan);
        }
        public ActionResult UpdateLoan(TBLMOVEMENT p)
        {
            var mvn = db.TBLMOVEMENT.Find(p.ID);
            mvn.MEMBERRETURNDATE = p.MEMBERRETURNDATE;
            mvn.TRANSACTIONSTATUS = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}