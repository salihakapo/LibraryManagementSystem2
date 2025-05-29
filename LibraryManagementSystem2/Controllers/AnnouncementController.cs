using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem2.Models.Entity;
namespace LibraryManagementSystem2.Controllers
{
    public class AnnouncementController : Controller
    {
        // GET: Announcement
        DBLIBRARY2Entities db = new DBLIBRARY2Entities();
        public ActionResult Index()
        {
            var value = db.TBLANNOUNCEMENTS.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult NewAnnouncement()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewAnnouncement(TBLANNOUNCEMENTS t)
        {
            db.TBLANNOUNCEMENTS.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAnnouncement(int id)
        {
            var announcement = db.TBLANNOUNCEMENTS.Find(id);
            db.TBLANNOUNCEMENTS.Remove(announcement);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DetailAnnouncement(TBLANNOUNCEMENTS p)
        {
            var announcement = db.TBLANNOUNCEMENTS.Find(p.ID);
            return View("DetailAnnouncement", announcement);
        }
        public ActionResult UpdateAnnouncement(TBLANNOUNCEMENTS t)
        {
            var announcement = db.TBLANNOUNCEMENTS.Find(t.ID);
            announcement.CATEGORY = t.CATEGORY;
            announcement.CONTENTS = t.CONTENTS;
            announcement.DATE = t.DATE;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}