using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem2.Models.Entity;
namespace LibraryManagementSystem2.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        DBLIBRARY2Entities db = new DBLIBRARY2Entities();
        public ActionResult Index()
        {
            var value = db.TBLCATEGORY.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(TBLCATEGORY p)
        {
            db.TBLCATEGORY.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult DeleteCategory(int id)
        {
            var category = db.TBLCATEGORY.Find(id);
            db.TBLCATEGORY.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetCategory(int id)
        {
            var ctg = db.TBLCATEGORY.Find(id);
            return View("GetCategory", ctg);
        }
        public ActionResult UpdateCategory(TBLCATEGORY p)
        {
            var ctg = db.TBLCATEGORY.Find(p.ID);
            ctg.NAME = p.NAME;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}