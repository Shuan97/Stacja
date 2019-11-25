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
    /// Logika interakcji dla klasy UserShowPricesView.xaml
    /// </summary>
    public partial class UserShowPricesView : UserControl
    {
        public UserShowPricesView()
        {
            InitializeComponent();
            List<Prices> users = Prices.GetPrices();
            UserList.Items.Clear();
            UserList.ItemsSource = users;
        }
    }
}
