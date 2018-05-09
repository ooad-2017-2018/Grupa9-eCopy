using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
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
        public KontrolaZaLogIn()
        {
            this.InitializeComponent();
        }

        private async void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            RegistracijaRadnika r = new RegistracijaRadnika();




        }

        private void Potvrdi_Click_1(object sender, RoutedEventArgs e)
        {
            Potvrdi_Click(sender, e);
        }
    }
}
