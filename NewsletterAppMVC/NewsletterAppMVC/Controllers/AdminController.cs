using NewsletterAppMVC.Models;
using NewsletterAppMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsletterAppMVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {

            using (NewsletterEntities db = new NewsletterEntities())
            {
                //var signups = db.SignUps.Where(X => X.Removed == null); //Lambda syntax
                //var signups = db.SignUps.Where(X => X.Removed == null).ToList(); //Adding ToList() performs the same

                var signups = (from c in db.SignUps where c.Removed == null select c); //LINQ syntax
                //var signups = (from c in db.SignUps where c.Removed == null select c).ToList();

                var signupsVM = new List<SignUpVM>();

                foreach (var signup in signups)
                {
                    var signupVM = new SignUpVM
                    {
                        Id = signup.Id,
                        FirstName = signup.FirstName,
                        LastName = signup.LastName,
                        EmailAddress = signup.EmailAddress
                    };
                    signupsVM.Add(signupVM);
                }

                return View(signupsVM);
            }

        }

        public ActionResult Unsubscribe(int Id)
        {
            using(NewsletterEntities db = new NewsletterEntities())
            {
                var signup = db.SignUps.Find(Id);
                signup.Removed = DateTime.Now;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


    }
}