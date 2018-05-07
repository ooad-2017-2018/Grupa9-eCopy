using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ECopy.Models
{
    class Printanje:Narudzba
    {
        private string format;
        private string uvez;
        private Document dokument;
        private Boolean uBoji;

        public Printanje(string format, string uvez, Document dokument, bool uBoji,int idNarudzbe, string vrstaNarudzbe, DateTime datumNarudzbe, string trenutniStatus, int kolicina, bool hitnaNarudzba, string predmet) : base(idNarudzbe, vrstaNarudzbe, datumNarudzbe, trenutniStatus, kolicina, hitnaNarudzba)
        {
            this.format = format;
            this.uvez = uvez;
            this.dokument = dokument;
            this.uBoji = uBoji;
        }

        public string Format { get => format; set => format = value; }
        public string Uvez { get => uvez; set => uvez = value; }
        public Document Dokument { get => dokument; set => dokument = value; }
        public bool UBoji { get => uBoji; set => uBoji = value; }
    }
}
