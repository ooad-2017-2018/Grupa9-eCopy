using ECopy.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Services.Maps;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
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
    public sealed partial class Karrta : Page
    {

        public const double lokacijaKopirniceLongitude = 18.3770994009617;
        public const double lokacijaKopirniceLatitude = 43.8911123782028;
        public Models.Library Library = new Models.Library();
        public int indexPosition = 1;
        public Karrta()
        {
            this.InitializeComponent();
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            double lo=lokacijaKopirniceLongitude;
            double la=lokacijaKopirniceLatitude;
            foreach (Narudzba n in KontejnerskaKlasa.narudzbe)
            {
                if (n.IdNarudzbe == KontejnerskaKlasa.i) { lo = n.pozicijaLongitude; la = n.pozicijaLatitude; }
            }
            Geopoint myPoint = await Library.Position();
            eCopyMapa.ZoomLevel = 16;
            eCopyMapa.Center = myPoint;
            dodajIkonuNaPoziciju(myPoint, "Vasa lokacija: " + indexPosition);
            BasicGeoposition pozicijaNarudzbe = new BasicGeoposition();
            pozicijaNarudzbe.Longitude = lo;
            pozicijaNarudzbe.Latitude = la;
            Geopoint kraj = new Geopoint(pozicijaNarudzbe);
            dodajIkonuNaPoziciju(kraj, "Lokacija narudzbe: " + indexPosition);
            PrikaziRutu(myPoint, kraj); //crtaj na klik
            indexPosition++;
        }

        private void dodajIkonuNaPoziciju(Geopoint location, string name)
        {
            //Kreiranje ikone
            MapIcon mapIcon = new MapIcon();
            mapIcon.Location = location;
            mapIcon.Title = String.Format("{0}\nLatin:{1}\nLongLng:{2}", name, location.Position.Latitude, location.Position.Longitude);

            //Dodavanje slike za lokaciju
            mapIcon.NormalizedAnchorPoint = new Point(0.5, 1.0);
            mapIcon.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/pinMap.jpg"));
            mapIcon.ZIndex = 0;
            eCopyMapa.MapElements.Add(mapIcon);
        }

        private async void PrikaziRutu(Geopoint pocetak, Geopoint kraj)
        {
            MapRouteFinderResult Rezultat = await MapRouteFinder.GetDrivingRouteAsync(pocetak, kraj, MapRouteOptimization.Time, MapRouteRestrictions.None);
            if(Rezultat.Status==MapRouteFinderStatus.Success)
            {
                eCopyMapa.Routes.Clear();
                MapRouteView pogledRute = new MapRouteView(Rezultat.Route);
                pogledRute.RouteColor = Colors.LightPink;
                pogledRute.OutlineColor = Colors.Black;

                eCopyMapa.Routes.Add(pogledRute);
                await eCopyMapa.TrySetViewBoundsAsync(Rezultat.Route.BoundingBox, null, MapAnimationKind.None);

            }
            else
            {
                var message = new MessageDialog("Ne moze se naci ruta");
                await message.ShowAsync();
            }
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            //Geopoint position = await Library.Position();
            //DependencyObject marker = Library.Marker();
            //eCopyMapa.Children.Add(marker);
            //MapControl.SetLocation(marker, position);
            //MapControl.SetNormalizedAnchorPoint(marker, new Point(0.5, 0.5));
            //eCopyMapa.ZoomLevel = 12;
            //eCopyMapa.Center = position;
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(IzbornikFizickogLica));
        }

        private async void eCopyMapa_MapTapped(MapControl sender, MapInputEventArgs args)
        {
            dodajIkonuNaPoziciju(args.Location, "Position: " + indexPosition);
            indexPosition++;
            Geopoint pocetak = await Library.Position();
            PrikaziRutu(pocetak, args.Location); //crtaj na klik
        }
    }
}
