using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_01_24_CONSOLE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string uzdavinys = "";

            while (uzdavinys != "0")
            {
                uzdavinys = uzdavinioPasirinkimas();
                paleistiUzdavini(uzdavinys);
                closingMessage();
            }
        }

        private static void paleistiUzdavini(string uzdavinys)
        {
            switch (uzdavinys)
            {
                case "1":
                    geriausiaKlase();
                    break;
                case "2":
                    sumaIrDalyba();
                    break;
                case "3":
                    pauksciai();
                    break;
                case "4":
                    ZaluZaidimas();
                    break;
                case "0":
                    closeProgram();
                    break;
                default:
                    Console.WriteLine("Tokio pasirinkimo nera.");
                    break;
            }
        }

        private static void ZaluZaidimas()
        {
            Console.Write("Iveskite žaidėjo role (karys, magas arba lankininkas): ");
            string role = Console.ReadLine();
            Console.Write("Iveskite priešininko gyvybes: ");
            int priesininkoGyvybes = Int32.Parse(Console.ReadLine());

            Console.WriteLine($"{role} suzalojo priesininka ({priesininkoGyvybes}) ir ateme {Math.Round(zalojimas(role, priesininkoGyvybes), 2)} gyvybiu.");
        }

        private static double zalojimas(string role, int priesininkoGyvybes)
        {
            switch (role.ToLower())
            {
                case "karys":
                    return (124 + priesininkoGyvybes / 100 * 7);
                case "magas":
                    if (priesininkoGyvybes >= 2000)
                    {
                        return (240 + 120);
                    }
                    break;
                case "lankininkas":
                    return(3 * 180);
                default:
                    Console.WriteLine("Tokios rolės nėra.");
                    break;
            }
            return 0;
        }

        private static void pauksciai()
        {
            List<int> pauksciai = new List<int>();
            NuskaitytiPaukscius(pauksciai);
            SururiuotiPaukscius(pauksciai);
            SpaustintiAtsakymus(pauksciai);
        }

        private static void SpaustintiAtsakymus(List<int> pauksciai)
        {
            Console.WriteLine("Skirtumas darp didziausio ir maziausio: " + (int)(pauksciai.Max() - pauksciai.Min()));
        }

        private static void SururiuotiPaukscius(List<int> pauksciai)
        {
            pauksciai.Sort();
            pauksciai.Reverse();
        }

        private static void NuskaitytiPaukscius(List<int> pauksciai)
        {
            Console.WriteLine("Iveskite tris ziemojanciu pauksciu kiekius po kiekvieno spasudami ENTER.");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("Ziemojantys pauksciai: ");
                pauksciai.Add(Convert.ToInt32(Console.ReadLine()));
            }
        }

        private static void sumaIrDalyba()
        {
            int a, b, c;
            Console.WriteLine("Iveskite tris skaicius po kiekvieno spausdami ENTER");
            a = Int32.Parse(Console.ReadLine());
            b = Int32.Parse(Console.ReadLine());
            c = Int32.Parse(Console.ReadLine());

            Console.WriteLine($"{a} + {b} + {c} = {Suma(a, b, c)}");
            Console.WriteLine($"{a} / {b} = {(double)dalyba(a, b)}");
        }

        private static double dalyba(int a, int b)
        {
            return Math.Round((double)(a / b));
        }

        private static int Suma(int a, int b, int c)
        {
            return a + b + c;
        }

        private static void closingMessage()
        {
            Console.WriteLine("\nSpauskite ENTER\n");
            Console.ReadLine();
            Console.Clear();
        }

        private static string uzdavinioPasirinkimas()
        {
            string uzdavinys;
            Console.WriteLine("Pasirinkite uzdavini: ");
            Console.WriteLine("1. Geriausia klase");
            Console.WriteLine("2. Suma ir dalyba");
            Console.WriteLine("3. Ziemojantys pauksciai");
            Console.WriteLine("4. Zaidimo zala");
            Console.WriteLine();
            Console.WriteLine("0. Baigti programa");

            Console.Write("\nJusu pasirinkimas: ");

            uzdavinys = Console.ReadLine();
            Console.WriteLine("---------------------------");
            return uzdavinys;
        }

        private static void closeProgram()
        {
            Console.WriteLine("Bye bye...\n");
            Environment.Exit(0);
        }

        private static void geriausiaKlase()
        {
            List<double> vidurkiai = new List<double>();

            Console.WriteLine("Iveskite klasių vidurkius po kiekvieno spasudami ENTER.");
            for (int i = 0; i < 4; i++)
            {
                Console.Write("Vidurkis: ");
                vidurkiai.Add(Convert.ToDouble(Console.ReadLine()));
            }
            double didziausias = vidurkiai.Max();
            vidurkiai.Remove(didziausias);
            Console.WriteLine("Didžiausias vidurkis: " + didziausias);
            Console.Write("Kitu klasiu vidurkiai skiriasi: ");
            foreach (var vidurkis in vidurkiai)
            {
                Console.Write(Math.Abs(vidurkis - didziausias) + " ");
            }
        }
    }
}
