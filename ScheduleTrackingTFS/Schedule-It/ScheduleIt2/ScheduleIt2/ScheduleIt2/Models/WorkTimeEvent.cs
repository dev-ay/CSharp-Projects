using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ScheduleIt2.Models
{
    public class WorkTimeEvent : Event
    {
        // This constructor makes sure that we didn't break the test data since it wasn't coded when we had a constructor
        public WorkTimeEvent() : this("")
        {

        }

        // Constructor
        public WorkTimeEvent(string userId)
        {
            EventID = Guid.NewGuid();
            Start = DateTime.Now;
            End = null;
            Note = "";
            Title = "";
            ActiveSchedule = true;
            ApproverId = "";
            Id = userId;
            ClockFunctionStatus = Models.ClockFunctionStatus.ClockInSuccess;
        }

        [Display(Name = "Clock Function Status")]
        public ClockFunctionStatus? ClockFunctionStatus { get; set; }
    }

    public enum ClockFunctionStatus
    {
        ClockInSuccess,
        ClockInFail,
        ClockOutSuccess,
        ClockOutFail,
        ClockInUpdated,
        ClockOutUpdated
    }
}