//1. Programa pasisveikina
//2. Programa pasako amziu
//3. Penki skaiciai be tarpu
//4. Penki skaiciai su tarpais
// ----------------------
// uzduotis 1, skaidre 63


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uzduotis_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string vardas = "Artūrai";
            Console.WriteLine("Labas " + vardas);

            int amzius = 45;
            Console.WriteLine($"Ivestas amzius: {amzius}.");

            int skaicius = 25;
            Console.WriteLine(skaicius + "" +
                              skaicius + "" + skaicius + "" +
                              skaicius + "" + skaicius);

            for(int i = 0; i < 5; i++)
            {
                Console.Write(skaicius);
                if (i == 4)
                {
                    Console.WriteLine();
                }
            }

            Console.WriteLine(string.Concat(Enumerable.Repeat(skaicius,28)));

            Console.WriteLine($"{skaicius} {skaicius} + " +
                   $"{skaicius} {skaicius} {skaicius}");

        }

    }
}
