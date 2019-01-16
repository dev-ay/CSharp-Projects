using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ScheduleIt2.Models;
using System.Web.Script.Serialization;

namespace ScheduleIt2.Controllers
{
    public class ShiftController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Shift
        [Authorize]
        public async Task<ActionResult> Index()
        {
            var query = await db.ScheduledWorkPeriods.ToListAsync();
            ViewBag.Query = new JavaScriptSerializer().Serialize(query);
            return View();
        }

        // GET: Shift/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shift/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,StartTime,EndTime,Day,WorkType,ScheduleId,PayRate,IsDayOff")] ScheduledWorkPeriod scheduledWorkPeriod)
        {
            if (ModelState.IsValid)
            {
                db.ScheduledWorkPeriods.Add(scheduledWorkPeriod);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(scheduledWorkPeriod);
        }

        // GET: Shift/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduledWorkPeriod scheduledWorkPeriod = await db.ScheduledWorkPeriods.FindAsync(id);
            if (scheduledWorkPeriod == null)
            {
                return HttpNotFound();
            }
            return View(scheduledWorkPeriod);
        }

        // POST: Shift/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,StartTime,EndTime,Day,WorkType,ScheduleId,PayRate,IsDayOff")] ScheduledWorkPeriod scheduledWorkPeriod)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scheduledWorkPeriod).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(scheduledWorkPeriod);
        }
    }
}
