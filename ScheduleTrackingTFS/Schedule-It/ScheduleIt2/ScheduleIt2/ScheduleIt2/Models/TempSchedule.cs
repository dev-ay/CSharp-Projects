using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ScheduleIt2.Models
{
    public class TempSchedule : Schedule
    {
        public int Priority { get; set; }
        [Display(Name = "Date Created")]
        public DateTime? DateCreated { get; set; }
    }
}