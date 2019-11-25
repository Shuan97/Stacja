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

namespace ProjektStacjaWPF.UI_Models
{
    /// <summary>
    /// Logika interakcji dla klasy InputTextUI.xaml
    /// </summary>
    public partial class InputTextUI : UserControl
    {
        bool dt = false;
        private String defaultText;
        public InputTextUI()
        {
            InitializeComponent();
        }

        public String GetText()
        {
            return this.InputText.Text.ToString();
        }

        private void InputText_OnGotFocus(object sender, RoutedEventArgs e)
        {
            //jeśli tekst nie został jeszcze nadpisany zostanie ustawiona tylko raz jego defaultowa wartość
            if (!dt)
            {
                defaultText = this.InputText.Text;
                dt = true;
            }
            
            if (this.InputText.Text == defaultText)
            {
                this.InputText.Text = "";
            }
            
            this.InputText.Foreground = Brushes.White;
            Border.BorderBrush = Brushes.White;
        }

        private void InputText_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (this.InputText.Text == "")
            {
                this.InputText.Text = defaultText;
                this.InputText.Foreground = Brushes.Gray;
                Border.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF808080");
            }           
        }
    }
}
