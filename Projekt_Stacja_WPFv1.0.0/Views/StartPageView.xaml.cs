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
    /// Logika interakcji dla klasy StartPageView.xaml
    /// </summary>
    public partial class StartPageView : UserControl
    {
        public StartPageView()
        {
            InitializeComponent();
            UserInfo.Content = "Witaj " + User.GetCurrentUser().Name + "!";
            Information.Text =
                "Stacja paliw – punkt sprzedaży detalicznej paliw, głównie benzyny," +
                " oleju napędowego oraz gazu płynnego (LPG), płynów chłodzących, środków czyszczących itp. " +
                "Dawniej, w początkowej fazie rozwoju motoryzacji, sprzedawano w nich wyłącznie paliwo, " +
                "a czas ich pracy zazwyczaj nie różnił się od czasu otwarcia warsztatów lub sklepów:" +
                " w nocy i w dni świąteczne stacje bywały nieczynne." + "Obecnie stacje paliw – tak w Polsce," +
                " jak w większości krajów europejskich – czynne są zazwyczaj całą dobę i przez wszystkie dni" +
                " tygodnia. Zwykle oferują – prócz sprzedaży paliw – akcesoria motoryzacyjne, drobne" +
                " typowe części zamienne(żarówki samochodowe, pióra wycieraczek, bezpieczniki samochodowe) itp.," +
                " a także oleje silnikowe i inne płyny eksploatacyjne do samochodów.Obok tych typowo motoryzacyjnych" +
                " towarów na stacjach paliw sprzedawane bywają na ogół także napoje oraz artykuły żywnościowe" +
                " – zazwyczaj batoniki, herbatniki itp.oraz żywność konserwowana, a także np.papierosy i gazety.Bywają" +
                " tam też instalowane automaty do sprzedaży napojów zimnych i gorących.";
        }
    }
}
