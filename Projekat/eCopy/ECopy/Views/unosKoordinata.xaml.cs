using ECopy.Models;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ECopy.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class unosKoordinata : Page
    {
        public unosKoordinata()
        {
            this.InitializeComponent();
        }

        private void povratak_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void potvrda_Click(object sender, RoutedEventArgs e)
        {
            int id = Int32.Parse(IDnarudzbe2.Text);
            float longitude = float.Parse(longitude2.Text);
            float latitude = float.Parse(latitude2.Text);

            foreach (Narudzba n in KontejnerskaKlasa.narudzbe)
            {
                if (n.IdNarudzbe == id)
                {
                    n.pozicijaLongitude = longitude;
                    n.pozicijaLatitude = latitude;
                }
            }
        }
    }
}
