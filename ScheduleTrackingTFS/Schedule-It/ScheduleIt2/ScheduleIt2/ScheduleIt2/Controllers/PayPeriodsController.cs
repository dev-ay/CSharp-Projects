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
    public class PayPeriodsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PayPeriods
        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                return View(db.PayPeriods.ToList());
            }
            else return View("~/Views/AdminError.cshtml");
        }

        // GET: PayPeriods/Create
        public ActionResult Create()
        {
            if (User.IsInRole("Admin"))
            {
                return View();
            }
            else return View("~/Views/AdminError.cshtml");
        }

        // POST: PayPeriods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PayPeriodId,PayPeriodLength,DaysUntilPayPeriod,StartDate")] PayPeriod payPeriod)
        {
            if (ModelState.IsValid)
            {
                payPeriod.PayPeriodId = Guid.NewGuid();
                db.PayPeriods.Add(payPeriod);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(payPeriod);
        }

        // GET: PayPeriods/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (User.IsInRole("Admin"))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                PayPeriod payPeriod = db.PayPeriods.Find(id);
                if (payPeriod == null)
                {
                    return HttpNotFound();
                }
                return View(payPeriod);
            }
            else return View("~/Views/AdminError.cshtml");
        }

        // POST: PayPeriods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PayPeriodId,PayPeriodLength,DaysUntilPayPeriod,StartDate")] PayPeriod payPeriod)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payPeriod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(payPeriod);
        }

        // GET: PayPeriods/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (User.IsInRole("Admin")) {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                PayPeriod payPeriod = db.PayPeriods.Find(id);
                if (payPeriod == null)
                {
                    return HttpNotFound();
                }
                return View(payPeriod);
            } 
            else
            {
                return View("~/Views/AdminError.cshtml");
            }
        }

        // POST: PayPeriods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            PayPeriod payPeriod = db.PayPeriods.Find(id);
            db.PayPeriods.Remove(payPeriod);
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
