using System;
using System.Collections.Generic;

namespace Projekti201801Esimerkit
{
    public class CsvTiedosto
    {
        public CsvTiedosto()
        {
        }

        public void KirjoitaTiedostoon(string tiedostopolkuTilaus, Tuote valittuTuote)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(tiedostopolkuTilaus, true))
            {
                string csvRivi = this.MuodostaTuotteestaCsvRivi(valittuTuote);
                file.WriteLine(csvRivi);
            }
        }

        public List<Tuote> LueTuotteetTiedostosta(string tiedostopolkuTuotelista)
        {
            List<Tuote> tuotelista = new List<Tuote>();
            
            string[] csvTuoterivit = System.IO.File.ReadAllLines(tiedostopolkuTuotelista);
            
            foreach (string rivi in csvTuoterivit)
            {
                Tuote tuote = LuoTuoteCsvRivista(rivi);
                tuotelista.Add(tuote);
            }
            
            return tuotelista;
        }

        private string MuodostaTuotteestaCsvRivi(Tuote valittuTuote)
        {
            return $"{valittuTuote.Tuotenumero};{valittuTuote.Tuotenimi};{valittuTuote.Hinta};{valittuTuote.Alv}";
        }


        private Tuote LuoTuoteCsvRivista(string rivi)
        {
            // Luokista on luotu olioita.
            string[] pilkottuRivi = rivi.Split(';');
            Tuote tuote = new Tuote();
            tuote.Tuotenumero = Int32.Parse(pilkottuRivi[0]);
            tuote.Tuotenimi = pilkottuRivi[1];
            tuote.Hinta = Double.Parse(pilkottuRivi[2]);
            tuote.Alv = Double.Parse(pilkottuRivi[3]);

            return tuote;
        }
    }
}
