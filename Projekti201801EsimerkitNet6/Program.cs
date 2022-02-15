// Ohjelman pääluokka, ns. pääohjelma, josta kaikki toiminnallisuus
// alkaa.
using Projekti201801EsimerkitNet6;


// Varsinaisen ohjelman suoritus alkaa.

Tulostaja tulostaja = new Tulostaja();
Lukija lukija = new Lukija();
CsvTiedosto csv = new CsvTiedosto();


const string tallennusSijainti = @"C:\\Temp\";
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