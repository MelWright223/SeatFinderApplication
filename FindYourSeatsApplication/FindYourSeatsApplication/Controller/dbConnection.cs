using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using MySqlConnector;
using MySql.Data;
using System.Threading.Tasks;
using FindYourSeatsApplication.Models;


namespace FindYourSeatsApplication.Controller
{
    class dbConnection
    {
        public List<StationData> connectDb()
        {
            List<StationData> result = new List<StationData>();
            string connectionString;
            MySql.Data.MySqlClient.MySqlConnection cnn = new MySql.Data.MySqlClient.MySqlConnection();
            connectionString = "Server=127.0.0.1;Port=3306;Database=TrainModels;Username=root;Password=RedPanda32!;";
            cnn.ConnectionString = connectionString;
            cnn.Open();


            // open a connection asynchronously


            try
            {
                cnn.Open();
                Console.WriteLine("Yes");
               
               
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can not open connection ! ");
            }
            //var connection = new MySqlConnector.MySqlConnection(builder.ConnectionString);
            //connection.Ope
            //Console.WriteLine("conected");
            string insertQuery = "SELECT * FROM train_stations WHERE StationId = 1";
            MySql.Data.MySqlClient.MySqlCommand myCommand = new MySql.Data.MySqlClient.MySqlCommand(insertQuery, cnn);


            myCommand.ExecuteNonQuery();
            //List<StationData> reader = myCommand.ExecuteReader();
            cnn.Close();

            //while (true)
            //{
            //    result.Add(new StationData
            //    {
            //        StationID = reader.GetInt32("StationId"), // the parameter is the name of the column
            //        StationName = reader.GetString("StationName"),
            //        MaximumCarriageSpace = reader.GetInt32("MaximumCarriageSpace"),
            //        StationLat = reader.GetString("StationLat"),
            //        StationLong = reader.GetString("StationLong")

            //    });

            //}
            //Console.WriteLine(result);
            return result;



        }
    }
}
