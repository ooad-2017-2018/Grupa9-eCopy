using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECopy.ViewModels
{
    class RadnikViewModel
    {
        private ECopy.Models.Radnik radnik;

        public ECopy.Models.Radnik Radnik { get => radnik; set => radnik = value; }
        void PostaviIme(String ime) { radnik.Ime = ime; }
        string DajIme() { return radnik.Ime; }
        void PostaviDatum(DateTime date) { radnik.DatumRodjenja = date; }
        void PostaviPoziciju(string position) { radnik.Pozicija = position; }
        void PostaviPlatu(float plata) { radnik.Plata = plata; }
    }
}

