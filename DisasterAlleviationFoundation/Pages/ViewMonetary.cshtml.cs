using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DisasterAlleviationFoundation.Pages
{
    public class ViewMonetaryModel : PageModel
    {
        public List<MonetaryDonation> listMonetaryDonation = new List<MonetaryDonation>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Server=tcp:diasterassignment.database.windows.net,1433;Initial Catalog=Disaster;Persist Security Info=False;User ID=st10118146;Password=Plugfilm60;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM MonetaryDonations";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                            while (reader.Read())
                            {
                                MonetaryDonation monetaryDonation = new MonetaryDonation();
                                monetaryDonation.dateMD = "" + reader.GetDateTime(0);
                                monetaryDonation.amountMD = reader.GetInt32(1);
                                monetaryDonation.donorMD = reader.GetString(2);

                                listMonetaryDonation.Add(monetaryDonation);
                            }
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }


        public class MonetaryDonation
        {
            public String dateMD;
            public int amountMD;
            public String donorMD;
        }
    }
}
 