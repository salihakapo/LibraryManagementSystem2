using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem2.Models.Entity;
namespace LibraryManagementSystem2.Controllers
{
    public class MyPanelController : Controller
    {
        // GET: MyPanel
        DBLIBRARY2Entities db = new DBLIBRARY2Entities();
        [HttpGet]
        [Authorize]
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
    }
}