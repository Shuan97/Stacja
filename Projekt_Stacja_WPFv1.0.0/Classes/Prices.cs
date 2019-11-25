using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProjektStacjaWPF.Classes
{
    class Prices
    {
        private static readonly MySqlConnection _dbConn = DBConnectionHandler.dbConn;

        public int Id { get; private set; }
        public String PricePB95 { get; private set; }
        public String PricePB98 { get; private set; }
        public String PriceON { get; private set; }
        public String PriceLPG { get; private set; }
        public String PriceDate { get; private set; }


        public Prices(int id, string pricePb95, string pricePb98, string priceOn, string PriceLpg, string pirceDate)
        {
            Id = id;
            PricePB95 = pricePb95;
            PricePB98 = pricePb98;
            PriceON = priceOn;
            PriceLPG = PriceLpg;
            PriceDate = pirceDate;
        }

        public static List<Prices> GetPrices()
        {
            List<Prices> prices = new List<Prices>();

            String query = "SELECT * FROM price";

            MySqlCommand cmd = new MySqlCommand(query, _dbConn);

            _dbConn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = (int)reader["PRI_ID"];
                String pb95 = reader["PRI_PB95"].ToString();
                String pb98 = reader["PRI_PB98"].ToString();
                String on = reader["PRI_ON"].ToString();
                String lpg = reader["PRI_LPG"].ToString();
                String date = reader["PRI_DATE"].ToString();

                Prices price = new Prices(id, pb95, pb98, on, lpg, date);
                prices.Add(price);
            }
            reader.Close();
            _dbConn.Close();
            return prices;
        }

        public static Prices GetLastPrice()
        {
            Prices price = null;
            String query = "SELECT * FROM price ORDER BY PRI_ID DESC LIMIT 1";

            MySqlCommand cmd = new MySqlCommand(query, _dbConn);

            _dbConn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = (int)reader["PRI_ID"];
                String pb95 = reader["PRI_PB95"].ToString();
                String pb98 = reader["PRI_PB98"].ToString();
                String on = reader["PRI_ON"].ToString();
                String lpg = reader["PRI_LPG"].ToString();
                String date = reader["PRI_DATE"].ToString();

                price = new Prices(id, pb95, pb98, on, lpg, date);
            }
            reader.Close();
            _dbConn.Close();
            return price;        
        }

        public static void AddNewPrice(Prices price)
        {
            String query = $"INSERT INTO price(PRI_PB95, PRI_PB98, PRI_ON, PRI_LPG, PRI_DATE) VALUES ('{price.PricePB95}','{price.PricePB98}','{price.PriceON}','{price.PriceLPG}','{price.PriceDate}')";

            MySqlCommand cmd = new MySqlCommand(query, _dbConn);

            _dbConn.Open();
            cmd.ExecuteNonQuery();
            int id = (int)cmd.LastInsertedId;
            //User u = new User(id, u, p, m, n, s, a, r);
            _dbConn.Close();
        }

    }
}
