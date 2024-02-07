using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024_02_01_patikrinimas
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
                    skaiciuKaras();
                    break;
                case "2":
                    surikiuotas();
                    break;
                case "3":
                    testukas();
                    break;
                case "4":

                    break;
                case "0":
                    closeProgram();
                    break;
                default:
                    Console.WriteLine("Tokio pasirinkimo nera.");
                    break;
            }
        }
        public static void testukas()
        {
            int a = 5;
            double b = 1.22;    
            b = a;
        }
        private static void skaiciuKaras()
        {
            int a, b, nul, vGalia, nuliai, vienetai, vienetuGalia, nuliuGalia, nGalia;

            Console.Write("Iveskite kintamaji a: ");
            a = Int32.Parse(Console.ReadLine());
            Console.Write("Iveskite kintamaji b: ");
            b = Int32.Parse(Console.ReadLine());
            Console.Write("Iveskite kintamaji nul: ");
            nul = Int32.Parse(Console.ReadLine());

            nuliuGalia = b;
            nuliai = nul;
            vienetuGalia = 2 * nuliuGalia;
            vienetai = a - nuliai;

            vGalia = vienetai * vienetuGalia;
            nGalia = nuliai * nuliuGalia;

            Console.WriteLine("Vienetu galia: " + vGalia);
            Console.WriteLine("Laimes " + kasLaimes(vGalia, nGalia)) ;
        }
        private static void surikiuotas()
        {
            Console.Write("Iveskite saraso duomenis: ");

            string[] inputArray = Console.ReadLine().Split(' ');

            int el = 2;
            Boolean ordered = true;
            while ((el < inputArray.Length ) & ordered)
            {
                if (Int32.Parse(inputArray[el]) < Int32.Parse(inputArray[el - 1]))
                    ordered = false;
                else
                    el++;
            }

            Console.WriteLine("Masyvas " + (ordered ? "surikiuotas" : "nesurikiuotas"));
        }
        private static string kasLaimes(int vienetai, int nuliai)
        {
            if (vienetai > nuliai)
                return "VIENETAI";
            else if (nuliai > vienetai)
                return "NULIAI";
            else
                return "NIEKAS";
        }
        private static void closeProgram()
        {
            Console.WriteLine("Bye bye...\n");
            Environment.Exit(0);
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
            Console.WriteLine("1. Skaiciu karas");
            Console.WriteLine("2. Surikiuotas");
            //Console.WriteLine("3. ");
            //Console.WriteLine("4. ");
            //Console.WriteLine("5. ");
            Console.WriteLine();
            Console.WriteLine("0. Baigti programa");

            Console.Write("\nJusu pasirinkimas: ");

            uzdavinys = Console.ReadLine();
            Console.WriteLine("---------------------------");
            return uzdavinys;
        }
    }
}

