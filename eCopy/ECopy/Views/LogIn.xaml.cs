using ECopy.Views;
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

namespace ECopy
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LogIn : Page
    {
        public LogIn()
        {
            this.InitializeComponent();
            login.OnNavigateParentReady += Login_OnNavigateParentReady;
            login.OnNavigateParentReady2 += Login_OnNavigateParentReady2;
        }

        private void Login_OnNavigateParentReady2(object source, EventArgs e)
        {
            Frame.Navigate(typeof(IzbornikFizickogLica));
        }

        private void Login_OnNavigateParentReady(object source, EventArgs e)
        {
            Frame.Navigate(typeof(RegistracijaRadnika));
        }

        private void povratak_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void login_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
