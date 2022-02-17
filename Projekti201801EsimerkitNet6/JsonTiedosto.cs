using Newtonsoft.Json;

namespace Projekti201801EsimerkitNet6
{
    public class JsonTiedosto
    {
        public List<Tuote> LueTuotteetTiedostosta(string tiedostopolkuTuotelista)
        {
            string jsonMerkkijono = File.ReadAllText(tiedostopolkuTuotelista);

            List<Tuote> tuotteet = JsonConvert.DeserializeObject<List<Tuote>>(jsonMerkkijono);

            return tuotteet;
        }

        public void KirjoitaTiedostoon(string tiedostopolkuTilaus, Tuote valittuTuote)
        {
            string jsonKaikkiTilaukset = File.ReadAllText(tiedostopolkuTilaus);
            List<Tuote> tilaukset = JsonConvert.DeserializeObject<List<Tuote>>(jsonKaikkiTilaukset);

            tilaukset.Add(valittuTuote);

            string jsonUudetTilaukset = JsonConvert.SerializeObject(tilaukset);

            File.WriteAllText(tiedostopolkuTilaus, jsonUudetTilaukset);
        }
    }
}
