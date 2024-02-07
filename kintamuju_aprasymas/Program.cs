using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace kintamuju_aprasymas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string vardas = "Petras", pavarde = "Petrulis";
            int amzius = 45;
            double ugis = 1.58, svoris = 58.5;
            string aukstoji_mokykla = "VU",
                   akademines_grupes_kodas = "AK-G-15";
            int kursas = 2;
            string programos_pavadinimas = "IT sistemu valdymas";
            int kreditu_skaicius = 15;
            bool studijuoja = true;
            char pogrupis = 'b';
            var kazkas = true;

            int pirmas = 5, antras = 10;

            Console.Write($"pirmas yra {pirmas} ir antras yra {antras}");
        }
    }
}
