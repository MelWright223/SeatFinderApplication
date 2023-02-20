using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FindYourSeatsApplication.Models;

namespace FindYourSeatsApplication.Controller
{
    class dbConnection
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public dbConnection()
        {
            initialize();
        }


        public void initialize()
        {

            server = "127.0.0.1";
            database = "traindata";
            uid = "root";
            password = "RedPanda32!";
            string connectionString;
            connectionString = "server=" + server + ";" + "database=" +
            database + ";" + "user=" + uid + ";" + "password=" + password + ";";

            connection = new MySqlConnection(connectionString);
            Console.WriteLine(connection.State);
            //connection.OpenAsync();
                     
           // CloseConnection();
            OpenConnection();
        }
        private bool OpenConnection()
        {
            connection.Open();
            Console.WriteLine("Connected");
            return true;

        }

        //Close connection
        private bool CloseConnection()
        {
            connection.Close();
            Console.WriteLine("Closed force");
            return true;
        }
        //getConnection = "Server=127.0.0.1;Port=3306;Database=TrainModels;Uid=root;Pwd=RedPanda32!;";
        //  MySql.Data.MySqlClient.MySqlConnection cnn = new MySql.Data.MySqlClient.MySqlConnection(getConnection);

    }


    //        string insertQuery = "SELECT * FROM train_stations WHERE StationId = 1";
      //      MySql.Data.MySqlClient.MySqlCommand myCommand = new MySql.Data.MySqlClient.MySqlCommand(insertQuery, cnn);


     //       myCommand.ExecuteNonQuery();
            //List<StationData> reader = myCommand.ExecuteReader();
           // cnn.Close();

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
            //return result;

}

