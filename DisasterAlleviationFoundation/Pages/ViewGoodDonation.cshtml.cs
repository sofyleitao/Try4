using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DisasterAlleviationFoundation.Pages
{
    public class ViewGoodDonationModel : PageModel
    {
        public string errorMessage = "";
        public List<GoodDonation> listGoodDonation = new List<GoodDonation>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Server=tcp:diasterassignment.database.windows.net,1433;Initial Catalog=Disaster;Persist Security Info=False;User ID=st10118146;Password=Plugfilm60;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM GoodsDonations";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                            while (reader.Read())
                            {
                                GoodDonation goodDonation = new GoodDonation();
                                goodDonation.dateGD = "" + reader.GetDateTime(0);
                                goodDonation.items = reader.GetInt32(1);
                                goodDonation.category = reader.GetString(2);
                                goodDonation.description = reader.GetString(3);
                                goodDonation.Name = reader.GetString(4);
                                goodDonation.activeDisaster = reader.GetString(5);

                                listGoodDonation.Add(goodDonation);
                            }
                    }

                }

            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }


        public class GoodDonation
        {
            public String dateGD;
            public int items;
            public String category;
            public String description;
            public String Name;
            public String activeDisaster;
        }
    }
    }

