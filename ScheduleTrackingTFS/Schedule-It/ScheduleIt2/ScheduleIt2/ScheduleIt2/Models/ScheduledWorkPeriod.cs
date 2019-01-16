using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ScheduleIt2.Models
{
    public class ScheduledWorkPeriod : Shift
    {
        public ScheduledWorkPeriod()
        {
            Id = new Guid();
        }

        public Days Day { get; set; }
        [Display(Name = "Work Type")]
        public string WorkType { get; set; }
        [Display(Name = "Schedule Id")]
        public Guid ScheduleId { get; set; }
        [Display(Name = "Pay Rate")]
        public decimal? PayRate { get; set; }
        [Display(Name = "Is Day Off")]
        public bool IsDayOff { get; set; }
    }

    public enum Days
    {
        Sun,
        Mon,
        Tue,
        Wed,
        Thur,
        Fri,
        Sat
    }
}