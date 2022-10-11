using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DisasterAlleviationFoundation.Pages
{
    public class ViewDisastersModel : PageModel
    {
        public string errorMessage = "";
        public List<Disaster> listDisaster = new List<Disaster>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Server=tcp:diasterassignment.database.windows.net,1433;Initial Catalog=Disaster;Persist Security Info=False;User ID=st10118146;Password=Plugfilm60;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM DISASTER";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                            while (reader.Read())
                            {
                                Disaster disaster = new Disaster();
                                disaster.StartDate = "" + reader.GetDateTime(0);
                                disaster.EndDate = reader.GetDateTime(1);
                                disaster.Location = reader.GetString(2);
                                disaster.descripDisas = reader.GetString(3);
                                disaster.AidType = reader.GetString(4);

                                listDisaster.Add(disaster);
                            }
                    }

                }

            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

        }
        public class Disaster
        {
            public String StartDate;
            public DateTime EndDate;
            public String Location;
            public String descripDisas;
            public String AidType;
        }
    }
}
