using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace DisasterAlleviationFoundation.Pages
{
    public class DonationModel : PageModel
    {
        public string errorMessage = "";
        public string successMessage = "";
        public void OnGet()
        {
        }

        public void OnPost()
        {
            DateTime DateMD = Convert.ToDateTime(Request.Form["dateMD"]);
            int AmountMD = Convert.ToInt32(Request.Form["amountMD"]);
            string DonorMD = Request.Form["donorMD"];

            DateTime date = DateMD.Date;
            try
            {
                string connectionString = "Server=tcp:diasterassignment.database.windows.net,1433;Initial Catalog=Disaster;Persist Security Info=False;User ID=st10118146;Password=Plugfilm60;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

                SqlConnection connection = new SqlConnection(connectionString);

                string sql = "INSERT INTO MonetaryDonations (DateMD,AmountMD,DonorMD) VALUES(@dateMD,@amountMD,@donorMD)";

                SqlCommand cmd = new SqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@dateMD", date);
                cmd.Parameters.AddWithValue("@amountMD", AmountMD);
                cmd.Parameters.AddWithValue("@donorMD", DonorMD);

                connection.Open();

                cmd.ExecuteNonQuery();

                connection.Close();

                successMessage = "Yaaay you donated thank you";
                Response.Redirect("/ViewMonetary");
            }
            catch(Exception ex)
            {
                errorMessage = ex.Message;
            }

            }
        }
    }

