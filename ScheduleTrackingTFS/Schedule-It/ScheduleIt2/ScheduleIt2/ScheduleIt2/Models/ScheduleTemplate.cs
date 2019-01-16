using ScheduleIt2.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ScheduleIt2.Models
{
    public class ScheduleTemplate
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<ScheduledWorkPeriod> ScheduledWorkPeriods { get; set; }

    }
}