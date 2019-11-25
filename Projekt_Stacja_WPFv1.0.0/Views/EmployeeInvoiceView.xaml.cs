using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ProjektStacjaWPF.Views
{
    /// <summary>
    /// Logika interakcji dla klasy EmployeeInvoiceView.xaml
    /// </summary>
    public partial class EmployeeInvoiceView : UserControl
    {
        private Product pr1 = null;
        private Product pr2 = null;
        private Product pr3 = null;
        private List<Product> productList;
        private User user;

        public EmployeeInvoiceView()
        {
            InitializeComponent();
            
        }

        private void BtnSearchUser(object sender, RoutedEventArgs e)
        {
            user = null;
            if (!String.IsNullOrEmpty(Number.Text))
            {
                user = User.GetUserByNumber(Number.Text);
            }
            else
            {
                MessageBox.Show("Wpisz numer!");
            }

            if (user != null)
            {
                Name.Text = user.Name;
                Surname.Text = user.Surname;
                Points.Text = user.Points;
            }          
        }

        private void BtnAddProducts(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            pr1 = Product.RandomProduct(0);
            pr2 = Product.RandomProduct(1);
            pr3 = Product.RandomProduct(2);
            int count = random.Next(1, 1000);
            productList = new List<Product>();
            productList.Add(pr1);
            if (count > 600 && pr1.Item != pr2.Item)
            {
                productList.Add(pr2);
            }
            if (count > 900 && pr1.Item != pr3.Item && pr2.Item != pr3.Item)
            {
                productList.Add(pr3);
            }
            //ProductList.Items.Clear();
            ProductList.ItemsSource = productList;
        }

        private void BtnInvoice(object sender, RoutedEventArgs e)
        {
            if (user == null)
            {
                MessageBox.Show("Wpisz dane użytkownika");
                return;
            }

            if (!Regex.IsMatch(pr1.Amount, "^\\d+$")) { MessageBox.Show("Niepoprawne dane wejściowe!"); }
            else
            {
                try
                {
                    Document doc = new Document(PageSize.A4, 10, 10, 42, 35);
                    PdfWriter pdfw = PdfWriter.GetInstance(doc, new FileStream("faktura.pdf", FileMode.Create));
                    doc.Open();
                    iTextSharp.text.Paragraph p = new iTextSharp.text.Paragraph("FAKTURA");
                    p.Alignment = Element.ALIGN_CENTER;
                    doc.Add(p);
                    iTextSharp.text.Paragraph p2 = new iTextSharp.text.Paragraph("");
                    p2.SpacingAfter = 10f;
                    p2.SpacingBefore = 10f;
                    doc.Add(p2);
                    var headerTab = new PdfPTable(new[] { .75f, 2f })
                    {
                        WidthPercentage = 75,
                        DefaultCell = { MinimumHeight = 22f }
                    };

                    headerTab.AddCell("Data");
                    headerTab.AddCell(DateTime.Now.ToString());
                    headerTab.AddCell("Imię");
                    headerTab.AddCell(user.Name);
                    headerTab.AddCell("Nazwisko");
                    headerTab.AddCell(user.Surname);
                    headerTab.AddCell("NIP");
                    headerTab.AddCell(user.Nip);
                    headerTab.AddCell("Miasto");
                    headerTab.AddCell(user.City);
                    headerTab.AddCell("Kod pocztowy");
                    headerTab.AddCell(user.Code);
                    headerTab.AddCell("Ulica");
                    headerTab.AddCell(user.Street);

                    doc.Add(headerTab);

                    iTextSharp.text.Paragraph p3 = new iTextSharp.text.Paragraph("");
                    p3.SpacingAfter = 10f;
                    p3.SpacingBefore = 10f;
                    doc.Add(p3);

                    iTextSharp.text.Paragraph p4 = new iTextSharp.text.Paragraph("Usługi i towary");
                    p4.Alignment = Element.ALIGN_CENTER;
                    doc.Add(p4);

                    iTextSharp.text.Paragraph p5 = new iTextSharp.text.Paragraph("");
                    p5.SpacingAfter = 10f;
                    p5.SpacingBefore = 10f;
                    doc.Add(p5);

                    foreach (Product i in productList)
                    {
                        iTextSharp.text.Paragraph p0 = new iTextSharp.text.Paragraph(i.Item + "   " + i.Amount + "L   " + i.Sum + "PLN");
                        doc.Add(p0);
                    }
                    doc.Close();
                    MessageBox.Show("Operacja udana");
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }
    }
}
