using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProjektStacjaWPF.Classes;

namespace ProjektStacjaWPF.Views
{
    /// <summary>
    /// Logika interakcji dla klasy UserPricesView.xaml
    /// </summary>
    public partial class UserPricesView : UserControl
    {
        public UserPricesView()
        {
            InitializeComponent();
            SetPrices();
        }

        private void SetPrices()
        {
            //List<Prices> prices = Prices.GetPrices();

            //Price95.Content = prices[0].PricePB95;
            //Price98.Content = prices[0].PricePB98;
            //PriceON.Content = prices[0].PriceON;
            //PriceLPG.Content = prices[0].PriceLPG;

            Prices price = Prices.GetLastPrice();

            Price95.Content = price.PricePB95;
            Price98.Content = price.PricePB98;
            PriceON.Content = price.PriceON;
            PriceLPG.Content = price.PriceLPG;
        }
    }
}
