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
using Windows.UI.Popups;
using Windows.UI;
using Microsoft.WindowsAzure.MobileServices;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ECopy
{

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Registracija_firma : Page
    {
        public Registracija_firma()
        {
            this.InitializeComponent();
        }

        private void povratak_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        private async void potvrda_Click(object sender, RoutedEventArgs e)
        {
            IMobileServiceTable<Firma> tabelaFirma = App.MobileService.GetTable<Firma>();

            string naziv = imefirmeBox.Text;
            string ime = ime1Box.Text;
            string prezime = prezimeBox.Text;
            string adresa = adresaBox.Text;
            string email = emailBox.Text;
            string korisnicko = imeBox.Text;
            string lozinka = sifraBox.Password.ToString();
            string potvrda = potvrdasifrebox.Password.ToString();
            string racun = racunBox.Text;

            greska1.Foreground = new SolidColorBrush(Colors.Red);

            if (naziv.Length == 0 || ime.Length == 0 || prezime.Length == 0 || adresa.Length == 0 || email.Length == 0 || korisnicko.Length == 0)
            {
                greska1.Text = "Morate popuniti sva polja!";
            }
            else if (lozinka.Length <= 3)
            {
                greska1.Text = "Lozinka mora imati više od tri znaka!";
            }
            else if (korisnicko.Length <= 3)
            {
                greska1.Text = "Korisničko ime mora imati više od tri znaka!";
            }
            else if (!email.Contains("@") || !email.Contains("."))
            {
                greska1.Text = "Neispravan format emaila!";
            }
            else if (!lozinka.Equals(potvrda))
            {
                greska1.Text = "Lozinke se ne podudaraju!";
            }
            else if (!IsDigitsOnly(racun) || racun.Length<=8)
            {
                greska1.Text = "Neispravan broj racuna!";
            }
            else
            {
                greska1.Text = " ";
                Firma novo = new Firma(naziv, ime, prezime, adresa, email, 000, korisnicko, lozinka, 000);
                novo.Id = 0;

                tabelaFirma.InsertAsync(novo);
                
                //MessageBox.Show("Usoješno ste se registrovali");

                MessageDialog showDialog = new MessageDialog("Uspješno ste se registrovali kao firma");
                await showDialog.ShowAsync();
            }
        }
    }

}
