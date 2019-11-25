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
using Org.BouncyCastle.Utilities.Collections;
using ProjektStacjaWPF.Classes;

namespace ProjektStacjaWPF.Views
{
    /// <summary>
    /// Logika interakcji dla klasy UserShowInformationView.xaml
    /// </summary>
    public partial class UserShowInformationView : UserControl
    {
        private static User _user;
        public UserShowInformationView()
        {
            InitializeComponent();
            SetUserData();           
        }

        public void SetUserData()
        {
            _user = User.GetCurrentUser();
            Username.Text = _user.Username;
            Password.Text = _user.Password;
            Mail.Text = _user.Mail;
            Name.Text = _user.Name;
            Surname.Text = _user.Surname;
            Age.Text = _user.Age.ToString();
            City.Text = _user.City;
            Street.Text = _user.Street;
            Code.Text = _user.Code;
            Pesel.Text = _user.Pesel;
            Nip.Text = _user.Nip;
            Regon.Text = _user.Regon;
        }
    }
}
