using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECopy.ViewModels
{
    class NarudzbaViewModel
    {
        private ECopy.Models.Narudzba narudzba;

        public ECopy.Models.Narudzba Narudzba { get => narudzba; set => narudzba = value; }
        public void PostaviId(int id) { narudzba.IdNarudzbe = id; }
        public int DajId() { return narudzba.IdNarudzbe; }
        public void PostaviVrstuNarudzbe(string vrsta) { narudzba.VrstaNarudzbe = vrsta; }
        public string DajVrstuNarudzbe() { return narudzba.VrstaNarudzbe; }
        public void PostaviDatum(DateTime date) { narudzba.DatumNarudzbe = date; }
        public DateTime dajDatum() { return narudzba.DatumNarudzbe; }
        public void PostaviStatus(string status) { narudzba.TrenutniStatus = status; }
        public string DajStatus() { return narudzba.TrenutniStatus; }
        public void PostaviKolicinu(int kolicina) { narudzba.Kolicina = kolicina; }
        public int DajKolicinu() { return narudzba.Kolicina; }
    }
}
