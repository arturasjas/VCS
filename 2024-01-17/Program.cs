using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace _2024_01_17
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string uzdavinys = "";

            while (uzdavinys != "0")
            {
                Console.WriteLine("Pasirinkite uzdavini: ");
                Console.WriteLine("1. Skaiciu eilute");
                Console.WriteLine("2. Skaiciuotuvas");
                Console.WriteLine("3. Trikampis");
                Console.WriteLine("4. Masyvai intro");
                Console.WriteLine("5. Temperaturos");
                Console.WriteLine("6. Pazymiai");
                Console.WriteLine("7. Degalai");
                Console.WriteLine();
                Console.WriteLine("0. Baigti programa");

                Console.Write("\nJusu pasirinkimas: ");

                uzdavinys = Console.ReadLine();
                Console.WriteLine("---------------------------");
                switch (uzdavinys) {
                    case "1":
                        int skaicius = 0;
                        Console.Write("Iveskite skaiciu: ");
                        skaicius = Int32.Parse(Console.ReadLine());

                        while (skaicius != 0)
                        {
                            Console.WriteLine("Skaicius: " + skaicius);
                            if (skaicius > 0)
                            {
                                skaicius--;
                            }
                            else
                            {
                                skaicius++;
                            }
                        }
                        Console.WriteLine("Skaicius: " + skaicius);
                        break;
                    case "2":
                        int skaicius1 = 0, skaicius2 = 0;
                        Console.Write("Iveskite pirma skaiciu: ");
                        skaicius1 = Int32.Parse(Console.ReadLine());
                        Console.Write("Iveskite antra skaiciu: ");
                        skaicius2 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine(skaicius1 + " + " + skaicius2 + " = " + (int)(skaicius1 + skaicius2));
                        Console.WriteLine(skaicius1 + " - " + skaicius2 + " = " + (int)(skaicius1 - skaicius2));
                        Console.WriteLine(skaicius1 + " * " + skaicius2 + " = " + skaicius1 * skaicius2);
                        Console.WriteLine(skaicius1 + " / " + skaicius2 + " = " + Math.Round((double)skaicius1 / skaicius2,2));
                   
                        break;
                    case "3":
                        int statinis1 = 0, statinis2 = 0;
                        Console.Write("Iveskite pirmojo statinio ilgi: ");
                        statinis1 = Int32.Parse(Console.ReadLine());
                        Console.Write("Iveskite antrojo statinio ilgi: ");
                        statinis2 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Izambine: " + Math.Sqrt(Math.Pow(statinis1, 2)+ Math.Pow(statinis2, 2)));
                        break;
                    case "4":
                        
                        int[] pazymiai = new int[10];

                        Console.WriteLine("Kiek bus automobiliu?");
                        int auto = Int32.Parse(Console.ReadLine());
                        string[] automobiliai = new string[auto];

                        automobiliai[0] = "AUDI";
                        automobiliai[1] = "VW";
                        automobiliai[2] = "BMW";
                        automobiliai[3] = "SUBARU";
                        automobiliai[4] = "SKODA";

                        StreamReader failas = new StreamReader("C:\\Users\\artur\\OneDrive\\Desktop\\test.txt");
                        string eilute;
                        int index = 0;
                        while((eilute = failas.ReadLine()) != null)
                        {
                            pazymiai[index++] = Convert.ToInt32(eilute);
                        }
                        failas.Close();

                        foreach (string automobilis in automobiliai.Where(automoto => !string.IsNullOrEmpty(automoto)).ToArray())
                        {
                            if (automobilis != null) {
                                Console.Write("Auto: " + automobilis);
                                Console.WriteLine();
                            }
                        }

                        Console.WriteLine("Automobiliai: " + string.Join(" - ",automobiliai ));
                        Console.WriteLine("Pazymiai: " + string.Join(",", pazymiai));

                        Console.WriteLine("Paskutinis pazymys: " + pazymiai.Last());
                        Console.WriteLine("Pirmas automobilis: " + automobiliai.First());
                        Console.WriteLine("Automobiliu skaicius: " + automobiliai.Length);
                        Console.WriteLine("Automatine suma: " + pazymiai.Sum());
                        Console.WriteLine("Minimalus pazymys: " + pazymiai.Min() );
                        break;
                    case "5":
                        int[] temperaturos = { 10, 5, 6, 6, 1, -2, -15 };
                        Console.WriteLine("Temperaturos: " + string.Join(", ",temperaturos));
                        Console.WriteLine("Zemiausia temperatura: " + temperaturos.Min());
                        Console.WriteLine("Didziausia temperatura: " + temperaturos.Max());
                        Console.WriteLine("Temperaturos vidurkis: " + Math.Round(temperaturos.Average()));
                        int zemiau = 0, auksciau = 0;
                        foreach(int temperatura in temperaturos)
                        {
                            if (temperatura < temperaturos.Average())
                                zemiau++;
                            else if (temperatura > temperaturos.Average())
                                auksciau++;
                        }
                        Console.WriteLine("Zemiau uz virudki: " + zemiau);
                        Console.WriteLine("Auksciau uz vidurki: " + auksciau);
                        break;
                    case "6":
                        int[] ivertinimai = { 10, 5, 6, 6, 0, 4, 2 };
                        Console.WriteLine("Pazymiai: " + string.Join(", ", ivertinimai));
                        Console.WriteLine("Geriausias  pazymys: " + ivertinimai.Max());
                        Console.WriteLine("Pazymiu vidurkis: " + Math.Round(ivertinimai.Average()));
                        int desimtukai = 0, neigiami = 0;
                        foreach (int vertinimas in ivertinimai)
                        {
                            if (vertinimas < 4)
                                neigiami++;
                            else if (vertinimas == 10)
                                desimtukai++;
                        }
                        Console.WriteLine("Neigiami pazymiai: " + neigiami);
                        Console.WriteLine("Desimtukai: " + desimtukai);
                        break;
                    case "7":
                        int[,] statistika = { { 120, 8 }, { 50, 3 }, { 100, 10 }, { 350, 23 } };
                        Console.Write("Statistika:\nkm  - litrai\n");
                        int[] kilometrai = new int[4], degalai = new int[4];
                        for (int i = 0; i < 4; i++)
                        {
                            kilometrai[i] = statistika[i, 0];
                            degalai[i] = statistika[i, 1];

                            Console.WriteLine(statistika[i, 0] + " - " + statistika[i,1]);
                        }

                        Console.WriteLine();
                        Console.WriteLine("Trumpiausia kelione: " + kilometrai.Min());
                        Console.WriteLine("Ilgiausia kelione: " + kilometrai.Max());
                        Console.WriteLine("Kuro sanaudu suma: " + degalai.Sum());
                        Console.WriteLine("Kilometru suma: " + kilometrai.Sum());

                        break;
                    case "0":
                        Console.WriteLine("Bye bye...\n");
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
