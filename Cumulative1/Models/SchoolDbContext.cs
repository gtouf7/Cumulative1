using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


// My SQL data isntalled
using MySql.Data.MySqlClient;

namespace Cumulative1.Models
{
    public class SchoolDbContext
    {
        //local MAMP properties were identified
        private static string User { get { return "root";  } }
        private static string Password { get { return "root";  } }
        private static string Database { get { return "school";  } }
        private static string Server { get { return "localhost"; } }
        private static string Port { get { return "3306"; } }

        protected static string ConnectionString
        {
            get
            {
                return "server = " + Server
                    + "; user =" + User
                    + "; database = " + Database
                    + "; port =" + Port
                    + "; password =" + Password
                    + "; convert zero datetime = true";
            }
        }
        public MySqlConnection AccessDatabase()
        {
            return new MySqlConnection(ConnectionString);
        }
        //connection to MySQL database
    }
}