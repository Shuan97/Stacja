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
    /// Logika interakcji dla klasy UserEditDataView.xaml
    /// </summary>
    public partial class UserEditDataView : UserControl
    {
        private User _user;
        public UserEditDataView()
        {
            InitializeComponent();
            _user = User.GetCurrentUser();
            UpdateData();
        }

        private void UserEditData(object sender, RoutedEventArgs e)
        {
            int id = _user.Id;
            String username = Username.Text;
            String password = Password.Text;
            String mail = Mail.Text;
            String name = Name.Text;
            String surname = Surname.Text;
            int age = Convert.ToInt32(Age.Text);
            String city = City.Text;
            String street = Street.Text;
            String code = Code.Text;
            String pesel = Pesel.Text;
            String nip = Nip.Text;
            String regon = Regon.Text;
            String points = User.GetCurrentUser().Points;
            int role = User.GetCurrentUser().Role;

            User user = new User(id, username, password, mail, name, surname, age, role, city, street, code, pesel, nip, regon, points);
            User.Update(user);
            User.SetCurrentUser(user);
            _user = User.GetCurrentUser();
            UpdateData();
        }

        private void UpdateData()
        {
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
