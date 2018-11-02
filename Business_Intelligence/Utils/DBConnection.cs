using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Business_Intelligence.Utils
{
    public class DBConnection
    {

        public static SqlConnection conn;
        public static SqlCommand cmd;
        public static bool isConnected = false;
        public static SqlDataReader reader;

        public static void connect()
        {
            //       conn = new SqlConnection("Data Source = DESKTOP-O3G0UFM\\SQLEXPRESS; Initial Catalog = BI; Connect Timeout = 30; Integrated Security=SSPI;");
            conn = new SqlConnection("Data Source = HIGOR-PC\\SQLEXPRESS; Initial Catalog = BI; Connect Timeout = 30; Integrated Security=SSPI;");
            conn.Open();
            cmd = new SqlCommand();

            cmd.Connection = conn;
            isConnected = true;
        }

        public static SqlDataReader getResults(string query)
        {
            cmd.CommandText = query;
            reader = cmd.ExecuteReader();
            return reader;

        }

        public static void closeConnections()
        {
            conn.Close();
            reader.Close();
            isConnected = false;
        }


    }
}