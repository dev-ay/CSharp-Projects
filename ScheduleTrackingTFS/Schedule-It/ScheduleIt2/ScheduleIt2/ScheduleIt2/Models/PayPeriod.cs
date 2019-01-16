using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ScheduleIt2.Models
{
    public class PayPeriod
    {
        public PayPeriod(DateTime startDate, int periodLength, int daysUntilPayDay)
        {
            PayPeriodId = new Guid();
            StartDate = startDate;
            PayPeriodLength = periodLength;
            DaysUntilPayPeriod = daysUntilPayDay;
        }

        [Key, Display(Name = "Pay Period Id")]
        public Guid PayPeriodId { get; set; }
        [Display(Name = "Pay Period Length (Days)")]
        public int PayPeriodLength { get; set; }
        [Display(Name = "Days Until Pay Period")]
        public int DaysUntilPayPeriod { get; set; }
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
    }
}