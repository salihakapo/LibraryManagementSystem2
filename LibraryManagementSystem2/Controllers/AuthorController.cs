using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem2.Models.Entity;
namespace LibraryManagementSystem2.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        DBLIBRARY2Entities db = new DBLIBRARY2Entities();
        public ActionResult Index()
        {
            var value = db.TBLAUTHOR.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAuthor(TBLAUTHOR p)
        {
            if(!ModelState.IsValid)
            {
                return View("AddAuthor");
            }
            db.TBLAUTHOR.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult DeleteAuthor(int id)
        {
            var author = db.TBLAUTHOR.Find(id);
            db.TBLAUTHOR.Remove(author);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetAuthor(int id)
        {
            var auth = db.TBLAUTHOR.Find(id);
            return View("GetAuthor", auth);
        }
        public ActionResult UpdateAuthor(TBLAUTHOR p)
        {
            var auth = db.TBLAUTHOR.Find(p.ID);
            auth.NAME = p.NAME;
            auth.SURNAME = p.SURNAME;
            auth.DETAILS = p.DETAILS;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AuthorBooks (int id)
        {
            var author = db.TBLBOOK.Where(x => x.AUTHOR == id).ToList();
            var authname = db.TBLAUTHOR.Where(y => y.ID == id).Select(z => z.NAME + " " + z.SURNAME).FirstOrDefault();
            ViewBag.a1 = authname;
            return View(author);
        }
    }
}