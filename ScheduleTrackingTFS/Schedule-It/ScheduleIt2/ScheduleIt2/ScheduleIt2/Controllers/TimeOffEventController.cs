using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ScheduleIt2.Models;
using Microsoft.AspNet.Identity;

namespace ScheduleIt2.Controllers
{
    public class TimeOffEventController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TimeOffEvent
        // Makes sure the user is an Admin before allowing them to view the Index
        [Authorize]
        public ActionResult Index()
        {

            if (User.IsInRole("Admin"))
            {
                ViewBag.headerData = new TimeOffEvent();
                return View(db.TimeOffEvents.OrderBy(x => x.Start).ToList());
            }
            else return View("~/Views/AdminError.cshtml");
        }

        // GET: TimeOffEvent/Create
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else return View("~/Views/LoginError.cshtml");
        }
        // POST: TimeOffEvent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EventID,Start,End,Note,Title,ActiveSchedule,ApproverId,Submitted")] TimeOffEvent timeOffEvent)
        {
            if (ModelState.IsValid)
            {
                // Setting the submitted time to now
                timeOffEvent.Submitted = DateTime.Now;
                // Setting the eventID to a new unique GUID, without this, it is all 0s
                timeOffEvent.EventID = Guid.NewGuid();
                db.TimeOffEvents.Add(timeOffEvent);
                timeOffEvent.Id = HttpContext.User.Identity.GetUserId();
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(timeOffEvent);
        }

        // GET: TimeOffEvent/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeOffEvent timeOffEvent = (TimeOffEvent)db.TimeOffEvents.Find(id);
            if (timeOffEvent == null)
            {
                return HttpNotFound();
            }
            return View(timeOffEvent);
        }

        // POST: TimeOffEvent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EventID,Start,End,Note,Title,ActiveSchedule,ApproverId,Submitted")] TimeOffEvent timeOffEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timeOffEvent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(timeOffEvent);
        }

        // GET: TimeOffEvent/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeOffEvent timeOffEvent = db.TimeOffEvents.Find(id);
            if (timeOffEvent == null)
            {
                return HttpNotFound();
            }
            return View(timeOffEvent);
        }

        // POST: TimeOffEvent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TimeOffEvent timeOffEvent = db.TimeOffEvents.Find(id);
            db.TimeOffEvents.Remove(timeOffEvent);
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

        //Function takes in a string message title and a string message Content 
        //  and sends the message to all users in current database
        private void MessageAll(string messageTitle, string content)
        {
            Message m = new Message
            {
                MessageID = new Guid(),
                MessageTitle = messageTitle,
                Content = content,
                DateSent = DateTime.Now,
                Sender = db.Users.Find("be59571d - 359d - 449e-b540 - ac529c09b9f0") //Sender is Admin
            };

            foreach (var user in db.Users)
            {
                m.Recipient = user;
                db.Messages.Add(m);
                db.SaveChanges();
            }


        }


    }
}
