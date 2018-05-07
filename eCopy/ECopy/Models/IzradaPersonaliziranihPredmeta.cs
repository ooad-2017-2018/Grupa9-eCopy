﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace ECopy.Models
{
    class IzradaPersonaliziranihPredmeta:Narudzba
    {
        private string predmet;
        private string boja;
        private Image slika;

        public IzradaPersonaliziranihPredmeta(int idNarudzbe, string vrstaNarudzbe, DateTime datumNarudzbe, string trenutniStatus, int kolicina, bool hitnaNarudzba,string predmet, string boja, Image slika):base( idNarudzbe, vrstaNarudzbe,  datumNarudzbe,  trenutniStatus,  kolicina,  hitnaNarudzba)
        {
            this.predmet = predmet;
            this.boja = boja;
            this.slika = slika;
        }

        public string Predmet { get => predmet; set => predmet = value; }
        public string Boja { get => boja; set => boja = value; }
        public Image Slika { get => slika; set => slika = value; }
    }
}
