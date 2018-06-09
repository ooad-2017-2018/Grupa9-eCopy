using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ECopy
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static bool Validacija(string adresa, string email, string korisnicko, string lozinka, string potvrda, TextBlock greska1)
        {
            if (adresa.Length == 0 || email.Length == 0 || korisnicko.Length == 0)
            {
                greska1.Text = "Morate popuniti sva polja!";
                return false;
            }
            else if (lozinka.Length <= 3)
            {
                greska1.Text = "Lozinka mora imati više od tri znaka!";
                return false;
            }
            else if (korisnicko.Length <= 3)
            {
                greska1.Text = "Korisničko ime mora imati više od tri znaka!";
                return false;
            }
            else if (!email.Contains("@") || !email.Contains("."))
            {
                greska1.Text = "Neispravan format emaila!";
                return false;
            }
            else if (!lozinka.Equals(potvrda))
            {
                greska1.Text = "Lozinke se ne podudaraju!";
                return false;
            }
            return true;
        }
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void MessageTextBlock_SelectionChanged(System.Object sender, RoutedEventArgs e)
        {

        }

        private void Prijava_Click(object sender, RoutedEventArgs e)
        {

            this.Frame.Navigate(typeof(LogIn));
        }

        private void Registracija_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Registracija_f));
        }

        private void narudzba_Click(object sender, RoutedEventArgs e)
        {
            //this.Frame.Navigate(typeof(Views.Karrta));
            this.Frame.Navigate(typeof(OdabirNarudzbe));
        }
    }
}
