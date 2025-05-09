using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagementSystem2.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Uploadimage(HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                string filepath = Path.Combine(Server.MapPath("~/web2/resimler/"), Path.GetFileName(file.FileName));
                file.SaveAs(filepath);
            }
            return RedirectToAction("Index");
        }
    }
}