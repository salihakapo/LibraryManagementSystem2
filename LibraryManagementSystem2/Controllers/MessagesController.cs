using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LibraryManagementSystem2.Models.Entity;
namespace LibraryManagementSystem2.Controllers
{
    public class MessagesController : Controller
    {
        // GET: Messages
        DBLIBRARY2Entities db = new DBLIBRARY2Entities();
        public ActionResult Index()
        {
            var membermail = (string)Session["Mail"].ToString();
            var messages = db.TBLMESSAGES.Where(x => x.RECEIVER == membermail.ToString()).ToList();
            return View(messages);
        }
        public ActionResult Send()
        {
            var membermail = (string)Session["Mail"].ToString();
            var messages = db.TBLMESSAGES.Where(x => x.SENDER == membermail.ToString()).ToList();
            return View(messages);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(TBLMESSAGES t)
        {
            var membermail = (string)Session["Mail"].ToString();
            t.SENDER = membermail.ToString();
            t.DATE = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TBLMESSAGES.Add(t);
            db.SaveChanges();
            return RedirectToAction("Send", "Messages");
        }
        public PartialViewResult Partial1()
        {
            var membermail = (string)Session["Mail"].ToString();
            var incomingnumber = db.TBLMESSAGES.Where(x => x.RECEIVER == membermail).Count();
            ViewBag.v1 = incomingnumber;
            var sentnumber = db.TBLMESSAGES.Where(x => x.SENDER == membermail).Count();
            ViewBag.v2 = sentnumber;
            return PartialView();
        }
    }
}