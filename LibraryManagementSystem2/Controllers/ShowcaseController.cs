using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem2.Models.Entity;
using LibraryManagementSystem2.Models.Myclasses;
namespace LibraryManagementSystem2.Controllers
{
    [AllowAnonymous]
    public class ShowcaseController : Controller
    {
        // GET: Showcase
        DBLIBRARY2Entities db = new DBLIBRARY2Entities();
        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Value1 = db.TBLBOOK.ToList();
            cs.Value2 = db.TBLABOUT.ToList();
            //var value = db.TBLBOOK.ToList();
            return View(cs);
        }
        [HttpPost]
        public ActionResult Index(TBLCONTACT t)
        {
            db.TBLCONTACT.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}