using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarInsuranceAppMVC_Excel.ViewModels
{
    public class QuoteVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public System.DateTime BirthDate { get; set; }
        public int CarYear { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public int DUI { get; set; }
        public int Tickets { get; set; }
        public int Coverage { get; set; }
        public Nullable<decimal> MonthlyCost { get; set; }
    }
}


