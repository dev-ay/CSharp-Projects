using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ScheduleIt2.Models
{
    public class Schedule
    {
        public Schedule(string userId)
        {

            Id = Guid.NewGuid();
            Notes = "";
            ScheduleStartDay = DateTime.Now;
            ScheduleEndDay = null;
            UserId = userId;
            Repeating = true;
            ScheduledWorkPeriods = new List<ScheduledWorkPeriod>();
        }
        //parameterless Constructor.
        public Schedule() { }

        [Key]
        public Guid Id { get; set; }
        public string Notes { get; set; }
        [Display(Name = "Schedule Start Day")]
        public DateTime ScheduleStartDay { get; set; }
        [Display(Name = "Schedule End Day")]
        public DateTime? ScheduleEndDay { get; set; }
        [Display(Name = "User Id")]
        public string UserId { get; set; }
        public bool Repeating { get; set; }
        //added List of scheduled work periods
        [Display(Name = "Scheduled Work Periods")]
        public List<ScheduledWorkPeriod> ScheduledWorkPeriods { get; set; }
    }
}