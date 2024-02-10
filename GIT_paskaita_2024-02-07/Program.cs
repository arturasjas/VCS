using System;
using CSharpVitamins;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace GIT_paskaita_2024_02_07
{
    internal class Program
    {
        const int CLOSE = 0;

        const int WOODEN = 1;
        const int PLASTIC = 2;

        const int INSERT = 1;
        const int LIST = 2;

        const int UPDATE = 1;
        const int DELETE = 2;

        private static List<PlasticShip> plasticShips = new List<PlasticShip>();
        private static List<WoodenShip> woodenShips = new List<WoodenShip>();

        private static string[] levelHeader = { "", "", "" };

        private static List<Tuple<int, string>> shipMenu;
        private static List<Tuple<int, ShortGuid>> shipIds;

        private static List<Tuple<int, string>> CRUDmenu = new List<Tuple<int, string>>{
            Tuple.Create( CLOSE, "## Uzdaryti programa"),
            Tuple.Create( INSERT, "Itraukti nauja irasa" ),
            Tuple.Create( LIST, "Spausdinti sarasa" ) };


        private static List<Tuple<int, string>> shipType = new List<Tuple<int, string>>{
            Tuple.Create( CLOSE, "## Uzdaryti programa"),
            Tuple.Create( WOODEN, "Mediniai laivai" ),
            Tuple.Create( PLASTIC, "Plastikiniai laivai" )
             };

        private static List<Tuple<int, string>> updateMenu = new List<Tuple<int, string>>{
            Tuple.Create( CLOSE, "## Uzdaryti programa"),
            Tuple.Create( UPDATE, "Redaguoti" ),
            Tuple.Create( DELETE, "Istrinti" )
             };

        static void Main(string[] args)
        {
            addDemoData();
            int selection = showMenu(shipType,0).Item1;
            
            if (selection == CLOSE)
                closeProgram();
            else
                shipCRUD(selection);
        }

        private static void addDemoData()
        {
            woodenShips.Add(new WoodenShip("MedinisLaivas1", 45, 38, 1984, true, true, false));
            woodenShips.Add(new WoodenShip("MedinisLaivas2", 145, 28, 1688, true, false, false));
            woodenShips.Add(new WoodenShip("MedinisLaivas3", 425, 45, 1756, true, true, true));
            woodenShips.Add(new WoodenShip("MedinisLaivas4", 15, 37, 1454, true, true, false));
            
            plasticShips.Add(new PlasticShip("PlastikinisLaivas1", 145, 78, 1995, true, false, true));
            plasticShips.Add(new PlasticShip("PlastikinisLaivas2", 15, 93, 1984, true, false, true));
            plasticShips.Add(new PlasticShip("PlastikinisLaivas3", 175, 21, 1973, true, true, true));
            plasticShips.Add(new PlasticShip("PlastikinisLaivas4", 165, 35, 1866, true, false, true));
            plasticShips.Add(new PlasticShip("PlastikinisLaivas5", 125, 74, 1997, false, false, true));

            Console.WriteLine("\nDemo data added:\n");
            foreach (var ship in plasticShips)
            {
                Console.WriteLine(ship);
            }
            foreach (var ship in woodenShips)
            {
                Console.WriteLine(ship);
            }
            Console.ReadLine();
        }
            private static void shipCRUD(int shipType)
        {
            int selection = showMenu(CRUDmenu, 1).Item1;
            while (true)
            {
                printHeader();
                switch (selection)
                {
                    case INSERT:
                        insertNewRecord(shipType);
                        selection = showMenu(CRUDmenu, 1).Item1;
                        break;
                    case LIST:
                        listRecords(shipType);
                        selection = showMenu(CRUDmenu, 1).Item1;
                        break;
                    case CLOSE:
                        closeProgram();
                        break;
                }
            }
        }

        private static void insertNewRecord(int shipType)
        {
            Console.Write("Pavadinimas:  ");
            string shipName = Console.ReadLine();
            Console.Write("Metai:        ");
            int shipYear = readNumber();
            Console.Write("Ilgi (cm):    ");
            int shipLength = readNumber();
            Console.Write("Aukstis (cm): ");
            int shipHeight = readNumber();
            Boolean precut, floats, sails, RC, prepainted, stickers;

            switch (shipType)
            {
                case WOODEN:
                    Console.Write("Plaukia:      ");
                    floats = readBoolean();
                    Console.Write("Yra bures:    ");
                    sails = readBoolean();
                    Console.Write("Detales supjaustytos: ");
                    precut = readBoolean();

                    woodenShips.Add(new WoodenShip(shipName, shipLength,shipHeight,shipYear,precut,floats,sails));
                    break;
                case PLASTIC:
                    Console.Write("RC valdymas:  ");
                    RC = readBoolean();
                    Console.Write("Dazytas:      ");
                    prepainted = readBoolean();
                    Console.Write("Lipdukai:     ");
                    stickers = readBoolean();
                    plasticShips.Add(new PlasticShip(shipName, shipLength, shipHeight, shipYear,RC,prepainted,stickers));
                    break;
            }
        }

        private static Boolean readBoolean()
        {
            string input = Console.ReadLine();
            while (true)
            {
                if (input.ToLower().Equals("taip"))
                    return true;
                else if (input.ToLower().Equals("ne"))
                    return false;
                {
                    Console.Write("   Irasykite tik 'taip' arba 'ne'.\n   Iveskite reiksme is nuajo arba \n   irasykite 'iseiti' jei norite iseiti is programos: ");
                    input = Console.ReadLine();
                }
                if (input.ToLower().Equals("iseiti"))
                    closeProgram();
            }
        }
        private static int readNumber()
        {
            string input = Console.ReadLine();
            int number;
            while (true) {
                if (int.TryParse(input, out number))
                    return number;
                else
                {
                    Console.Write("   Ivesta reiksme nera skaicius.\n   Iveskite skaiciu arba \n   irasykite 'iseiti' jei norite iseiti is programos: ");
                    input = Console.ReadLine();
                }
                if (input.ToLower().Equals("iseiti"))
                    closeProgram();
            }
        }

        private static void listRecords(int shipType)
        {
            generateShipList(shipType);
            Tuple<int,ShortGuid>shipSelection = showMenu(shipMenu, 2);

            int selection = shipSelection.Item1;
            
            switch (selection)
            {
                case UPDATE:
                    updateRecord(shipType, shipSelection.Item2);
                    break;
                case DELETE:
                    deleteRecord(shipType, shipSelection.Item2);
                    break;
                case CLOSE:
                    closeProgram();
                    break;
            }
        }

        private static void generateShipList(int shipType)
        {
            int sequence = 1;
            shipMenu = new List<Tuple<int, string>> { Tuple.Create(CLOSE, "## Uzdaryti programa") };
            shipIds = new List<Tuple<int, ShortGuid>> { };

            if (shipType == WOODEN)
                foreach (WoodenShip ship in woodenShips)
                {
                    shipMenu.Add(Tuple.Create(sequence, ship.ToString()));
                    shipIds.Add(Tuple.Create(sequence++, ship.Id));
                }
            else
                foreach (PlasticShip ship in plasticShips)
                {
                    shipMenu.Add(Tuple.Create(sequence, ship.ToString()));
                    shipIds.Add(Tuple.Create(sequence++, ship.Id));
                }
        }

        private static void deleteRecord(int shipType, ShortGuid shipId)
        {
            Console.WriteLine("DELETE: " + shipId);
        }

        private static void updateRecord(int shipType, ShortGuid shipId)
        {
            Console.WriteLine("UPDATE: " + shipId);
        }
        private static void closeProgram()
        {
            Console.Clear();
            Console.WriteLine("\nAciu, kad apsilankete!\n");
            Environment.Exit(0);
        }

        private static Tuple<int, ShortGuid> showMenu(List<Tuple<int, string>> selectionList,int level, Boolean getId = false)
        {
            int optionsCount = selectionList.Count;
            int selected = 1;
            bool done = false;
            printHeader();

            while (!done)
            {
                foreach (var select in selectionList)
                {
                    if (selected == select.Item1)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("> ".PadLeft(level * 3));
                    }
                    else
                    {
                        Console.Write("  ".PadLeft(level * 3));
                    }
                    Console.WriteLine(select.Item2);
                    Console.ResetColor();
                }

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        selected = Math.Max(0, selected - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        selected = Math.Min(optionsCount - 1, selected + 1);
                        break;
                    case ConsoleKey.Enter:
                        done = true;
                        break;
                }
                if (!done)
                    Console.CursorTop = Console.CursorTop - optionsCount;
            }
            if (selected != CLOSE)
            {
                levelHeader[level]= "> ".PadLeft(level * 3) + selectionList.Find(selection => selection.Item1 == selected).Item2+"\n";                    
            }

            return Tuple.Create(selected, ShortGuid.Empty);
        }

        private static void printHeader()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(String.Join("", levelHeader.Where(header => !string.IsNullOrEmpty(header))));
            Console.ResetColor();
        }
    }
}
