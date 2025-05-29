using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LibraryManagementSystem2.Models.Entity;
namespace LibraryManagementSystem2.Controllers
{
    [Authorize]
    public class MyPanelController : Controller
    {
        // GET: MyPanel
        DBLIBRARY2Entities db = new DBLIBRARY2Entities();
        [HttpGet]
        public ActionResult Index()
        {
            var membermail = (string)Session["Mail"];
            var value = db.TBLMEMBERS.FirstOrDefault(z => z.EMAIL == membermail);
            return View(value);
        }
        [HttpPost]
        public ActionResult Index2(TBLMEMBERS p)
        {
            var user = (string)Session["Mail"];
            var member = db.TBLMEMBERS.FirstOrDefault(x => x.EMAIL == user);
            member.PASSWORD = p.PASSWORD;
            member.NAME = p.NAME;
            member.SURNAME = p.SURNAME;
            member.USERNAME = p.USERNAME;
            member.SCHOOL = p.SCHOOL;
            member.PHOTO = p.PHOTO;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MyBooks()
        {
            var user = (string)Session["Mail"];
            var ID = db.TBLMEMBERS.Where(x => x.EMAIL == user.ToString()).Select(z => z.ID).FirstOrDefault();
            var value = db.TBLMOVEMENT.Where(x => x.MEMBER == ID).ToList();
            return View(value);
        }
        public ActionResult Announcement()
        {
            var announcementlist = db.TBLANNOUNCEMENTS.ToList();
            return View(announcementlist);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }
    }
}