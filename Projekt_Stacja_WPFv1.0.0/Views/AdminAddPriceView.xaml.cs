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
    /// Logika interakcji dla klasy AdminAddPriceView.xaml
    /// </summary>
    public partial class AdminAddPriceView : UserControl
    {
        public AdminAddPriceView()
        {
            InitializeComponent();
            Prices price = Prices.GetLastPrice();
            PB95.Text = price.PricePB95;
            PB98.Text = price.PricePB98;
            ON.Text = price.PriceON;
            LPG.Text = price.PriceLPG;
            Date.Text = DateTime.Today.ToString("yyyy-MM-dd");
        }

        private void BtnAddPrice(object sender, RoutedEventArgs e)
        {
            Prices price = new Prices(0,PB95.Text, PB98.Text, ON.Text, LPG.Text, Date.Text);
            Prices.AddNewPrice(price);
        }
    }
}
