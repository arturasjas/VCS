/* 
 * Namų darbai
 * Skaidres 1
 * ND1
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace namu_darbai_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string title = "Mano  vardas",
                vardas = "vardas";

            int plotis = 50,
                aukstis = 10;
            double space_title = (plotis - 2 - title.Length)/2,
                space_vardas = (plotis - 2 - vardas.Length)/2;


            string line = new string('-', plotis) + "\n",
                spaces = "|" + new string(' ', plotis - 2) + "|\n",
                tuscia_erdve = string.Concat(System.Linq.Enumerable.Repeat(spaces, aukstis)),
                header = "|" + new string(' ', (int)Math.Ceiling(space_title)) +
                        title + new string(' ', (int)Math.Floor(space_title)) + "|\n",
                name_line = "|" + new string(' ', (int)Math.Ceiling(space_vardas)) +
                        vardas + new string(' ', (int)Math.Floor(space_vardas)) + "|";

            Console.Write(line + tuscia_erdve);
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine(header + name_line);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(tuscia_erdve+line);
        }
    }
}
