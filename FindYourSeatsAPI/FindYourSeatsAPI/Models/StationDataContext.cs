using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
 

namespace FindYourSeatsAPI.Models
{
    public class StationDataContext
    {
        public string ConnectionString { get; set; }

        public StationDataContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
       

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        
        public List<StationData> getAllStations()
        {
            List<StationData> station = new List<StationData>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("Select * from traindata.train_stations",conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        station.Add(new StationData()
                        {
                            StationID = Convert.ToInt32(reader["StationId"]),
                            StationName = reader["StationName"].ToString(),
                            MaximumCarriageSpace = Convert.ToInt32(reader["MaximumCarriageSpace"]),
                            StationLat = Convert.ToDouble(reader["StationLat"]),
                            StationLong = Convert.ToDouble(reader["StationLong"])
                        });
                        //Console.WriteLine(station);
                    }
                    Console.WriteLine(station.ToString());
                    conn.Close();
                }
              
                return station;

            }
        }
    }
}
