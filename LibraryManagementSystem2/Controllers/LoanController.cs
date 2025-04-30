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
            return View();
        }
        [HttpPost]
        public ActionResult Lend(TBLMOVEMENT p)
        {
            db.TBLMOVEMENT.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult LoanReturn(int id)
        {
            var loan = db.TBLMOVEMENT.Find(id);
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