using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows;
using MySql.Data.MySqlClient;

namespace ProjektStacjaWPF.Classes
{
    [Flags]
    enum UserRole : int
    {
        User = 1,
        Employee = 2,
        Admin = 4
    }

    public class User
    {
        //database stuff
        private const String SERVER = "localhost";
        private const String DATABASE = "stacja";
        private const String UID = "root";
        private const String PASSWORD = "daromi10";
        //private static MySqlConnection dbConn;
        private static MySqlConnection _dbConn = DBConnectionHandler.dbConn;
        private static User currentUser = null;

        //public UserRole Role { get; set; }
        //User class stuff
        public int Id { get; private set; }
        public String Username { get; private set; }
        public String Password { get; private set; }
        public String Mail { get; private set; }
        public String Name { get; private set; }
        public String Surname { get; private set; }
        public int Age { get; private set; }
        public String City { get; private set; }
        public String Street { get; private set; }
        public String Code { get; private set; }
        public String Pesel { get; private set; }
        public String Nip { get; private set; }
        public String Regon { get; private set; }
        public String Points{ get; private set; }

        public int Role { get; private set; }

        public User(int id, String u, String p, String m, String n, String s, int a, int r, String city, String street, String code, String pesel, String nip, String regon, String points)
        {
            Id = id;
            Username = u;
            Password = p;
            Mail = m;
            Name = n;
            Surname = s;
            Age = a;
            City = city;
            Street = street;
            Code = code;
            Pesel = pesel;
            Nip = nip;
            Regon = regon;
            Role = r;
            Points = points;
        }

        //public static void InitializeDB()
        //{
        //    MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
        //    {
        //        Server = SERVER,
        //        UserID = UID,
        //        Password = PASSWORD,
        //        Database = DATABASE
        //    };

        //    String connString = builder.ToString();
        //    builder = null;
        //    dbConn = new MySqlConnection(connString);

        //    Application.Current.Exit += (sender, args) =>
        //    {
        //        if (dbConn != null)
        //        {
        //            dbConn.Dispose();
        //            dbConn = null;
        //        }
        //    };
        //}

        public static List<User> GetUsers()
        {
            List<User> users = new List<User>();

            String query = "SELECT * FROM user";

            MySqlCommand cmd = new MySqlCommand(query, _dbConn);

            _dbConn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = (int)reader["USR_ID"];
                String username = reader["USR_LOGIN"].ToString();
                String password = reader["USR_PASSWORD"].ToString();
                String mail = reader["USR_MAIL"].ToString();
                String name = reader["USR_NAME"].ToString();
                String surname = reader["USR_SURNAME"].ToString();
                int age = (int)reader["USR_AGE"];
                String city = reader["USR_CITY"].ToString();
                String street = reader["USR_STREET"].ToString();
                String code = reader["USR_CODE"].ToString();
                String pesel = reader["USR_PESEL"].ToString();
                String nip = reader["USR_NIP"].ToString();
                String regon = reader["USR_REGON"].ToString();
                String points = reader["USR_LEVEL"].ToString();
                int role = (int) reader["USR_ROLE"];

                User u = new User(id, username, password, mail, name, surname, age, role, city, street, code, pesel, nip, regon, points);

                users.Add(u);
            }
            reader.Close();
            _dbConn.Close();
            return users;
        }

        public static User GetCurrentUser()
        {
            return currentUser;
        }

        public static void SetCurrentUser(User user)
        {
            currentUser = user;
        }
        //string u, string p, string m, string n, string s, int a, int r
        public static void Insert(User user)
        {
            String query = $"INSERT INTO user(USR_LOGIN, USR_PASSWORD, USR_MAIL, USR_NAME, USR_SURNAME, USR_AGE, USR_ROLE, USR_CITY, USR_STREET, USR_CODE, USR_PESEL, USR_NIP, USR_REGON, USR_LEVEL) VALUES ('{user.Username}','{user.Password}','{user.Mail}','{user.Name}','{user.Surname}','{user.Age}','{user.Role}','{user.City}','{user.Street}','{user.Code}','{user.Pesel}','{user.Nip}','{user.Regon}','{user.Points}')";

            MySqlCommand cmd = new MySqlCommand(query, _dbConn);

            _dbConn.Open();
            cmd.ExecuteNonQuery();
            int id = (int)cmd.LastInsertedId;
            //User u = new User(id, u, p, m, n, s, a, r);
            _dbConn.Close();
        }

        public static void Update(User user)
        {
            String query = $"UPDATE user SET USR_LOGIN='{user.Username}', USR_PASSWORD='{user.Password}', USR_MAIL='{user.Mail}', USR_NAME='{user.Name}', USR_SURNAME='{user.Surname}', USR_AGE='{user.Age}', USR_ROLE='{user.Role}', USR_CITY='{user.City}', USR_STREET='{user.Street}', USR_CODE='{user.Code}', USR_PESEL='{user.Pesel}', USR_NIP='{user.Nip}', USR_REGON='{user.Regon}' WHERE USR_ID={user.Id}";

            MySqlCommand cmd = new MySqlCommand(query, _dbConn);

            _dbConn.Open();
            cmd.ExecuteNonQuery();
            _dbConn.Close();
        }

        public void Delete()
        {
            String query = $"DELETE FROM user WHERE USR_ID={Id}";

            MySqlCommand cmd = new MySqlCommand(query, _dbConn);

            _dbConn.Open();
            cmd.ExecuteNonQuery();
            _dbConn.Close();
        }

        public static User LogIn(String u, String p)
        {
            String query = $"SELECT COUNT(*) FROM stacja.user WHERE USR_LOGIN='{u}' AND USR_PASSWORD='{p}'";            
            MySqlDataAdapter sda = new MySqlDataAdapter(query, _dbConn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {                
                return GetUser(u,p);
            }
            else
            {
                MessageBox.Show("wrong username");
                return null;
            }
        }

        private static User GetUser(string u, string p)
        {
            User user = null;
            String query = $"SELECT * FROM stacja.user WHERE USR_LOGIN='{u}' AND USR_PASSWORD='{p}'";

            MySqlCommand cmd = new MySqlCommand(query, _dbConn);

            _dbConn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = (int)reader["USR_ID"];
                String username = reader["USR_LOGIN"].ToString();
                String password = reader["USR_PASSWORD"].ToString();
                String mail = reader["USR_MAIL"].ToString();
                String name = reader["USR_NAME"].ToString();
                String surname = reader["USR_SURNAME"].ToString();
                int age = (int)reader["USR_AGE"];
                String city = reader["USR_CITY"].ToString();
                String street = reader["USR_STREET"].ToString();
                String code = reader["USR_CODE"].ToString();
                String pesel = reader["USR_PESEL"].ToString();
                String nip = reader["USR_NIP"].ToString();
                String regon = reader["USR_REGON"].ToString();
                String points = reader["USR_LEVEL"].ToString();
                int role = (int)reader["USR_ROLE"];
                user = new User(id, username, password, mail, name, surname, age, role, city, street, code, pesel, nip, regon, points);
                SetCurrentUser(user);
            }
            reader.Close();
            _dbConn.Close();
            return user;
        }

        public static User GetUser(int id)
        {
            User user = null;
            String query = $"SELECT * FROM stacja.user WHERE USR_ID='{id}'";

            MySqlCommand cmd = new MySqlCommand(query, _dbConn);

            _dbConn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                //int id = (int)reader["USR_ID"];
                String username = reader["USR_LOGIN"].ToString();
                String password = reader["USR_PASSWORD"].ToString();
                String mail = reader["USR_MAIL"].ToString();
                String name = reader["USR_NAME"].ToString();
                String surname = reader["USR_SURNAME"].ToString();
                int age = (int)reader["USR_AGE"];
                String city = reader["USR_CITY"].ToString();
                String street = reader["USR_STREET"].ToString();
                String code = reader["USR_CODE"].ToString();
                String pesel = reader["USR_PESEL"].ToString();
                String nip = reader["USR_NIP"].ToString();
                String regon = reader["USR_REGON"].ToString();
                String points = reader["USR_LEVEL"].ToString();
                int role = (int)reader["USR_ROLE"];
                user = new User(id, username, password, mail, name, surname, age, role, city, street, code, pesel, nip, regon, points);
            }
            reader.Close();
            _dbConn.Close();
            return user;
        }

        public static String GetPoints(int id)
        {
            String points = null;
            String query = $"SELECT * FROM stacja.user WHERE USR_ID='{id}'";

            MySqlCommand cmd = new MySqlCommand(query, _dbConn);

            _dbConn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                points = reader["USR_LEVEL"].ToString();
            }
            reader.Close();
            _dbConn.Close();
            return points;
        }

        public static User GetUserByNumber(string number)
        {
            User user = null;
            String query = null;
            if (number.Length == 11)
            {
                //PESEL
                query = $"SELECT * FROM stacja.user WHERE USR_PESEL='{number}'";
                //MessageBox.Show("1");
            }
            else if (number.Length == 10)
            {
                //NIP
                query = $"SELECT * FROM stacja.user WHERE USR_NIP='{number}'";
                //MessageBox.Show("2");
            }
            else if (number.Length == 9)
            {
                //REGON
                query = $"SELECT * FROM stacja.user WHERE USR_REGON='{number}'";
                //MessageBox.Show("3");
            }
            else
            {
                MessageBox.Show("Niepoprawna długość!");
                return null;
            }


            MySqlCommand cmd = new MySqlCommand(query, _dbConn);

            _dbConn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = (int)reader["USR_ID"];
                String username = reader["USR_LOGIN"].ToString();
                String password = reader["USR_PASSWORD"].ToString();
                String mail = reader["USR_MAIL"].ToString();
                String name = reader["USR_NAME"].ToString();
                String surname = reader["USR_SURNAME"].ToString();
                int age = (int)reader["USR_AGE"];
                String city = reader["USR_CITY"].ToString();
                String street = reader["USR_STREET"].ToString();
                String code = reader["USR_CODE"].ToString();
                String pesel = reader["USR_PESEL"].ToString();
                String nip = reader["USR_NIP"].ToString();
                String regon = reader["USR_REGON"].ToString();
                String points = reader["USR_LEVEL"].ToString();
                int role = (int)reader["USR_ROLE"];
                user = new User(id, username, password, mail, name, surname, age, role, city, street, code, pesel, nip, regon, points);
            }

            if (user == null)
            {
                MessageBox.Show("Niepoprawny numer!");
                reader.Close();
                _dbConn.Close();
                return null;
            }

            reader.Close();
            _dbConn.Close();
            return user;
        }
    }
}
