using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
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

    public sealed partial class PromjenaKorisnickihPodataka : Page
    {
        public string trenutniUser;
        ViewModels.FizickoLiceViewModel flvm= ViewModels.FizickoLiceViewModel.getInstance();
        public PromjenaKorisnickihPodataka()
           
        {
            
            this.InitializeComponent();
            //flvm = new ViewModels.FizickoLiceViewModel();

        }

        private async void potvrda_Click(object sender, RoutedEventArgs e)
        {

            string adresa = adresaBox.Text;
            string email = emailBox.Text;
            string korisnicko = imeBox.Text;
            string lozinka = sifraBox.Password.ToString();
            string potvrda = potvrdasifrebox.Password.ToString();
            //DateTime datum = (DateTime) date.Date;


            greska1.Foreground = new SolidColorBrush(Colors.Red);
           
            if (MainPage.Validacija(adresa, email, korisnicko, lozinka, potvrda, greska1))

            {
                greska1.Text = " ";
                Boolean b = await flvm.promjenaPassword(Models.FizickoLice.trenutniUser, lozinka);
                if (b)
                {
                    MessageDialog showDialog = new MessageDialog("Promjena šifre uspješno završena");
                    await showDialog.ShowAsync();
                }
            }
        }

        private void povratak_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(IzbornikFizickogLica));
        }
    }
}
