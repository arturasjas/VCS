using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace namu_darbai_2024_01_15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string uzdavinys = "";

            while (uzdavinys != "0") {
                Console.WriteLine("Pasirinkite uzdavini: ");
                Console.WriteLine("4. Skaitmenu suma");
                Console.WriteLine("5. Dvigubas  skaicius");
                Console.WriteLine("6. Olimpines zaidynes");
                Console.WriteLine("7. Teigiamas - neigiamas");
                Console.WriteLine();
                Console.WriteLine("0. Baigti programa");

                Console.Write("\nJusu pasirinkimas: ");

                uzdavinys = Console.ReadLine();
                Console.WriteLine("---------------------------");
                switch (uzdavinys)
                {
                    case "4": {
                            int tr1 = 0, tr2 = 0,
                            suma_tr1 = 0, suma_tr2 = 0;
                            Console.WriteLine("Irasykite du skaicius spausdami ENTER po kiekvieno.");
                            try
                            {
                                tr1 = Int32.Parse(Console.ReadLine());
                                tr2 = Int32.Parse(Console.ReadLine());
                            }
                            catch
                            {
                                Console.WriteLine("Ivedete ne skaicius.");
                                break;
                            }

                            int ilgis_tr1 = tr1.ToString().Length,
                                ilgis_tr2 = tr2.ToString().Length;
                            int skaicius1 = tr1, skaicius2 = tr2;

                            for (int i1 = 0, i2 = 0;
                                i1 < ilgis_tr1 || i2 < ilgis_tr2;
                                i1++, i2++)
                            {
                                int skaitmuo1 = tr1 % 10;
                                int skaitmuo2 = tr2 % 10;

                                suma_tr1 += skaitmuo1;
                                suma_tr2 += skaitmuo2;

                                tr1 = tr1 / 10;
                                tr2 = tr2 / 10;
                            }

                            Console.WriteLine("Skaiciaus " + skaicius1 + " skaitmenu suma yra " + suma_tr1);
                            Console.WriteLine("Skaiciaus " + skaicius2 + " skaitmenu suma yra " + suma_tr2);
                            break;
                        }
                    case "5":
                        {
                            Console.Write("Iveskite skaiciu: ");
                            int skaicius = 0;
                            try
                            {
                                skaicius = Int32.Parse(Console.ReadLine());
                            }
                            catch
                            {
                                Console.WriteLine("Ivestas ne skaicius.");
                                break;
                            };
                            if (skaicius > 10) {
                                Console.WriteLine(skaicius + " * 2 = " + skaicius * 2);
                            }
                            break;
                        }
                    case "6":
                        {
                            int first_game = 1896, step = 4, game_number = 0, year = 0;
                            Console.Write("Iveskite zaidyniu metus: ");
                            try
                            {
                                year = Int32.Parse(Console.ReadLine());
                            }
                            catch
                            {
                                Console.WriteLine("Tokiu metu nebuna");
                                break;
                            }

                            if (year < first_game)
                            {
                                Console.WriteLine(year + " metais olimpines zaidynes dar nevykdavo");
                            } else
                            {
                                for (int current = first_game; current <= year; current++)
                                {
                                    if (current % step == 0)
                                        game_number++;
                                }
                                if (year % step == 0)
                                {
                                    Console.WriteLine(year + " metais vyko " + game_number + "-osios olimpines zaidynes");
                                } else
                                {
                                    Console.WriteLine(year + " metai nera olimpiniai.");
                                }

                            }
                            break;
                        }
                    case "7":
                        {
                            Console.Write("Iveskite skaiciu: ");
                            int skaicius = 0;
                            try
                            {
                                skaicius = Int32.Parse(Console.ReadLine());
                            }
                            catch
                            {
                                Console.WriteLine("Sorry, reikia SKAICIAUS");
                                break;
                            }
                            Console.WriteLine("Skaicius " + skaicius + " yra " +
                                (skaicius < 0 ? "neigiamas" : skaicius > 0 ? "teigiamas" : "0"));
                            break;
                        }
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Tokio pasirinkimo nera.");
                        break;
                }
                Console.WriteLine("\nSpauskite ENTER\n");
                Console.ReadLine();
                Console.Clear();
            }
        }       
    }
}
