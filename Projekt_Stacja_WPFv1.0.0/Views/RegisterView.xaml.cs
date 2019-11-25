using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Logika interakcji dla klasy RegisterView.xaml
    /// </summary>
    public partial class RegisterView : UserControl
    {
        public RegisterView()
        {
            InitializeComponent();
            Login.InputText.Text = "login";
            Password.InputText.Text = "password";
            Email.InputText.Text = "e-mail";
            Name.InputText.Text = "name";
            Surname.InputText.Text = "surname";
            Age.InputText.Text = "age";
            City.InputText.Text = "city";
            Street.InputText.Text = "street";
            Code.InputText.Text = "postal code";
            Pesel.InputText.Text = "PESEL";
            Nip.InputText.Text = "NIP";
            Regon.InputText.Text = "REGON";

            Login.SetDefaultText();
            Password.SetDefaultText();
            Email.SetDefaultText();
            Name.SetDefaultText();
            Surname.SetDefaultText();
            Age.SetDefaultText();
            City.SetDefaultText();
            Street.SetDefaultText();
            Code.SetDefaultText();
            Pesel.SetDefaultText();
            Nip.SetDefaultText();
            Regon.SetDefaultText();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            bool correct = true;

            //Login
            if (!Regex.IsMatch(Login.GetText(), "^[a-z]{1,}"))
            {
                Login.InputText.Foreground = Brushes.Red;
                correct = false;
            }
            //Password
            //if (!Regex.IsMatch(Login.GetText(), "^[A-Z]{1}[a-z]{2,}"))
            //{
            //    Login.InputText.Foreground = Brushes.Red;
            //    correct = false;
            //}
            //Email
            if (!Regex.IsMatch(Email.GetText(), "^[a-z]{1}\\w+[@]{1}\\w{2,}[.]{1}\\w{2,3}"))
            {
                Email.InputText.Foreground = Brushes.Red;
                correct = false;
            }
            //Name
            if (!Regex.IsMatch(Name.GetText(), "^[A-Z]{1}[a-z]{2,}"))
            {
                Name.InputText.Foreground = Brushes.Red;
                correct = false;
            }
            //Surname
            if (!Regex.IsMatch(Surname.GetText(), "^[A-Z]{1}[a-z]{2,}"))
            {
                Surname.InputText.Foreground = Brushes.Red;
                correct = false;
            }
            //Age
            if (!Regex.IsMatch(Age.GetText(), "^\\d{2}$"))
            {
                Age.InputText.Foreground = Brushes.Red;
                correct = false;
            }
            //City
            if (!Regex.IsMatch(City.GetText(), "^[A-Z]{1}[a-z]+(\\s[A-Z]{1}[a-z]+){0,1}$"))
            {
                City.InputText.Foreground = Brushes.Red;
                correct = false;
            }
            //Street
            if (!Regex.IsMatch(Street.GetText(), "^[A-Z]{1}[a-z]+(\\s[A-Z]{1}[a-z]+){0,1}$"))
            {
                Street.InputText.Foreground = Brushes.Red;
                correct = false;
            }
            //Code
            if (!Regex.IsMatch(Code.GetText(), "^\\d{2}[-]{1}\\d{3}"))
            {
                Code.InputText.Foreground = Brushes.Red;
                correct = false;
            }
            //PESEL
            if (!Regex.IsMatch(Pesel.GetText(), "^\\d{11}$"))
            {
                Pesel.InputText.Foreground = Brushes.Red;
                correct = false;
            }
            //NIP
            if (!Regex.IsMatch(Nip.GetText(), "^\\d{10}$"))
            {
                Nip.InputText.Foreground = Brushes.Red;
                correct = false;
            }
            //REGON
            if (!Regex.IsMatch(Regon.GetText(), "^\\d{9}$"))
            {
                Regon.InputText.Foreground = Brushes.Red;
                correct = false;
            }


            if (correct)
            {
                User user = new User(0, Login.GetText(), Password.GetText(), Email.GetText(),
                    Name.GetText(), Surname.GetText(), Convert.ToInt32(Age.GetText()), 1, City.GetText(),
                    Street.GetText(), Code.GetText(), Pesel.GetText(), Nip.GetText(), Regon.GetText(), "0");

                User.Insert(user);
                ClearAllToDefault();
            }
            else
            {
                MessageBox.Show("Niepoprawne dane!");
            }

        }

        private void ClearAllToDefault()
        {
            Login.Refresh();
            Password.Refresh();
            Email.Refresh();
            Name.Refresh();
            Surname.Refresh();
            Age.Refresh();
            City.Refresh();
            Street.Refresh();
            Code.Refresh();
            Pesel.Refresh();
            Nip.Refresh();
            Regon.Refresh();
        }
    }
}
