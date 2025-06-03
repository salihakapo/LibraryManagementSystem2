using LibraryManagementSystem2.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagementSystem2.Controllers
{
    public class SettingsController : Controller
    {
        // GET: Settings
        DBLIBRARY2Entities db = new DBLIBRARY2Entities();
        public ActionResult Index()
        {
            var users = db.TBLADMIN.ToList();
            return View(users);
        }
        public ActionResult Index2()
        {
            var users = db.TBLADMIN.ToList();
            return View(users);
        }
        [HttpGet]
        public ActionResult NewAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewAdmin(TBLADMIN t)
        {
            db.TBLADMIN.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
        public ActionResult DeleteAdmin(int id)
        {
            var admin = db.TBLADMIN.Find(id);
            db.TBLADMIN.Remove(admin);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            var admin = db.TBLADMIN.Find(id);
            return View("UpdateAdmin", admin);
        }
        [HttpPost]
        public ActionResult UpdateAdmin(TBLADMIN p)
        {
            var admin = db.TBLADMIN.Find(p.ID);
            admin.USERNAME = p.USERNAME;
            admin.PASSWORD = p.PASSWORD;
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
    }
}