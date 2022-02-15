using System;
namespace Projekti201801Esimerkit
{
    public class Lukija
    {
        public Lukija()
        {
        }

        public int PyydaNumero() {
            int saatuSyote = Int32.Parse(Console.ReadLine());

            return saatuSyote;
        }

    }
}
