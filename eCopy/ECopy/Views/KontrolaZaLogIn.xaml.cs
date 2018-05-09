using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using WinUX.Mvvm.Services;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ECopy.Views
{
    public sealed partial class KontrolaZaLogIn : UserControl
    {
        public delegate void MyEventHandler(object source, EventArgs e);

        public event MyEventHandler OnNavigateParentReady;
        public event MyEventHandler OnNavigateParentReady2;

        public KontrolaZaLogIn()
        {
            this.InitializeComponent();
        }



        private void Potvrdi_Click_1(object sender, RoutedEventArgs e)
        {
            string ime = korisnickoImeBox.Text;
            string sifra = lozinkaBox.Password.ToString();
            greska1.Foreground = new SolidColorBrush(Colors.Red);

            if (ime.Length == 0 || sifra.Length == 0)
            {
                greska1.Text = "Morate popuniti sva polja!";
            }
            else if (sifra.Length <= 3)
            {
                greska1.Text = "Lozinka mora imati više od tri znaka!";
            }
            else if (ime.Length <= 3)
            {
                greska1.Text = "Korisničko ime mora imati više od tri znaka!";
            }
            else
            {
                if (korisnickoImeBox.Text == "administrator" && lozinkaBox.Password.ToString() == "123456789")
                    OnNavigateParentReady(this, null);
                else OnNavigateParentReady2(this, null);
            }


        }
    }
}
