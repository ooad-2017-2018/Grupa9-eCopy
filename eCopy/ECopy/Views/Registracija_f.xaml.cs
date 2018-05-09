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
using System.Windows;
using Windows.UI.Popups;
using Microsoft.WindowsAzure.MobileServices;
using Windows.UI;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ECopy
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Registracija_f : Page
    {
        public Registracija_f()
        {
            this.InitializeComponent();
        }

        private void registracijaZaFirmu_Click(object sender, RoutedEventArgs e)
        {

            this.Frame.Navigate(typeof(Registracija_firma));
        }

        private void povratak_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
        
            private async void potvrda_Click(object sender, RoutedEventArgs e)
        {
            IMobileServiceTable<FizickoLice> tabelaFizickoLice = App.MobileService.GetTable<FizickoLice>();

            string ime = ime1Box.Text;
            string prezime = prezimeBox.Text;
            string adresa = adresaBox.Text;
            string email = emailBox.Text;
            string korisnicko = imeBox.Text;
            string lozinka = sifraBox.Password.ToString();
            string potvrda = potvrdasifrebox.Password.ToString();
            //DateTime datum = (DateTime) date.Date;


            greska1.Foreground = new SolidColorBrush(Colors.Red);

            if (ime.Length==0 || prezime.Length == 0 || adresa.Length==0 || email.Length==0 || korisnicko.Length==0 )
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
            else
            {
                greska1.Text = " ";
                FizickoLice novo = new FizickoLice();
                novo.id = 0;
                novo.Ime = ime;
                novo.prezime = prezime;
                novo.adresa = adresa;
                novo.email = email;
                novo.korisnickoIme = korisnicko;
                novo.lozinka = lozinka;

                tabelaFizickoLice.InsertAsync(novo);

                MessageDialog showDialog = new MessageDialog("Uspješno ste se registrovali");
                await showDialog.ShowAsync();
            }
        }

        private void registracijaZaRadnka_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Views.RegistracijaRadnika));
        }
    }
}
