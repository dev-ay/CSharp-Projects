using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScheduleIt2.Models
{
    public class TimeOffEvent : Event
    {
        //constructor and parameterless constuctor. 
        public TimeOffEvent(string userId)
        {
            Id = userId;
            EventID = Guid.NewGuid();
            Start = DateTime.Now;
            End = null;
            Note = "";
            Title = "";
            ActiveSchedule = true;
            ApproverId = "";
            Submitted = DateTime.Now;
        }
        public TimeOffEvent() { }

        public DateTime? Submitted { get; set; }
    }
}