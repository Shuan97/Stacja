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
    /// Logika interakcji dla klasy LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();

            Username.InputText.Text = "username";
            Password.InputText.Password= "password";
        }

        private void BtnLogIn_OnClick(object sender, RoutedEventArgs e)
        {
            //int role = User.LogIn(Username.GetText(), Password.GetText());
            //User.LogIn("test", "test");
            User.LogIn(Username.GetText(), Password.GetText());

            if (User.GetCurrentUser() != null)
            {
                MainUserView userView = new MainUserView();
                userView.Show();
                Application.Current.Windows[0]?.Close();
            }                          
        }
    }
}
