using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem2.Models.Entity;
namespace LibraryManagementSystem2.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        DBLIBRARY2Entities db = new DBLIBRARY2Entities();
        public ActionResult Index(string p)
        {
            var books = from b in db.TBLBOOK select b;
            if (!string.IsNullOrEmpty(p))
            {
                books = books.Where(m => m.NAME.Contains(p));
            }
            //var books = db.TBLBOOK.ToList();
            return View(books.ToList());
        }

        [HttpGet]
        public ActionResult AddBook()
        {
            List<SelectListItem> value1 = (from i in db.TBLCATEGORY.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.NAME,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.vle1 = value1;

            List<SelectListItem> value2 = (from i in db.TBLAUTHOR.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.NAME + ' ' + i.SURNAME,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.vle2 = value2;

            return View();
        }
        [HttpPost]
        public ActionResult AddBook(TBLBOOK p)
        {
            var ctg = db.TBLCATEGORY.Where(b => b.ID == p.TBLCATEGORY.ID).FirstOrDefault();
            var auth = db.TBLAUTHOR.Where(a => a.ID == p.TBLAUTHOR.ID).FirstOrDefault();
            p.TBLCATEGORY = ctg;
            p.TBLAUTHOR = auth;
            db.TBLBOOK.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteBook(int id)
        {
            var book = db.TBLBOOK.Find(id);
            db.TBLBOOK.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetBook(int id)
        {
            var book = db.TBLBOOK.Find(id);
            List<SelectListItem> value1 = (from i in db.TBLCATEGORY.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.NAME,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.vle1 = value1;

            List<SelectListItem> value2 = (from i in db.TBLAUTHOR.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.NAME + ' ' + i.SURNAME,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.vle2 = value2;
            return View("GetBook", book);
        }
        public ActionResult UpdateBook(TBLBOOK p)
        {
            var book = db.TBLBOOK.Find(p.ID);
            book.NAME = p.NAME;
            book.PUBLICATIONDATE = p.PUBLICATIONDATE;
            book.PUBLISHER = p.PUBLISHER;
            book.PAGECOUNT = p.PAGECOUNT;
            book.STATUS = p.STATUS;
            var ctg = db.TBLCATEGORY.Where(c => c.ID == p.TBLCATEGORY.ID).FirstOrDefault();
            var auth = db.TBLAUTHOR.Where(a => a.ID == p.TBLAUTHOR.ID).FirstOrDefault();
            book.CATEGORY = ctg.ID;
            book.AUTHOR = auth.ID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}