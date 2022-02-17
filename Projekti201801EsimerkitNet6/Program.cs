// Ohjelman pääluokka, ns. pääohjelma, josta kaikki toiminnallisuus
// alkaa.
using Microsoft.Extensions.Configuration;
using Projekti201801EsimerkitNet6;

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("OhjelmanAsetukset.json")
    .AddEnvironmentVariables()
    .Build();

OhjelmanAsetukset munAsetukset = config.GetRequiredSection("MunAsetukset").Get<OhjelmanAsetukset>();

// Varsinaisen ohjelman suoritus alkaa.

Tulostaja tulostaja = new Tulostaja();
Lukija lukija = new Lukija();
CsvTiedosto csv = new CsvTiedosto();
JsonTiedosto jsonTiedosto = new JsonTiedosto();


string tallennusSijainti = munAsetukset.TiedostoPolku;
string tiedostopolkuTuotelista = tallennusSijainti + "tuotelista.json";
string tiedostopolkuTilaus = tallennusSijainti + "tilaus.json";

//List<Tuote> tuotelista = csv.LueTuotteetTiedostosta(tiedostopolkuTuotelista);
List<Tuote> tuotelista = jsonTiedosto.LueTuotteetTiedostosta(tiedostopolkuTuotelista);

tulostaja.TulostaTuoterivinOtsikot();
tulostaja.TulostaTuoterivit(tuotelista);
tulostaja.TulostaTuotteenValintaOhje();

int valittuTunniste = lukija.PyydaNumero();
//Tuote valittuTuote = tuotelista[valittuTunniste - 1];
Tuote valittuTuote = tuotelista.FirstOrDefault(tuote => tuote.Tuotenumero == valittuTunniste);


tulostaja.TulostaTuoterivi(valittuTuote);

//csv.KirjoitaTiedostoon(tiedostopolkuTilaus, valittuTuote);
jsonTiedosto.KirjoitaTiedostoon(tiedostopolkuTilaus, valittuTuote);

// Varsinaisen ohjelman suoritus loppuu.