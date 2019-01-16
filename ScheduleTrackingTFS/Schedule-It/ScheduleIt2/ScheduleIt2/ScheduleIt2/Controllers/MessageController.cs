using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ScheduleIt2.Models;

namespace ScheduleIt2.Controllers
{
    public class MessageController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Message
        //Checks if you are in the adminsitrators role, if not, redirects to error page. 
        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                return View(db.Messages.ToList());
            }
            else return View("~/Views/AdminError.cshtml");
        }

        // GET: Message/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Message/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MessageID,DateSent,DateRead,MessageTitle,Content,UnreadMessage")] Message message)
        {
            if (ModelState.IsValid)
            {
                message.DateSent = DateTime.Now;
                message.MessageID = Guid.NewGuid();
                db.Messages.Add(message);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(message);
        }

        // GET: Message/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: Message/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Message message = db.Messages.Find(id);
            db.Messages.Remove(message);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: Message/Inbox
        public ActionResult Inbox()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View(db.Messages.Where(m => m.Recipient == db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault()).ToList());
            }
            else return View("LoginError");
        }

        // POST: Message/MarkAsRead
        [HttpPost]
        public string MarkAsRead(Guid id)
        {
            var message = db.Messages.Find(id);
            message.DateRead = DateTime.Now;
            db.SaveChanges();
            return message.DateRead.ToString();
        }
    }
}
