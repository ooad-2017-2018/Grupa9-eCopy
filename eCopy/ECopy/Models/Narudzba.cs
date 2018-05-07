using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECopy.Models
{
    abstract class Narudzba
    {
        private int idNarudzbe;
        private string vrstaNarudzbe;
        private DateTime datumNarudzbe;
        private string trenutniStatus;
        private int kolicina;
        private Boolean hitnaNarudzba;

        public Narudzba(int idNarudzbe, string vrstaNarudzbe, DateTime datumNarudzbe, string trenutniStatus, int kolicina, bool hitnaNarudzba)
        {
            this.IdNarudzbe = idNarudzbe;
            this.VrstaNarudzbe = vrstaNarudzbe;
            this.DatumNarudzbe = datumNarudzbe;
            this.TrenutniStatus = trenutniStatus;
            this.Kolicina = kolicina;
            this.HitnaNarudzba = hitnaNarudzba;
        }
        public Narudzba(int idNarudzbe, string vrstaNarudzbe, DateTime datumNarudzbe, int kolicina, bool hitnaNarudzba)
        {
            this.IdNarudzbe = idNarudzbe;
            this.VrstaNarudzbe = vrstaNarudzbe;
            this.DatumNarudzbe = datumNarudzbe;
            
            this.Kolicina = kolicina;
            this.HitnaNarudzba = hitnaNarudzba;
        }

        public int IdNarudzbe { get => idNarudzbe; set => idNarudzbe = value; }
        public string VrstaNarudzbe { get => vrstaNarudzbe; set => vrstaNarudzbe = value; }
        public DateTime DatumNarudzbe { get => datumNarudzbe; set => datumNarudzbe = value; }
        public string TrenutniStatus { get => trenutniStatus; set => trenutniStatus = value; }
        public int Kolicina { get => kolicina; set => kolicina = value; }
        public bool HitnaNarudzba { get => hitnaNarudzba; set => hitnaNarudzba = value; }
    }
}
