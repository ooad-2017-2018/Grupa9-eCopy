using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ECopy.ViewModels
{
    class RadnikViewModel
    {
        private ECopy.Models.Radnik korisnik;
        

        public async Task<bool> Registruj(string Password, string Username, string FirstName, string LastName, string Position, DateTime DateOfBirth)
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
            korisnik = new Models.Radnik(FirstName, LastName, Username, Password, Position, 1000, DateOfBirth);
            Uri requestUri = new Uri("http://localhost:60625/Radniks/Add/" + "?ime=" + korisnik.Ime + "&prezime=" + korisnik.Prezime + "&korisnickoIme=" + korisnik.KorisnickoIme + "&lozinka=" + korisnik.Lozinka + "&pozicija=" + korisnik.Pozicija + "&plata=" + korisnik.Plata.ToString() + "&datum=" + korisnik.DatumRodjenja);
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

