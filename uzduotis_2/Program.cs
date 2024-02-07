/* Skaidre 2
 * uzdavinys 5 ir 6
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uzduotis_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string line = "****", space = "  ";
            Console.Write($"{line}\n*{space}*\n" +
                $"*{space}*\n{line}\n");

            string marke = "VW", modelis = "GOLF";
            int metai = 2013, rida = 300000;
            Console.WriteLine($"Automobilio {marke} {modelis} ({metai} m.) " +
                $"rida- {rida} km.");
        }   
    }
}
