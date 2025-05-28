using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem2.Models.Entity;
using PagedList;
using PagedList.Mvc;
namespace LibraryManagementSystem2.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        DBLIBRARY2Entities db = new DBLIBRARY2Entities();
        public ActionResult Index(int page = 1)
        {
            //var value = db.TBLMEMBERS.ToList();
            var value = db.TBLMEMBERS.ToList().ToPagedList(page, 5);
            return View(value);
        }
        [HttpGet]
        public ActionResult AddMember()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddMember(TBLMEMBERS p)
        {
            if (!ModelState.IsValid)
            {
                return View("AddMember");
            }
            db.TBLMEMBERS.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult DeleteMember(int id)
        {
            var member = db.TBLMEMBERS.Find(id);
            db.TBLMEMBERS.Remove(member);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetMember(int id)
        {
            var member = db.TBLMEMBERS.Find(id);
            return View("GetMember", member);
        }
        public ActionResult UpdateMember(TBLMEMBERS p)
        {
            var member = db.TBLMEMBERS.Find(p.ID);
            member.NAME = p.NAME;
            member.SURNAME = p.SURNAME;
            member.EMAIL = p.EMAIL;
            member.USERNAME = p.USERNAME;
            member.PASSWORD = p.PASSWORD;
            member.PHOTO = p.PHOTO;
            member.PHONE = p.PHONE;
            member.SCHOOL = p.SCHOOL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MemberBookHistory(int id)
        {
            var bookhis = db.TBLMOVEMENT.Where(x => x.MEMBER == id).ToList();
            var membook = db.TBLMEMBERS.Where(y => y.ID == id).Select(z => z.NAME + " " + z.SURNAME).FirstOrDefault();
            ViewBag.m1 = membook;
            return View(bookhis);
        }
    }
}