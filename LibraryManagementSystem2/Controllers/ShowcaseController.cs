using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem2.Models.Entity;
namespace LibraryManagementSystem2.Controllers
{
    public class ShowcaseController : Controller
    {
        // GET: Showcase
        DBLIBRARY2Entities db = new DBLIBRARY2Entities();
        public ActionResult Index()
        {
            var value = db.TBLBOOK.ToList();
            return View(value);
        }
    }
}