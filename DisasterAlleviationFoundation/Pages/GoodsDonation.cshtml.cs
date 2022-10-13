using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DisasterAlleviationFoundation.Pages
{
   
    public class GoodsDonationModel : PageModel
    {
        public string errorMessage = "";
        public string successMessage = "";
        public void OnGet()
        {
        }
        public void OnPost()
        {

            DateTime DateGD = Convert.ToDateTime(Request.Form["date"]);
            int Items = Convert.ToInt32(Request.Form["items"]);
            string Category = Request.Form["category"];
            string Description = Request.Form["description"];
            string DonorGD = Request.Form["Name"];
            string Other = Request.Form["Other"];
            string ActiveDisaster = Request.Form["activeDisaster"];

            DateTime date = DateGD.Date;
            try
            {
                string connectionString = "Server=tcp:diasterassignment.database.windows.net,1433;Initial Catalog=Disaster;Persist Security Info=False;User ID=st10118146;Password=Plugfilm60;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

                SqlConnection connection = new SqlConnection(connectionString);

                string sql = "INSERT INTO GoodsDonations (DateGD,Items,Category,Description,DonorGD,ActiveDisaster) VALUES(@date,@items,@category,@description,@Name,@activeDisaster)";

                SqlCommand cmd = new SqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@items", Items);
                //cmd.Parameters.AddWithValue("@category", Category);
                cmd.Parameters.AddWithValue("@description", Description);
                cmd.Parameters.AddWithValue("@Name", DonorGD);
                cmd.Parameters.AddWithValue("@activeDisaster", ActiveDisaster);

                if (Category != null)
                {
                    cmd.Parameters.AddWithValue("@category", Category);
                }
                else if (Category == "Other")
                {
                    cmd.Parameters.AddWithValue("@category", Other);
                }
                connection.Open();

                cmd.ExecuteNonQuery();

                connection.Close();
              
                successMessage = "Yaaay you donated thank you";
                Response.Redirect("/ViewGoodDonation");
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }
    }
}
