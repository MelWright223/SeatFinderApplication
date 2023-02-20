using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using MySqlConnector;

namespace FindYourSeatsApplication.Controller
{
    class databaseConn
    {
        private MySqlConnector.MySqlConnection conn;
        public bool DatabaseConn()
        {
            string myConnectionString;
            myConnectionString = "server=127.0.0.1;port=3306;user=root;password=RedPanda32!;database=traindata";
            try
            {
                conn = new  MySqlConnector.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                Console.WriteLine(conn.State);
                conn.Open();
                
                return true;
                
            }
            catch (MySqlConnector.MySqlException ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

    }
}
