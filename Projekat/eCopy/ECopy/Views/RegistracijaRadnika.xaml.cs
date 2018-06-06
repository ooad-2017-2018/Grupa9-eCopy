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

namespace ECopy.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    public sealed partial class RegistracijaRadnika : Page
    {

        ViewModels.RadnikViewModel radnikvm;
        public RegistracijaRadnika()
        {
            this.InitializeComponent();
            radnikvm = new ViewModels.RadnikViewModel();
        }

        private void povratak_Click(object sender, RoutedEventArgs e)
        {

            this.Frame.Navigate(typeof(MainPage));
        }

        private async void potvrda_Click(object sender, RoutedEventArgs e)
        {
            IMobileServiceTable<Models.Radnik> tabelaRadnici = App.MobileService.GetTable<Models.Radnik>();

            string ime = ime1.Text;
            string prezime = prezime2.Text;
            object Temp = pozicija2.SelectedItem;
            string pozicija = Temp.ToString();
            string plata = plata2.Text;
            string korisnicko = korisnicko2.Text;
            string lozinka = lozinka2.Password.ToString();
            string potvrda = potvrdalozinka2.Password.ToString();
            //DateTime datum = dat2.get;

            greska1.Foreground = new SolidColorBrush(Colors.Red);

            if (ime.Length == 0 || prezime.Length == 0 || pozicija.Length == 0 || plata.Length == 0 || korisnicko.Length == 0)
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
            else if (!lozinka.Equals(potvrda))
            {
                greska1.Text = "Lozinke se ne podudaraju!";
            }

            else
            {
                greska1.Text = " ";


                Boolean b = await radnikvm.Registruj(lozinka, korisnicko, ime, prezime, pozicija, default(DateTime));
                if (b)
                {
 
                   // await showDialog4.ShowAsync();
                    // this.Frame.Navigate(typeof(PocetnaForma));
                }
                ECopy.Models.Radnik novi = new ECopy.Models.Radnik(ime, prezime, korisnicko, lozinka, pozicija, float.Parse(plata), default(DateTime));
                novi.id = 0;

                tabelaRadnici.InsertAsync(novi);

                MessageDialog showDialog = new MessageDialog("Uspješno ste se registrovali");
                await showDialog.ShowAsync();


            }


        }
    }
}
