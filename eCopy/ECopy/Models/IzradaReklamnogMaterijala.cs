using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace ECopy.Models
{
    class IzradaReklamnogMaterijala:Narudzba
    {
        private string predmet;
        private string boja;
        private Image slika;
        private string logo;

        public IzradaReklamnogMaterijala(string predmet, string boja, Image slika, string logo, int idNarudzbe, string vrstaNarudzbe, DateTime datumNarudzbe, string trenutniStatus, int kolicina, bool hitnaNarudzba) : base(idNarudzbe, vrstaNarudzbe, datumNarudzbe, trenutniStatus, kolicina, hitnaNarudzba)
        {
            this.predmet = predmet;
            this.boja = boja;
            this.slika = slika;
            this.logo = logo;
        }

        public string Predmet { get => predmet; set => predmet = value; }
        public string Boja { get => boja; set => boja = value; }
        public Image Slika { get => slika; set => slika = value; }
        public string Logo { get => logo; set => logo = value; }
    }
}
