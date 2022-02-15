using System;
using System.Collections.Generic;
using System.Linq;

namespace Projekti201801Esimerkit
{
    // Ohjelman pääluokka, ns. pääohjelma, josta kaikki toiminnallisuus
    // alkaa.

    class MainClass
    {

        // Main metodia kutsutaan kun ohjelma käynnistyy. Tämä on ensimmäinen
        // metodi mitä siis ohjelma kutsuu ja josta kaikki alkaa.
        // 
        // "string[] args" tarkoittaa parametreja, jos niitä on annettu ohjelman
        // alkaessa esimerkiksi komentokehotteesta.

        public static void Main(string[] args)
        {
            // Varsinaisen ohjelman suoritus alkaa.
            Tulostaja tulostaja = new Tulostaja();
            Lukija lukija = new Lukija();
            CsvTiedosto csv = new CsvTiedosto();


            const string tallennusSijainti = @"/Users/sovelluskontti/dev/tmp/";
            const string tiedostopolkuTuotelista = tallennusSijainti + "tuotelista.csv";
            const string tiedostopolkuTilaus = tallennusSijainti + "tilaus.csv";

            List<Tuote> tuotelista = csv.LueTuotteetTiedostosta(tiedostopolkuTuotelista);

            tulostaja.TulostaTuoterivinOtsikot();
            tulostaja.TulostaTuoterivit(tuotelista);
            tulostaja.TulostaTuotteenValintaOhje();

            int valittuTunniste = lukija.PyydaNumero();
            Tuote valittuTuote = tuotelista[valittuTunniste - 1];


            tulostaja.TulostaTuoterivi(valittuTuote);
            csv.KirjoitaTiedostoon(tiedostopolkuTilaus, valittuTuote);
            // Varsinaisen ohjelman suoritus loppuu.
        }

    }
}
