using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ScheduleIt2.Models;

namespace ScheduleIt2.Controllers
{
    public class TempScheduleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TempSchedule
        public ActionResult Index()
        {
            return View(db.TempSchedules.ToList());
        }

        

        // GET: TempSchedule/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TempSchedule/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Notes,ScheduleStartDay,ScheduleEndDay,UserId,Repeating,TemplateId,Priority,DateCreated")] TempSchedule tempSchedule)
        {
            if (ModelState.IsValid)
            {
                tempSchedule.Id = Guid.NewGuid();
                tempSchedule.DateCreated = DateTime.Now;
                tempSchedule.UserId = HttpContext.User.Identity.GetUserId();
                db.TempSchedules.Add(tempSchedule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tempSchedule);
        }

        // GET: TempSchedule/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TempSchedule tempSchedule = db.TempSchedules.Find(id);
            if (tempSchedule == null)
            {
                return HttpNotFound();
            }
            return View(tempSchedule);
        }

        // POST: TempSchedule/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Notes,ScheduleStartDay,ScheduleEndDay,UserId,Repeating,TemplateId,Priority,DateCreated")] TempSchedule tempSchedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tempSchedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tempSchedule);
        }

        // GET: TempSchedule/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TempSchedule tempSchedule = db.TempSchedules.Find(id);
            if (tempSchedule == null)
            {
                return HttpNotFound();
            }
            return View(tempSchedule);
        }

        // POST: TempSchedule/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            TempSchedule tempSchedule = db.TempSchedules.Find(id);
            db.TempSchedules.Remove(tempSchedule);
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
    }
}
