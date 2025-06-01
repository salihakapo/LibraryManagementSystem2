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

            var v1 = db.TBLMEMBERS.Where(x => x.EMAIL == membermail).Select(y => y.NAME).FirstOrDefault();
            ViewBag.v1 = v1;

            var v2 = db.TBLMEMBERS.Where(x => x.EMAIL == membermail).Select(y => y.SURNAME).FirstOrDefault();
            ViewBag.v2 = v2;

            var v3 = db.TBLMEMBERS.Where(x => x.EMAIL == membermail).Select(y => y.PHOTO).FirstOrDefault();
            ViewBag.v3 = v3;

            var v4 = db.TBLMEMBERS.Where(x => x.EMAIL == membermail).Select(y => y.USERNAME).FirstOrDefault();
            ViewBag.v4 = v4;

            var v5 = db.TBLMEMBERS.Where(x => x.EMAIL == membermail).Select(y => y.SCHOOL).FirstOrDefault();
            ViewBag.v5 = v5;

            var v6 = db.TBLMEMBERS.Where(x => x.EMAIL == membermail).Select(y => y.PHONE).FirstOrDefault();
            ViewBag.v6 = v6;

            var v7 = db.TBLMEMBERS.Where(x => x.EMAIL == membermail).Select(y => y.EMAIL).FirstOrDefault();
            ViewBag.v7 = v7;

            var memberid= db.TBLMEMBERS.Where(x => x.EMAIL == membermail).Select(y => y.ID).FirstOrDefault();
            var v8 = db.TBLMOVEMENT.Where(x => x.MEMBER == memberid).Count();
            ViewBag.v8 = v8;

            var v9 = db.TBLMESSAGES.Where(x => x.RECEIVER == membermail).Count();
            ViewBag.v9 = v9;

            var v10 = db.TBLANNOUNCEMENTS.Count();
            ViewBag.v10 = v10;
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
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
    }
}