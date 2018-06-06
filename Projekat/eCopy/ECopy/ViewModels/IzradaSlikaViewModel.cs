using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace ECopy.ViewModels
{
    class IzradaSlikaViewModel
    {
        private ECopy.Models.IzradaSlika korisnik;
        public async Task<bool> Registruj(string format, string dodatno, DateTime datumNarudzbe, string kolicina, bool hitnaNarudzba)
        {
            Windows.Web.Http.HttpClient httpClient = new Windows.Web.Http.HttpClient();
            var headers = httpClient.DefaultRequestHeaders;
            string header = "ie";
            if (!headers.UserAgent.TryParseAdd(header))
            {
                throw new Exception("Invalid header value: " + header);
            }
            header = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)";
            if (!headers.UserAgent.TryParseAdd(header))
            {
                throw new Exception("Invalid header value: " + header);
            }
            //string stri = Convert.ToBase64String(Image);
            korisnik = new Models.IzradaSlika(format, dodatno, 0, "izrada slika", datumNarudzbe, "u obradi", Int32.Parse(kolicina), hitnaNarudzba);

            //MessageDialog showDialog = new MessageDialog(korisnik.Format + korisnik.Dodatno + korisnik.Kolicina);
            //await showDialog.ShowAsync();

            Uri requestUri = new Uri("http://localhost:60625/IzradaSlikas/Add/" + "?datum=" + korisnik.DatumNarudzbe + "&status=" + korisnik.TrenutniStatus + "&kolicina=" + korisnik.Kolicina + "&hitno=" + "da" + "&format=" + korisnik.Format + "&dodatno=" + korisnik.Dodatno);
            Windows.Web.Http.HttpResponseMessage httpResponse = new Windows.Web.Http.HttpResponseMessage();
            string httpResponseBody = "";


            try
            {
                //var success = await Windows.System.Launcher.LaunchUriAsync(requestUri);
                httpResponse = await httpClient.PostAsync(requestUri, null);
                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
                string json = httpResponseBody;
            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }
            return true;
        }
    }
}
