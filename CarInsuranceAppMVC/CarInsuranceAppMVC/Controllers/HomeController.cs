using CarInsuranceAppMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsuranceAppMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult SignUp(Quote request)
        {
            decimal cost = 50;

            //Check Age
            var span = DateTime.Now - Convert.ToDateTime(request.BirthDate) ;
            var age = span.Days / 365;
            if (age < 18) cost += 100;
            else if (age < 21) cost += 25;
            else if (age > 100) cost += 25;

            //Check Car Year
            if (request.CarYear < 2000) cost += 25;
            else if (request.CarYear > 2015) cost += 25;

            //Check Car Make and Model
            if(request.CarMake == "Porsche")
            {
                cost += 25;
                if (request.CarModel == "911 Carrera") cost += 25;
            }
        
            //Check for Traffic Tickets
            cost += request.Tickets * 10;

            //Check for DUI
            if (request.DUI > 0) cost *= 1.25m;

            //Check for Coverage Option
            if (request.Coverage == 1) cost *= 1.5m;

            //Round to the penny
            cost = Math.Round(cost,2);
                
            using (var db = new CarInsuranceEntities())
            {
                var quotes = db.Quotes;
                var quote = new Quote
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    BirthDate = request.BirthDate,
                    CarYear = request.CarYear,
                    CarMake = request.CarMake,
                    CarModel = request.CarModel,
                    DUI = request.DUI,
                    Tickets = request.Tickets,
                    Coverage = request.Coverage,
                    MonthlyCost = cost
                };
                quotes.Add(quote);
                db.SaveChanges();

                return View(quote);
            }
        }




        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}