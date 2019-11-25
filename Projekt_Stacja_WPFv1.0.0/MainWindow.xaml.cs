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
using ProjektStacjaWPF.Views;

namespace ProjektStacjaWPF
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly LoginView _loginView;
        private readonly RegisterView _registerView;
        private readonly InformationView _informationView;
        public MainWindow()
        {
            InitializeComponent();
            DBConnectionHandler.InitializeDB();
            _loginView = new LoginView();
            _registerView = new RegisterView();
            _informationView = new InformationView();           
            DataContext = _loginView;
        }

        private void BtnLog_OnClick(object sender, RoutedEventArgs e)
        {
            DataContext = _loginView;
        }

        private void BtnSign_OnClick(object sender, RoutedEventArgs e)
        {
            DataContext = _registerView;
        }
        
        private void BtnInfo_OnClick(object sender, RoutedEventArgs e)
        {
            DataContext = _informationView;
        }

        private void BtnExit_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
