using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjektStacjaWPF.Classes
{
    public class Product
    {
        public String Item { get; private set; }
        public String Amount { get; private set; }
        public String Price { get; private set; }
        public String Sum { get; private set; }


        public Product(string i, string a, string p, string s)
        {
            Item = i;
            Amount = a;
            Price = p;
            Sum = s;
        }

        public static Product RandomProduct(int i)
        {
            string item = null;
            int amount = 0;
            double price = 0;
            double sum = 0;
            Random rnd = new Random();
            Random rndamt = new Random();
            Prices prices = Prices.GetLastPrice();
            int randItem = rnd.Next(1, 5 + i);
            switch (randItem)
            {
                case 1:
                    item = "PB95";
                    amount = rndamt.Next(10, 50);
                    price = Convert.ToDouble(prices.PricePB95);
                    sum = amount * price;
                    break;
                case 2:
                    item = "PB98";
                    amount = rndamt.Next(10, 50);
                    price = Convert.ToDouble(prices.PricePB98);
                    sum = amount * price;
                    break;
                case 3:
                    item = "ON";
                    amount = rndamt.Next(10, 50);
                    price = Convert.ToDouble(prices.PriceON);
                    sum = amount * price;
                    break;
                case 4:
                    item = "LPG";
                    amount = rndamt.Next(30, 70);
                    price = Convert.ToDouble(prices.PriceLPG);
                    sum = amount * price;
                    break;
                case 5:
                    item = "Myjnia standardowa";
                    amount = rndamt.Next(5,10);
                    price = 19.99;
                    sum = amount * price;
                    break;
                case 6:
                    item = "Myjnia woskowanie";
                    amount = rndamt.Next(5,10);
                    price = 34.99;
                    sum = amount * price;
                    break;
                default:
                    MessageBox.Show("Nieznany błąd");
                    break;
            }

            Product product = new Product(item, amount.ToString(), price.ToString(), sum.ToString());

            return product;
        }
    }
}
