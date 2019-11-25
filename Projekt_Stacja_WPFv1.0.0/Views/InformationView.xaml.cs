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
using MySql.Data.MySqlClient;
using ProjektStacjaWPF.Classes;

namespace ProjektStacjaWPF.Views
{
    /// <summary>
    /// Logika interakcji dla klasy InformationView.xaml
    /// </summary>
    public partial class InformationView : UserControl
    {
        public InformationView()
        {
            InitializeComponent();
            LoadAll();
        }

        private void LoadAll()
        {
            Prices price = Prices.GetLastPrice();

            Price95.Content = price.PricePB95;
            Price98.Content = price.PricePB98;
            PriceON.Content = price.PriceON;
            PriceLPG.Content = price.PriceLPG;
        }
    }
}
