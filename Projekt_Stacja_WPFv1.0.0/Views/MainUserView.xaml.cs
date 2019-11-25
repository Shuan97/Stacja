using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ProjektStacjaWPF.Classes;

namespace ProjektStacjaWPF.Views
{
    /// <summary>
    /// Logika interakcji dla klasy MainUserView.xaml
    /// </summary>
    public partial class MainUserView : Window
    {


        public MainUserView()
        {           
            InitializeComponent();


            var currUser = User.GetCurrentUser();
            switch (currUser.Role)
            {
                case 1: //User
                    ShowUsers.Visibility = Visibility.Collapsed;
                    EditUsers.Visibility = Visibility.Collapsed;
                    Camera.Visibility = Visibility.Collapsed;
                    Invoice.Visibility = Visibility.Collapsed;
                    NewPrice.Visibility = Visibility.Collapsed;
                    break;
                case 2: //Employee
                    //ShowUsers.Visibility = Visibility.Collapsed;
                    EditUsers.Visibility = Visibility.Collapsed;
                    Camera.Visibility = Visibility.Collapsed;
                    NewPrice.Visibility = Visibility.Collapsed;
                    break;
                case 3: //Manager
                    //ShowUsers.Visibility = Visibility.Collapsed;
                    EditUsers.Visibility = Visibility.Collapsed;
                    NewPrice.Visibility = Visibility.Collapsed;
                    break;
                case 4: //Admin
                    break;
                default:
                    MessageBox.Show("Coś poszło nie tak!");
                    break;
            }
            MessageBox.Show("Zalogowano "+currUser.Name+"!");
            DataContext = new StartPageView();
        }

        /// <summary>
        /// Pokaż stronę startową
        /// </summary>
        private void StartPage(object sender, RoutedEventArgs e)
        {            
            DataContext =  new StartPageView();
        }

        private void ButtonClick2(object sender, RoutedEventArgs e)
        {
            this.Menu2.Visibility = this.Menu2.Visibility == Visibility.Visible
                ? Visibility.Collapsed
                : Visibility.Visible;
        }

        /// <summary>
        /// Wyloguj użytkownika
        /// </summary>
        private void BtnLogout(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            User.SetCurrentUser(null);
            Application.Current.Windows[0]?.Close();
        }

        /// <summary>
        /// Pokaż dane użytkownika
        /// </summary>
        private void BtnShowUser(object sender, RoutedEventArgs e)
        {
            DataContext = new UserShowInformationView();
        }

        /// <summary>
        /// Edytuj dane użytkownika
        /// </summary>
        private void BtnEditUser(object sender, RoutedEventArgs e)
        {
            DataContext = new UserEditDataView();
        }

        private void BtnPrices(object sender, RoutedEventArgs e)
        {
            DataContext = new UserPricesView();
        }


        // ---------- Employee ----------


        /// <summary>
        /// Pokaż dane użytkowników
        /// </summary>
        private void BtnShowUsers(object sender, RoutedEventArgs e)
        {
            DataContext = new EmployeeShowUsersView();
        }

        /// <summary>
        /// Edytuj dane użytkowników
        /// </summary>
        private void BtnEditUsers(object sender, RoutedEventArgs e)
        {
            DataContext = new EmployeeEditUsersView();
        }

        //private void ButtonCameraMenu(object sender, RoutedEventArgs e)
        //{
        //    this.MenuCamera.Visibility = this.MenuCamera.Visibility == Visibility.Visible
        //        ? Visibility.Collapsed
        //        : Visibility.Visible;
        //}

        private void ButtonShowCamera(object sender, RoutedEventArgs e)
        {
            DataContext = new ManagerShowCameraView();
        }

        private void ButtonClickPrice(object sender, RoutedEventArgs e)
        {
            this.MenuCennik.Visibility = this.MenuCennik.Visibility == Visibility.Visible
                ? Visibility.Collapsed
                : Visibility.Visible;
        }

        private void BtnShowPrices(object sender, RoutedEventArgs e)
        {
            DataContext = new UserShowPricesView();
        }

        private void BtnAddPrice(object sender, RoutedEventArgs e)
        {
            DataContext = new AdminAddPriceView();
        }

        //private void ButtonClick3(object sender, RoutedEventArgs e)
        //{
        //    this.Menu3.Visibility = this.Menu3.Visibility == Visibility.Visible
        //        ? Visibility.Collapsed
        //        : Visibility.Visible;
        //}

        private void BtnMyPoints(object sender, RoutedEventArgs e)
        {
            DataContext = new UserMyPointsView();
        }

        private void BtnInvoice(object sender, RoutedEventArgs e)
        {
            DataContext = new EmployeeInvoiceView();
        }
    }
}
