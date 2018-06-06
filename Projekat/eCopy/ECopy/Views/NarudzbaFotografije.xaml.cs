using ECopy.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ECopy
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NarudzbaFotografije : Page
    {
        ViewModels.IzradaSlikaViewModel slikevm;
        public NarudzbaFotografije()
        {
            this.InitializeComponent();
            slikevm = new ViewModels.IzradaSlikaViewModel();
        }

        private void povratak_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(OdabirNarudzbe));

        }

        private async void potvrda_Click(object sender, RoutedEventArgs e)
        {
            bool da = false;
            if (hitno.IsChecked==true) da = true;
            Narudzba nova = new IzradaSlika(format2.Text, velicina2.Text, 1, "izradaSlika", default(DateTime), "u obradi", Int32.Parse(kolicina2.Text), da);
            KontejnerskaKlasa.narudzbe.Add(nova);
            Boolean b = await slikevm.Registruj(format2.Text,  velicina2.Text,  default(DateTime), kolicina2.Text,  da);
            //DateTime datum = DateTime.Parse("2018-01-01");
            // b = await slikevm.Registruj("A4", "3", datum, "ne", true);
            if (b)
            {
                MessageDialog showDialog = new MessageDialog("Obavljena narudzba za izradu slika");
                await showDialog.ShowAsync();
            }
        }
    }
}
