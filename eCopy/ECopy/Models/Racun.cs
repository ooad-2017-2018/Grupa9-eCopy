﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECopy.Models
{
    class Racun
    {
        private int idRacuna;
        private int brojNarudzbi;
        private DateTime datumIzdavanja;

        public Racun(int idRacuna, int brojNarudzbi, DateTime datumIzdavanja)
        {
            this.idRacuna = idRacuna;
            this.brojNarudzbi = brojNarudzbi;
            this.datumIzdavanja = datumIzdavanja;
        }

        public int IdRacuna { get => idRacuna; set => idRacuna = value; }
        public int BrojNarudzbi { get => brojNarudzbi; set => brojNarudzbi = value; }
        public DateTime DatumIzdavanja { get => datumIzdavanja; set => datumIzdavanja = value; }
    }
}
