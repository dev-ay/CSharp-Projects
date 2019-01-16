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
    public class ScheduleTemplateController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ScheduleTemplate
        public ActionResult Index()
        {
            return View(db.ScheduleTemplate.ToList());
        }

       

        // GET: ScheduleTemplate/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ScheduleTemplate/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Notes")] ScheduleTemplate scheduleTemplate)
        {
            if (ModelState.IsValid)
            {
                scheduleTemplate.Id = Guid.NewGuid();
                db.ScheduleTemplate.Add(scheduleTemplate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(scheduleTemplate);
        }

        // GET: ScheduleTemplate/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleTemplate scheduleTemplate = db.ScheduleTemplate.Find(id);
            if (scheduleTemplate == null)
            {
                return HttpNotFound();
            }
            return View(scheduleTemplate);
        }

        // POST: ScheduleTemplate/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Notes")] ScheduleTemplate scheduleTemplate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scheduleTemplate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scheduleTemplate);
        }

        // GET: ScheduleTemplate/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleTemplate scheduleTemplate = db.ScheduleTemplate.Find(id);
            if (scheduleTemplate == null)
            {
                return HttpNotFound();
            }
            return View(scheduleTemplate);
        }

        // POST: ScheduleTemplate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ScheduleTemplate scheduleTemplate = db.ScheduleTemplate.Find(id);
            db.ScheduleTemplate.Remove(scheduleTemplate);
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


        //Get events from database context
        public JsonResult GetEvents()
        {
            var events = db.Events.ToList();
            return new JsonResult
            {
                Data = events,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }


        [HttpPost]
        public JsonResult SaveEvent(Event u)
        {
            var status = false;

            //If EventID exists, replace current event c with updated event u.
            //Otherwise, add new event n to database
            if(u.EventID == Guid.Empty)
            {
                var test = Guid.NewGuid();
                u.EventID = test;
                db.Events.Add(u);
            }
            else
            {
                var c = db.Events.Where(a => a.EventID == u.EventID).FirstOrDefault();
                if(c != null)
                {
                    c.Title = u.Title;
                    c.Start = u.Start;
                    c.End = u.End;
                    c.Note = u.Note;
                    //c.Color = u.Color;
                    //c.IsFullDay = u.IsFullDay;
                }
            }

            db.SaveChanges();
            status = true;

            return new JsonResult { Data = new { status = status } };
        }


        [HttpPost]
        public JsonResult DeleteEvent(Guid EventID)
        {
            var status = false;

            var c = db.Events.Where(a => a.EventID == EventID).FirstOrDefault();
            if(c != null)
            {
                db.Events.Remove(c);
                db.SaveChanges();
                status = true;
            }

            return new JsonResult { Data = new { status = status } };
        }


    }
}
