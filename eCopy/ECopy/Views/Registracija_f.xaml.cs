﻿using System;
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

            if (!lozinka.Equals(potvrda))
            {
                MessageDialog showDialog1 = new MessageDialog("Lozinke se ne podudaraju");
                await showDialog1.ShowAsync();
            }
            FizickoLice novo = new FizickoLice();
            novo.id = 0;
            novo.Ime = ime;
            novo.prezime = prezime;
            novo.adresa = adresa;
            novo.email = email;
            novo.korisnickoIme = korisnicko;
            novo.lozinka = lozinka;

            tabelaFizickoLice.InsertAsync(novo);

            //KontejnerskaKlasa.registrovaniKorisnici.Add(novo);

            MessageDialog showDialog = new MessageDialog("Uspješno ste se registrovali");
            await showDialog.ShowAsync();
        }

        private void registracijaZaRadnka_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Views.RegistracijaRadnika));
        }
    }
}
