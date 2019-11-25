using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Management;
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
    /// Logika interakcji dla klasy EmployeeEditUsersView.xaml
    /// </summary>
    public partial class EmployeeEditUsersView : UserControl
    {
        private int _id;
        private string _username;
        private string _password;
        private string _name;
        private string _surname;
        private string _mail;
        private int _age;
        private string _city;
        private string _street;
        private string _code;
        private string _pesel;
        private string _nip;
        private string _regon;
        private string _role;
        private string _points;

        public EmployeeEditUsersView()
        {
            InitializeComponent();
            List<User> users = User.GetUsers();
            //UserList.Items.Clear();
            UserList.ItemsSource = users;
        }

        private void BtnEditData(object sender, RoutedEventArgs e)
        {            
            EditData();
        }

        private void EditData()
        {
            try
            {
                //_username = Username.Text;
                //_password = Name.
                _name = Name.Text;
                _surname = Surname.Text;
                _mail = Mail.Text;
                _age = Convert.ToInt32(Age.Text);
                _city = City.Text;
                _street = Street.Text;
                _code = Code.Text;
                _pesel = Pesel.Text;
                _nip = Nip.Text;
                _regon = Regon.Text;
                _role = Role.SelectedIndex.ToString();
                //MessageBox.Show(_role);

                User.Update(new User(_id, _username, _password, _mail, _name, _surname, _age, Convert.ToInt32(_role) + 1, _city, _street, _code, _pesel, _nip, _regon, _points));
                List<User> users = User.GetUsers();
                //UserList.Items.Clear();
                UserList.ItemsSource = users;
            }
            catch (Exception e)
            {
                MessageBox.Show("Niepoprawnde dane!");
            }            
        }

        private void UserList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //DataGrid dataGrid = (DataGrid)sender;
            //if (dataGrid.SelectedItem is DataRowView rowSelected)
            //{
            //    Name.Text = rowSelected["Name"].ToString();
            //}
            //MessageBox.Show("!!!");

            User user = UserList.SelectedItem as User;
            if (user != null)
            {
                _id = user.Id;
                _username = user.Username;
                _password = user.Password;
                Name.Text = user.Name;
                Surname.Text = user.Surname;
                Mail.Text = user.Mail;
                Age.Text = user.Age.ToString();
                City.Text = user.City;
                Street.Text = user.Street;
                Code.Text = user.Code;
                Pesel.Text = user.Pesel;
                Nip.Text = user.Nip;
                Regon.Text = user.Regon;
                Role.SelectedIndex = user.Role - 1;
                _points = user.Points;
            }

            //foreach (User row in UserList.ItemsSource)
            //{
            //    Console.WriteLine(row.Name.ToString());
            //}
        }
    }
}
