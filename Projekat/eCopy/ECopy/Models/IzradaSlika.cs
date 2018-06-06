using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECopy.Models
{
    class IzradaSlika : Narudzba
    {
        private string format;
        private string dodatno;

        public IzradaSlika(string format, string dodatno, int idNarudzbe, string vrstaNaarudzbe, DateTime datumNarudzbe, string trenutniStatus, int kolicina, bool hitnaNarudzba) : base(idNarudzbe, vrstaNaarudzbe, datumNarudzbe, trenutniStatus, kolicina, hitnaNarudzba)
        {
            this.Format = format;
            this.Dodatno = dodatno;
        }

        public string Format { get => format; set => format = value; }
        public string Dodatno { get => dodatno; set => dodatno = value; }
    }
}
