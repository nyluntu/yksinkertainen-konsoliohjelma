using System;
using System.Collections.Generic;
using System.Linq;

namespace Projekti201801Esimerkit
{
    public class Tulostaja
    {
        public Tulostaja()
        {
        }


        public void TulostaTuoterivinOtsikot() {
            Console.WriteLine("Tunniste\tTuotenumero\tNimi\t\tHinta");
        }

        public void TulostaTuoterivi(Tuote tuote)
        {
            string tuloste = $"{tuote.Tuotenumero}\t\t{tuote.Tuotenimi}\t\t\t{tuote.Hinta}";
            
            // Näytä tuloste.
            Console.WriteLine(tuloste);
        }

        public void TulostaTuoterivi(int tunniste, Tuote tuote) {
            // Muodostetaan haluttu tuloste.
            tunniste = tunniste + 1;
            string tuloste = $"{tunniste}\t{tuote.Tuotenumero}\t\t{tuote.Tuotenimi}\t\t\t{tuote.Hinta}";

            // Näytä tuloste.
            Console.WriteLine(tuloste);
        }

        public void TulostaTuoterivit(List<Tuote> tuotelista) {
            
            for (int i = 0; i < tuotelista.Count(); i++)
            {
                // haetaan listasta tuote.
                Tuote listallaOlevaTuote = tuotelista[i];
                this.TulostaTuoterivi(i, listallaOlevaTuote);
            }
            
        }

        public void TulostaTuotteenValintaOhje() {
            Console.WriteLine("Anna haluamasi tuotteen tunniste.");
        }



    }
}
