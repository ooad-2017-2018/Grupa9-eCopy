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
        IMobileServiceTable<Models.FizickoLice> tabelaFizickoLice = App.MobileService.GetTable<Models.FizickoLice>();
        //Models.SingletonFizickoLice tabelaFizickoLice = App.MobileService.GetTable<Models.F>
        ViewModels.FizickoLiceViewModel flvm = ViewModels.FizickoLiceViewModel.getInstance();
        public Registracija_f()
        {
            this.InitializeComponent();
            //flvm = new ViewModels.FizickoLiceViewModel();
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
            

            string ime = ime1Box.Text;
            string prezime = prezimeBox.Text;
            string adresa = adresaBox.Text;
            string email = emailBox.Text;
            string korisnicko = imeBox.Text;
            string lozinka = sifraBox.Password.ToString();
            string potvrda = potvrdasifrebox.Password.ToString();
            DateTime datum = date.Date.DateTime;


            greska1.Foreground = new SolidColorBrush(Colors.Red);

            if (ime.Length==0 || prezime.Length == 0 || adresa.Length==0 || email.Length==0 || korisnicko.Length==0 )
            {
                greska1.Text = "Morate popuniti sva polja!";
            }
            else if (MainPage.Validacija(adresa, email, korisnicko, lozinka, potvrda, greska1))
            {
                greska1.Text = " ";
                Models.FizickoLice novo = new Models.FizickoLice();
                novo.id = 0;
                novo.Ime = ime;
                novo.prezime = prezime;
                novo.adresa = adresa;
                novo.email = email;
                novo.korisnickoIme = korisnicko;
                novo.lozinka = lozinka;

                tabelaFizickoLice.InsertAsync(novo);

                Boolean b = await flvm.Registruj(ime, prezime, adresa, email, korisnicko, lozinka, datum);

                if (b)
                {
                    MessageDialog showDialog = new MessageDialog("Uspješno ste se registrovali");
                    await showDialog.ShowAsync();
                }
            }
        }

        
    }
}
