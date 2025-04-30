using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem2.Models.Entity;
namespace LibraryManagementSystem2.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        DBLIBRARY2Entities db = new DBLIBRARY2Entities();

        public ActionResult Index()
        {
            var value = db.TBLSTAFF.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddStaff()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStaff(TBLSTAFF p)
        {
            if (!ModelState.IsValid)
            {
                return View("AddStaff");
            }
            db.TBLSTAFF.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult DeleteStaff(int id)
        {
            var stf = db.TBLSTAFF.Find(id);
            db.TBLSTAFF.Remove(stf);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetStaff(int id)
        {
            var stf = db.TBLSTAFF.Find(id);
            return View("GetStaff", stf);
        }
        public ActionResult UpdateStaff(TBLSTAFF p)
        {
            var stf = db.TBLSTAFF.Find(p.ID);
            stf.STAFF = p.STAFF;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}