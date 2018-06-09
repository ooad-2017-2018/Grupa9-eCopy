using ECopy.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.UI.Popups;

namespace ECopy.ViewModels
{
    class FizickoLiceViewModel
    {
        private ECopy.Models.FizickoLice korisnik;
        private static readonly HttpClient client = new HttpClient();
        public static string httprequest= "http://ecopyrestapi20180606065004.azurewebsites.net/";


        // static varijabla koja čuva instancu Singleton klase
        private static FizickoLiceViewModel uniqueInstance;
        // privatni konstruktor klase-samo ova tj. Singleton klasa može instancirati ovaj objekat
        private FizickoLiceViewModel() { }
        public static FizickoLiceViewModel getInstance()
        {
            if (uniqueInstance == null)
            {
                // instanciranje objekta Singleton klase
                //ako nikad nije potrebna instanca neće biti nikad kreirana-lazzy implementation
                 uniqueInstance = new FizickoLiceViewModel();
            }
            return uniqueInstance;
        }



        public async Task<bool> Registruj(string ime, string prezime, string adresa, string email, 
            string korisnickoIme, string lozinka, DateTime datum)
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
            //MessageDialog showDialog = new MessageDialog(ime + prezime +email + adresa);
            //await showDialog.ShowAsync();
            korisnik = new Models.FizickoLice(ime, prezime, adresa, email, korisnickoIme, lozinka, datum);

            Uri requestUri = new Uri("http://localhost:60625/FizickoLice/Add/" + "?ime=" + korisnik.Ime + 
                "&prezime=" + korisnik.prezime + "&adresa=" + korisnik.adresa + "&email=" + korisnik.email + 
                "&korisnickoIme=" + korisnik.korisnickoIme + "&lozinka=" + korisnik.lozinka + "&datum=" + 
                korisnik.datumRodjenja);
            Windows.Web.Http.HttpResponseMessage httpResponse = new Windows.Web.Http.HttpResponseMessage();
            string httpResponseBody = "";


            try
            {
                //var success = await Windows.System.Launcher.LaunchUriAsync(requestUri);
                httpResponse = await httpClient.PostAsync(requestUri, null);
                string json = httpResponseBody;
                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }
            return true;
        }

        public async Task<bool> promjenaPassword(string ime, string lozinka)
        {
            {
                Windows.Web.Http.HttpClient httpClient = new Windows.Web.Http.HttpClient();
                //Add a user-agent header to the GET request. 
                var headers = httpClient.DefaultRequestHeaders;

                //The safe way to add a header value is to use the TryParseAdd method and verify the return value is true,
                //especially if the header value is coming from user input.
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

                Uri requestUri = new Uri("http://localhost:60625/FizickoLice/promjenaPassword/"+ "3" + "&password=" + lozinka);


                //Send the PUT request asynchronously and retrieve the response as a string.
                Windows.Web.Http.HttpResponseMessage httpResponse = new Windows.Web.Http.HttpResponseMessage();

                string httpResponseBody = "";
                try
                {

                    httpResponse = await httpClient.PutAsync(requestUri, null);

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

        public async Task<bool> nadjiKorisnika(string username, string lozinka)
        {
            List<FizickoLice> korisnici = new List<FizickoLice>();
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(httprequest);
                client.DefaultRequestHeaders.Clear();

                //definisanje formata koji želimo prihvatiti
                client.DefaultRequestHeaders.Accept.Add(new
                   MediaTypeWithQualityHeaderValue("application/json"));
                //Asinhrono slanje zahtjeva za podacima o studentima

                HttpResponseMessage Res = await client.GetAsync("api/FizickoLice/");
                //Provjera da li je rezultat uspješan
                if (Res.IsSuccessStatusCode)
                {
                    //spremanje podataka dobijenih iz responsa
                    var response = Res.Content.ReadAsStringAsync().Result;

                    //Deserijalizacija responsa dobijenog iz apija i pretvaranje u listustudenata
                    korisnici = JsonConvert.DeserializeObject<List<FizickoLice>>(response);
                }
                foreach (FizickoLice f in korisnici)
                {
                    if (f.korisnickoIme.Equals(username) && f.lozinka.Equals(lozinka)) return true;
                }

                return false;
            }
        }
        }
  }

