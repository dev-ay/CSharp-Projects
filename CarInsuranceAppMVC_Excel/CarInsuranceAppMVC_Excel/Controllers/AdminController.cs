using CarInsuranceAppMVC_Excel.Models;
using CarInsuranceAppMVC_Excel.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsuranceAppMVC_Excel.Controllers
{
    public class AdminController : Controller
    {

        //Change Timeout from 30 to 60
        private readonly string _connectionString = @"Data Source=DESKTOP-LTB9U22\SQLEXPRESS;Initial Catalog=CarInsurance;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private string _queryString;

        // GET: Admin
        public ActionResult Index()
        {

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                _queryString = @"Select * FROM [EXCELDATA]...[Quote$]";
                SqlCommand command = new SqlCommand(_queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                var quotesVM = new List<QuoteVM>();

                while (reader.Read())
                {
                    //Read() command returns DBNULL not null, thus must use DBNULL.Value instead of null
                    if (reader["Id"] == DBNull.Value) break;

                    var quoteVM = new QuoteVM
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        BirthDate = Convert.ToDateTime(reader["BirthDate"]),
                        CarYear = Convert.ToInt32(reader["CarYear"]),
                        CarMake = reader["CarMake"].ToString(),
                        CarModel = reader["CarModel"].ToString(),
                        DUI = Convert.ToInt32(reader["DUI"]),
                        Tickets = Convert.ToInt32(reader["Tickets"]),
                        Coverage = Convert.ToInt32(reader["Coverage"]),
                        MonthlyCost = Convert.ToDecimal(reader["MonthlyCost"]),
                    };
                    quotesVM.Add(quoteVM);

                }

                return View(quotesVM);
            }

        }

    }
}