using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECopy.Models
{
    class IzradaSlika:Narudzba
    {
        private string format;
        private string dodatno;

        public IzradaSlika(int idNarudzbe, string vrstaNarudzbe, DateTime datumNarudzbe, string trenutniStatus, int kolicina, bool hitnaNarudzba,string predmet, string boja, Image slika, string dodatno, string format):base(idNarudzbe, vrstaNarudzbe, datumNarudzbe, trenutniStatus, kolicina, hitnaNarudzba)
        {
            this.format = format;
            this.dodatno = dodatno;
        }

        public string Format { get => format; set => format = value; }
        public string Dodatno { get => dodatno; set => dodatno = value; }
    }
}
