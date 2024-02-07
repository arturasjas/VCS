using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aritmetiniai_veiksmai
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("4 + 5 = " + (4 + 5));
            Console.WriteLine("4 - 5 = " + (4 - 5));
            Console.WriteLine("4 * 5 = " + (4*5));
            Console.WriteLine("4 / 5 = " + (double)4 / 5);

            Console.WriteLine("4 ^ 2 = " + Math.Pow(4,2));
            Console.WriteLine("4 ^ 3 = " + Math.Pow(4,2));

            Console.WriteLine("3 * 4 * 5 = " + (3 * 4 * 5));

            Console.WriteLine("------------------------");
            int skaicius = 5;
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{skaicius} * {i} = " + skaicius * i);
            }

            int dvizenklis = 15,
                sk1 = (int)(dvizenklis % 10),
                sk2 = (int)(dvizenklis / 10);
            Console.WriteLine($"{dvizenklis} --- {sk1} * {sk2} = " + sk1 * sk2);

            Console.WriteLine(Convert.ToInt32('5'.ToString()));
        }
    }
}
