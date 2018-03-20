# Grupa9-eCopy
Tema: Online kopirnica

###Članovi tima
- Omerašević Berina
- Panjeta Ajla
- Zukorlić Nudžejma

##OPIS  TEME

Aplikacija eCopy je aplikacija koja omogućava svojim korisnicima (kupcima) da koriste usluge kopirnice bez potrebe da je posjećuju, tj. online. Naime, zahvaljujući  ovoj aplikacije korisnik može putem svog uređaja (mobilnog telefona, laptopa i sl.), poslati dokumente za printanje, te odabrati način kopiranja koji želi (boja, format, uvez...). Pored usluga printanja na papiru, kopirnica nudi i druge usluge kao što je pravljenje personalizovanih šoljica, majica, termos boca, naljepnica te plakata, na korisniku je samo da putem ove aplikacije odabere  željeni predmet,  boju, natpis i/ili sliku), a kopirnica(odnosno radnik kopirnice) ima zadatak da obavi ono sto je korisnik tražio i pošalje mu proizvod na kućnu adresu (ukoliko je on to odabrao). Kopirnica također nudi usluge izrade reklamnih materijala za firme u vidu printanja na raznim predmetima koje korisnik može odabrati.
Korisnici aplikacije imaju mogućnost da kreiraju vlastiti account kako bi ostvarili razne pogodnosti koje kopoirnica nudi, ali i olakšali sebi način naručivanja jer ne bi morali svaki put navoditi svoje podatke i mogli bi izvršiti online plaćanje. Ukoliko ne žele kreirati nalog mogu se prijaviti i kao gost. Pored korisnika (kupaca) i radnici kopirnice imaju svoj account na aplikaciji kako bi mogli primati narudžbe, te slati povratne informacije klijentima.
Aplikacija je pogodna za ljude koji nemaju vremena posjećivati kopirnice i čekati da se ispuni njihov zahtjev, jer na ovaj način sve mogu obaviti u veoma kratkom roku i dobiti gotov proizvod na kućnu adresu jer aplikacija ima i opciju hitne narudžbe (koja se dodatno plaća).
Ovu aplikaciju (sistem) može kupiti bilo koja kopirnica koja posjeduje ove usluge, a želi modernizovati svoj način rada.

##PROCESI

###Registracija korisnika
Korisnik ce imati opciju sign in pri samom otvaranju aplikacije, gdje ce se tražiti od njega da unese licne podatke:
- Ime
-	Prezime
-	Broj telefona
-	Adresa
-	Broj racuna
-	Korisnicko ime
-	Lozinka
-	Student/Penzioner (neobavezno polje)-služi kako bi navedene kategorije mogle poslti dokaz o svom statusu i ostavriti određeni popust

###Registracija firmi
-	Naziv firme
-	Ime zaduzene osobe
-	Broj telefona
-	Adresa
-	Broj racuna
-	Korisnicko ime
-	Lozinka
Napomena: Potrebno je da se razlikuje registracija firmi i registracija fizičkih lica, jer kopirnica nudi različite pogodnosti za ova dva slučaja (npr. za firme je omogućeno prinatnje reklamnih materijala itd.)

###Slanje narudžbe za printanje
Korisnik koji je  registrovan može koristiti ovu opciju tako što popunjava određenu formu sa sljedećim podacima:
-	Dokument za printanje(upload)
-	Broj primjeraka
-	Format
-	Boja
-	Uvez
-	Vrsta papira
-	Boja papira
-	Dodatni zahtjev
-	Hitna narudžba
Neregistrovani korisnici će morati poslati i lične podatke sa adresom kako bi se mogla obaviti dostava.

###Slanje narudžbe za izradu slika
Korisnik koji je  registrovan može koristiti ovu opciju tako što popunjava određenu formu sa sljedećim podacima:
-	Slike za izradu
-	Broj primjeraka
-	Format
-	Dodatni zahtjev (okvir, crno-bijela izrada...)
-	Hitna narudžba
Neregistrovani korisnici će morati poslati i lične podatke sa adresom kako bi se mogla obaviti dostava.

###Slanje narudžbe za izradu personalizoavnih predmeta:
Kao i za slanje narzdžbe za printanje registrovani korisnici popunjavaju sljedeće podatke: (dok neregistrovani moraju dodatno poslati i lične podatke)
-	Slika/logo
-	Predmet(izabir  ponudjenih)
-	Kolicina
-	Boja
-	Dodatni zahtjev
-	Hitna narudžba

###Slanje narudžbe za izradu reklamnog materijala(samo za registrovane  firme)
Registrovane firme  moraju poslati sljedeće podatke kako bi izvršili narudžbu:
-	Slika/logo
-	Predmet(izabir  ponudjenih)
-	Kolicina
-	Krajnji datum isporuke
-	Dodatni zahtjev

###Uvid u stanje poslane narudžbe
Ovoj opciji pristupaju klijenti koji su registroavni a poslai su narudžbu i na ovaj način mogu vidjeti odgovor kopirnice na njihov zahtjev te eventualno vrijeme dolaska narudžbe. 

###Registracija radnika
Radnika može registrovati samo administrator. Potrebno je popuniti sljedeće podatke:
-	Ime
-	Prezime
-	Datum rođenja
-	Pozicija (radnik na poslovima printanja, dostavljač...)
-	Broj telefona
-	Adresa
-	Stručna sprema
-	Plata
Ovi podaci će biti vidljivi samo administratoru, kao i spisak radnika.

###Preuzimanje zahtjeva klijenta i odgovor na njegov zahtjev
Registrovani radnik će imati uvid u sve primljene narudžben i preuzeće one najstarije, kada pročita narudžbu i zahtjeve klijenta, šalje povratne informacije klijentu(npr. da li može ili ne može ispuniti njegove zahtjeve i zašto, kada bi mogao očekivati svoj paket itd.), nakon što završi posao pakuje paket i dodjeljuje mu identifikacioni  broj , te šalje paket putem dostavljača na određenu adresu.

##FUNKCIONALNOSTI

-Mogućnost registracije korisnika
-Mogućnost registracije firme
-Slanje narudžbe za printanje
-Slanje narudžbe za izradu slika
-Slanje narudžbe za izradu personalizovanih predmeta
-Slanje narudžbe za izradu reklamnog materijala (važi samo za firme)
-Preuzimanje narudžbe od strane uposlenika
-Slanje povratne informacije klijentu o narudžbi
-Preuzimanje adrese i paketa za slanje od strane uposlenika(dostavljača)

##AKTERI:

-Kupac: Online korisnik koji šalje svoje zahtjeve (fizičko lice ili firma)
-Administrator- Unosi nove radnike i održava aplikaciju, dodaje nove ponude isl.
-Radnik kopirnice-Ispunjava zahtjeve kupca
-Radnik dostavljač- Dobija zahtjev za pošiljku i dostavlja je na kućnu adresu
