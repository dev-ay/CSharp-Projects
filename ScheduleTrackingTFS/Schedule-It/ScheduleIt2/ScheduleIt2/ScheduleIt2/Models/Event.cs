using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ScheduleIt2.Models
{
    public class Event
    {
        [Key]
        public Guid EventID { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Start { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? End { get; set; }
        public string Note { get; set; }
        public string Title { get; set; }
        [Display(Name = "Active Schedule")]
        public bool ActiveSchedule { get; set; }
        [Display(Name = "Approver Id")]
        public string ApproverId { get; set; }
        public string Id { get; set; }
        //public virtual ICollection<ApplicationUser> ApplicationUser { get; set; }
    }
}