// Ohjelman pääluokka, ns. pääohjelma, josta kaikki toiminnallisuus
// alkaa.
using Microsoft.Extensions.Configuration;
using Projekti201801EsimerkitNet6;

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("OhjelmanAsetukset.json")
    .AddEnvironmentVariables()
    .Build();

OhjelmanAsetukset munAsetukset = config.GetRequiredSection("MunAsetukset").Get<OhjelmanAsetukset>();

Console.WriteLine(munAsetukset.TiedostoPolku);
Console.WriteLine(munAsetukset.Asetus1);

// Varsinaisen ohjelman suoritus alkaa.

Tulostaja tulostaja = new Tulostaja();
Lukija lukija = new Lukija();
CsvTiedosto csv = new CsvTiedosto();


string tallennusSijainti = munAsetukset.TiedostoPolku;
string tiedostopolkuTuotelista = tallennusSijainti + "tuotelista.csv";
string tiedostopolkuTilaus = tallennusSijainti + "tilaus.csv";

List<Tuote> tuotelista = csv.LueTuotteetTiedostosta(tiedostopolkuTuotelista);

tulostaja.TulostaTuoterivinOtsikot();
tulostaja.TulostaTuoterivit(tuotelista);
tulostaja.TulostaTuotteenValintaOhje();

int valittuTunniste = lukija.PyydaNumero();
Tuote valittuTuote = tuotelista[valittuTunniste - 1];


tulostaja.TulostaTuoterivi(valittuTuote);
csv.KirjoitaTiedostoon(tiedostopolkuTilaus, valittuTuote);
// Varsinaisen ohjelman suoritus loppuu.