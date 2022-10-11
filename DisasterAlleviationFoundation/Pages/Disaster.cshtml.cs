using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DisasterAlleviationFoundation.Pages
{
    public class DisasterModel : PageModel
    {
        public string errorMessage = "";
        public string successMessage = "";
        public void OnGet()
        {
        }

        public void OnPost()
        {
            DateTime StartDate = Convert.ToDateTime(Request.Form["StartDate"]);
            DateTime EndDate = Convert.ToDateTime(Request.Form["EndDate"]);
            string Location = Request.Form["Location"];
            string Description = Request.Form["descripDisas"];
            string AidTypes = Request.Form["AidType"];

            DateTime date = StartDate.Date;
            DateTime date1 = EndDate.Date;
            try
            {
                string connectionString = "Server=tcp:diasterassignment.database.windows.net,1433;Initial Catalog=Disaster;Persist Security Info=False;User ID=st10118146;Password=Plugfilm60;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

                SqlConnection connection = new SqlConnection(connectionString);

                string sql = "INSERT INTO DISASTER (StartDate,EndDate,Location,Description,AidTypes) VALUES(@StartDate,@EndDate,@Location,@descripDisas,@AidType)";

                SqlCommand cmd = new SqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@StartDate", date);
                cmd.Parameters.AddWithValue("@EndDate", date1);
                cmd.Parameters.AddWithValue("@Location", Location);
                cmd.Parameters.AddWithValue("@descripDisas", Description);
                cmd.Parameters.AddWithValue("@AidType", AidTypes);

                connection.Open();

                cmd.ExecuteNonQuery();

                connection.Close();

                successMessage = "Yaaay you donated thank you";
                Response.Redirect("/ViewDisasters");
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }
    }
}
