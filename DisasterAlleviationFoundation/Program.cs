using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using System.Data.SqlTypes;

namespace DisasterAlleviationFoundation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* try
             {
                 string connectionString = "Server=tcp:diasterassignment.database.windows.net,1433;Initial Catalog=Disaster;Persist Security Info=False;User ID=st10118146;Password=Plugfilm60;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                 using (SqlConnection connection = new SqlConnection(connectionString))
                 {
                     connection.Open();
                     Console.WriteLine("---------------------------------------------------");
                     String sql = "SELECT * FROM Disaster;";
                     using (SqlCommand command = new SqlCommand(sql, connection))
                     {
                         using (SqlDataReader reader = command.ExecuteReader())
                         {
                             while (reader.Read())
                             {
                                 Console.WriteLine("{0} - {1}",
                                         reader.GetInt32(0), reader.GetString(1));
                             }
                         }
                     }
                 }

             }
             catch (SqlException e)
             {
                 Console.WriteLine(e.ToString());
             }
             Console.ReadLine();*/
            CreateHostBuilder(args).Build().Run();
        }

            public static IHostBuilder CreateHostBuilder(string[] args) =>
                Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>();
                    });
        }
    }

