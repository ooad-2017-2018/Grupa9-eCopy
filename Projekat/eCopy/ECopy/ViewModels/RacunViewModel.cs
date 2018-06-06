using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECopy.ViewModels
{
    class RacunViewModel
    {
        private ECopy.Models.Racun racun;

        public ECopy.Models.Racun Racun { get => racun; set => racun = value; }
        public void PostaviId(int id) { racun.IdRacuna = id; }
        public int DajId() { return racun.IdRacuna; }
        public void PostaviBrojNarudzbi(int broj) { racun.BrojNarudzbi = broj; }
        public int DajBrojNarudzbe() { return racun.BrojNarudzbi; }
        public void PostaviDatum(DateTime date) { racun.DatumIzdavanja = date; }
        public DateTime DajDatum() { return racun.DatumIzdavanja; }
    }
}
