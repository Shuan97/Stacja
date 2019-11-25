using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace ProjektStacjaWPF.Classes
{
    class DBConnectionHandler
    {
        private const string SERVER = "localhost";
        private const string DATABASE = "stacja";
        private const string UID = "root";
        private const string PASSWORD = "daromi10";
        public static MySqlConnection dbConn { get; private set; }

        public static void InitializeDB()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
            {
                Server = SERVER,
                UserID = UID,
                Password = PASSWORD,
                Database = DATABASE
            };

            String connString = builder.ToString();
            builder = null;
            dbConn = new MySqlConnection(connString);

            Application.Current.Exit += (sender, args) =>
            {
                if (dbConn == null) return;
                dbConn.Dispose();
                dbConn = null;
            };
        }
    }
}
