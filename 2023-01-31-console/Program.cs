using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _2023_01_31_console
{
    public class Objektukas
    {
        public int kintamasis { get; set; }

        public Objektukas() { 
            Console.WriteLine("Labas rytas");
        }
        public void Spausdink()
        {
            kintamasis = 5;
            Console.WriteLine("Hellow");
        }
    }

    public class Gyvunas
    {
        public string rusis { get; set; }
        protected int kojos { get; set; }
        public int amzius { get; set; }
        protected Boolean vegetaras { get; set; }
        private const Boolean egzistuoja = true;

        public Gyvunas(string rusis, int kojos, int amzius, Boolean vegetaras)
        {
            this.rusis = rusis;
            this.kojos = kojos;
            this.amzius = amzius;
            this.vegetaras = vegetaras;
        }

        public virtual void apibudink() {
            Console.WriteLine($"{rusis} yra gyvunas su {kojos} kojomis. Ji yra {amzius} m. amziaus ({vegetaras})");
        }   

        public virtual void skleiskGarsa()
        {
            Console.Write("Gyvunas skleidzia garsa: ");
        }
        protected void arEgizstuoja()
        {
            Console.WriteLine("Gyvunas egzistuoja: " + egzistuoja);
        }
    }

    public class Gyvate : Gyvunas
    {
    
        public int ilgis { get; set; }
        public Gyvate(string rusis, int kojos, int amzius, Boolean vegetaras, int ilgis) : base(rusis, kojos, amzius, vegetaras)
        {
            this.ilgis = ilgis;
        }

        public override void apibudink()
        {
            Console.WriteLine($"{rusis} yra gyvate. Ji yra {amzius} m. amziaus vegetaras ({vegetaras}). Jos ilgis - {ilgis} m.");
        }

        public override void skleiskGarsa()
        {
            base.skleiskGarsa();
            Console.WriteLine("SSSSsssSSS");
        }

        public void arTikras()
        {
            base.arEgizstuoja();
        }
    }

    internal class Program
    {
        public static void paveldejimai()
        {
            Gyvunas varle = new Gyvunas("vargliagyvis", 4, 2, false);
            varle.apibudink();
            Gyvate givaciokas = new Gyvate("pitonas", 0, 10, false, 5);
            givaciokas.apibudink();
            givaciokas.skleiskGarsa();
            givaciokas.arTikras();
        }
        public static void klases()
        {
            Objektukas objektas = new Objektukas();
            objektas.Spausdink();
        }
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
                    klases();
                    break;
                case "2":
                    paveldejimai();
                    break;
                case "3":
                    islaidos();
                    break;
                case "4":
                    laimingiSkaiciai();
                    break;
                case "0":
                    closeProgram();
                    break;
                default:
                    Console.WriteLine("Tokio pasirinkimo nera.");
                    break;
            }
        }
        private static void islaidos()
        {
            double iplaukos;
            string suma;
            List<double> islaidos = new List<double>();
            StreamReader input = new StreamReader("D:\\islaidos.txt");
            StreamWriter output = new StreamWriter("D:\\ataskaita.txt");

            iplaukos = Convert.ToDouble(input.ReadLine());
            Console.WriteLine("Iplaukos: " + iplaukos);
            Console.WriteLine("--------------------------");

            while ((suma = input.ReadLine()) != null)
            {
                Console.WriteLine("Islaidos:  " + suma);
                if(double.TryParse(suma, out double skaicius)){
                    islaidos.Add(skaicius);
                } 
                
            }
            input.Close();

            Console.WriteLine("--------------------------");
            output.WriteLine(likoDienpinigiu(iplaukos, islaidos));
            output.WriteLine(statistika(islaidos, "max"));
            output.WriteLine(statistika(islaidos, "vidurkis"));

            output.Close();
        }

        private static void laimingiSkaiciai()
        {
            string[] visiSkaiciai = Enumerable.Range(1, 100).Select(n => n.ToString()).ToArray();
            StreamReader input = new StreamReader("D:\\burimas.txt");
            StreamWriter output = new StreamWriter("D:\\laimejimai.txt");

            string[] burtai = input.ReadLine().Split(' ');

            //for(int i = 0;i < burtai.Length; i = i+2)
            //{
            //    int skaitmuo = Int32.Parse(burtai[i]);
            //    int pasikartojimas = Int32.Parse(burtai[i + 1]);

            //    int counter = 0;
            //    for(int j = 0;j < visiSkaiciai.Length; j++)
            //    {
            //        if( == .Split(skaitmuo.ToString()).Length - 1

            //    }
                
            // mastymas geras, bet norejau per daug abstrakciai padaryti.    
            //}

            
            Console.WriteLine("Burtai:  " + burtai[0]);
        }

        private static double likoDienpinigiu(double gavo, List<double> isleido)
        {
            double liko;
            Console.WriteLine("Liko dienpinigiu:     " + (liko = Math.Round(gavo - statistika(isleido, "suma"), 2)));
            return liko;
        }

        private static double statistika(List<double> isleido, string kaSkaicuojam)
        {
            double skaiciuotuvas = 0;
            switch (kaSkaicuojam)
            {
                case "suma":
                    Console.WriteLine("Viso islaidu:         " + (skaiciuotuvas = isleido.Sum()));
                    break;
                case "max":
                    Console.WriteLine("Didziausios islaidos: " + (skaiciuotuvas = isleido.Max()));
                    break;
                case "vidurkis":
                    Console.WriteLine("Islaidu vidurkis:     " + (skaiciuotuvas = Math.Round(isleido.Average(), 2)));
                    break;
                default:
                    break;
            }
            return skaiciuotuvas;
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
            Console.WriteLine("1. Klases intro");
            Console.WriteLine("2. Paveldejimai");
            Console.WriteLine("3. Islaidos");
            Console.WriteLine("4. Laimingi skaiciai");
            Console.WriteLine();
            Console.WriteLine("0. Baigti programa");

            Console.Write("\nJusu pasirinkimas: ");

            uzdavinys = Console.ReadLine();
            Console.WriteLine("---------------------------");
            return uzdavinys;
        }
    }
}
