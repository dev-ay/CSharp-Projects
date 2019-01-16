using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ScheduleIt2.Models
{
    public class Message
    {
        [Key]
        public Guid MessageID { get; set; }
        [Display(Name = "Date Sent")]
        public DateTime DateSent { get; set; }
        [Display(Name = "Date Read")]
        public DateTime? DateRead { get; set; }
        [Display(Name = "Message Title")]
        public string MessageTitle { get; set; }
        public string Content { get; set; }
        public ApplicationUser Sender { get; set; }
        public ApplicationUser Recipient { get; set; }
        public Guid? EventID { get; set; }
    }
}