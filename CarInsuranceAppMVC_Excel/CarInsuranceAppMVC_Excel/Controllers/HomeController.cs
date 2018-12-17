using CarInsuranceAppMVC_Excel.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsuranceAppMVC_Excel.Controllers
{
    public class HomeController : Controller
    {
        //Change Timeout from 30 to 60
        private readonly string _connectionString = @"Data Source=DESKTOP-LTB9U22\SQLEXPRESS;Initial Catalog=CarInsurance;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private string _queryString = "";

        public ActionResult Index()
        {
                return View();
        }



        [HttpPost]
        public ActionResult SignUp(Quote request)
        {
            decimal cost = 50;

            //Check Age
            var span = DateTime.Now - Convert.ToDateTime(request.BirthDate);
            var age = span.Days / 365;
            if (age < 18) cost += 100;
            else if (age < 21) cost += 25;
            else if (age > 100) cost += 25;

            //Check Car Year
            if (request.CarYear < 2000) cost += 25;
            else if (request.CarYear > 2015) cost += 25;

            //Check Car Make and Model
            if (request.CarMake == "Porsche")
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
            cost = Math.Round(cost, 2);
            request.MonthlyCost = cost;

            int Id = 0;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                _queryString = @"Select [Id] FROM [EXCELDATA]...[Quote$]";
                SqlCommand command = new SqlCommand(_queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    //Read() command returns DBNULL not null, thus must use DBNULL.Value instead of null
                    if (reader["Id"] == DBNull.Value) break;

                    //Find largest Id in the Excel Database
                    int currentId = Convert.ToInt32(reader["Id"]);
                    if ( currentId > Id)
                    {
                        Id = currentId;
                    }
                }
            }

            //Increment largest existing Id in preparation for the next INSERT
            Id += 1;


            _queryString = @"INSERT INTO [EXCELDATA]...[Quote$] 
                            (Id,FirstName,LastName,Email,BirthDate,CarYear,CarMake,CarModel,DUI,Tickets,Coverage,MonthlyCost) 
                            VALUES (@Id,@FirstName,@LastName,@Email,@BirthDate,@CarYear,@CarMake,@CarModel,@DUI,@Tickets,@Coverage,@MonthlyCost)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(_queryString, connection);
                command.Parameters.AddWithValue("@Id",Id);
                command.Parameters.AddWithValue("@FirstName", request.FirstName);
                command.Parameters.AddWithValue("@LastName", request.LastName);
                command.Parameters.AddWithValue("@Email", request.Email);
                command.Parameters.AddWithValue("@BirthDate", request.BirthDate);//.ToString("MM/dd/yyyy"));
                command.Parameters.AddWithValue("@CarYear", request.CarYear);
                command.Parameters.AddWithValue("@CarMake", request.CarMake);
                command.Parameters.AddWithValue("@CarModel", request.CarModel);
                command.Parameters.AddWithValue("@DUI", request.DUI);
                command.Parameters.AddWithValue("@Tickets", request.Tickets);
                command.Parameters.AddWithValue("@Coverage", request.Coverage);
                command.Parameters.AddWithValue("@MonthlyCost", request.MonthlyCost);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }


                return View(request);
            
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