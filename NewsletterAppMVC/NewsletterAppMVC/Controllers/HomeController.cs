using NewsletterAppMVC.Models;
using NewsletterAppMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsletterAppMVC.Controllers
{
    public class HomeController : Controller
    {
        /*
        private readonly string _connectionString = @"Data Source=DESKTOP-LTB9U22\SQLEXPRESS;Initial Catalog=Newsletter;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        */

        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult SignUp(string firstName, string lastName, string emailAddress)
        {

            if(string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(emailAddress))
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else{

                using (NewsletterEntities db = new NewsletterEntities())
                {
                    var signup = new SignUp
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        EmailAddress = emailAddress
                    };
                    db.SignUps.Add(signup);
                    db.SaveChanges();
                    
                }
                return View("Success");

                //string queryString = @"INSERT INTO SignUps (LastName, FirstName, EmailAddress) 
                //                    VALUES (@FirstName, @LastName,@EmailAddress)";
                //using(SqlConnection connection = new SqlConnection(_connectionString))
                //{
                //    SqlCommand command = new SqlCommand(queryString, connection);
                //    command.Parameters.Add("@FirstName",SqlDbType.VarChar);
                //    command.Parameters.Add("@LastName",SqlDbType.VarChar);
                //    command.Parameters.Add("@EmailAddress",SqlDbType.VarChar);
                //    command.Parameters["@FirstName"].Value = firstName;
                //    command.Parameters["@LastName"].Value = lastName;
                //    command.Parameters["@EmailAddress"].Value = emailAddress;
                //    connection.Open();
                //    command.ExecuteNonQuery();
                //    connection.Close();
                //}
                //return View("Success");

            }
            
        }

        //Retrieve database data, map to Models NewsLetterSignUp, re-map necessary information to ViewModels SignUpVM and pass view model to View()
        //public ActionResult Admin()
        //{

            //string queryString = @"SELECT Id, FirstName, LastName, EmailAddress, SocialSecurityNumber FROM SignUps";
            //List<NewsletterSignUp> signups = new List<NewsletterSignUp>();

            //using(SqlConnection connection = new SqlConnection(_connectionString))
            //{
            //    SqlCommand command = new SqlCommand(queryString, connection);
            //    connection.Open();
            //    SqlDataReader reader = command.ExecuteReader();

            //    while (reader.Read())
            //    {
            //        var signup = new NewsletterSignUp
            //        {
            //            Id = Convert.ToInt32(reader["Id"]),
            //            FirstName = reader["FirstName"].ToString(),
            //            LastName = reader["LastName"].ToString(),
            //            EmailAddress = reader["EmailAddress"].ToString(),
            //            SocialSecurityNumber = reader["SocialSecurityNumber"].ToString()
            //        };
            //        signups.Add(signup);
            //    }

            //}

            //var signupsVM = new List<SignUpVM>();

            //foreach(var signup in signups)
            //{
            //    var signupVM = new SignUpVM
            //    {
            //        FirstName = signup.FirstName,
            //        LastName = signup.LastName,
            //        EmailAddress = signup.EmailAddress
            //    };
            //    signupsVM.Add(signupVM);
            //}

            //return View(signupsVM);
        //}

    }
}