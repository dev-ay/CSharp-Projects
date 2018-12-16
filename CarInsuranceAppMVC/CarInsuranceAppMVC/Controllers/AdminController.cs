using CarInsuranceAppMVC.Models;
using CarInsuranceAppMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsuranceAppMVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {

            using(var db = new CarInsuranceEntities())
            {
                var quotes = db.Quotes;
                var quotesVM = new List<QuoteVM>();
                foreach(var quote in quotes)
                {
                    var quoteVM = new QuoteVM
                    {
                        Id = quote.Id,
                        FirstName = quote.FirstName,
                        LastName = quote.LastName,
                        Email = quote.Email,
                        BirthDate = quote.BirthDate,
                        CarYear = quote.CarYear,
                        CarMake = quote.CarMake,
                        CarModel = quote.CarModel,
                        DUI = quote.DUI,
                        Tickets = quote.Tickets,
                        Coverage = quote.Coverage,
                        MonthlyCost = quote.MonthlyCost
                    };
                    quotesVM.Add(quoteVM);
                }
                return View(quotesVM);
            }
            
        }



    }
}