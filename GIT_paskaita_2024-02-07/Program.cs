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

        private static string[] levelHeader = { "", "", "", "" };

        private static List<Tuple<int, string, ShortGuid>> shipMenu;

        private static List<Tuple<int, string, ShortGuid>> mainMenuList = new List<Tuple<int, string, ShortGuid>>{
            Tuple.Create( CLOSE, "## Uzdaryti programa", ShortGuid.Empty),
            Tuple.Create( INSERT, "Itraukti nauja irasa" , ShortGuid.Empty),
            Tuple.Create( LIST, "Spausdinti sarasa" , ShortGuid.Empty) };


        private static List<Tuple<int, string, ShortGuid>> shipType = new List<Tuple<int, string, ShortGuid>>{
            Tuple.Create( CLOSE, "## Uzdaryti programa", ShortGuid.Empty),
            Tuple.Create( WOODEN, "Mediniai laivai" , ShortGuid.Empty),
            Tuple.Create( PLASTIC, "Plastikiniai laivai", ShortGuid.Empty)
             };

        private static List<Tuple<int, string, ShortGuid>> updateMenu = new List<Tuple<int, string, ShortGuid>>{
            Tuple.Create( CLOSE, "## Uzdaryti programa", ShortGuid.Empty),
            Tuple.Create( UPDATE, "Redaguoti" , ShortGuid.Empty),
            Tuple.Create( DELETE, "Istrinti" , ShortGuid.Empty)
             };

        static void Main(string[] args)
        {
            addDemoData();
            int selection = showMenu(shipType,0).Item1;
            
            if (selection == CLOSE)
                closeProgram();
            else
                showMainMenu(selection);
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
        private static void showMainMenu(int shipType)
        {
            int selection = showMenu(mainMenuList, 1).Item1;
            while (true)
            {
                printHeader();
                switch (selection)
                {
                    case INSERT:
                        insertNewRecord(shipType);
                        selection = showMenu(mainMenuList, 1).Item1;
                        break;
                    case LIST:
                        listRecords(shipType);
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
            
            if (shipSelection.Item1 == CLOSE){
                closeProgram();
            }
            
            switch (showMenu(updateMenu, 3).Item1)
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
            shipMenu = new List<Tuple<int, string, ShortGuid>> { Tuple.Create(CLOSE, "## Uzdaryti programa",ShortGuid.Empty) };

            if (shipType == WOODEN)
                foreach (WoodenShip ship in woodenShips)
                {
                    shipMenu.Add(Tuple.Create(sequence++, ship.ToString(),ship.Id));
                }
            else
                foreach (PlasticShip ship in plasticShips)
                {
                    shipMenu.Add(Tuple.Create(sequence++, ship.ToString(), ship.Id));
                }
        }

        private static void deleteRecord(int shipType, ShortGuid shipId)
        {
            Boolean canDelete = true;

            if (shipType == WOODEN && !woodenShips.Find(ship => ship.Id.Equals(shipId)).CanEdit)
                canDelete = false;
            if (shipType == PLASTIC && !plasticShips.Find(ship => ship.Id.Equals(shipId)).CanEdit)
                canDelete = false;

            if (!canDelete)
                Console.WriteLine(new string(' ',8) + "Trynimas siuo metu negalimas. Bandykite veliau.");
            
            if (shipType == WOODEN)
                woodenShips.RemoveAll(ship => ship.Id.Equals(shipId));
            else
                plasticShips.RemoveAll(ship => ship.Id.Equals(shipId));
            
            Console.WriteLine("\n" + new string(' ', 8) + "Laivas istrintas.");
            Console.ReadLine();
        }

        private static void updateRecord(int shipType, ShortGuid shipId)
        {
            Console.WriteLine("UPDATE: " + shipId);
            Console.ReadLine();
        }
        private static void closeProgram()
        {
            Console.Clear();
            Console.WriteLine("\nAciu, kad apsilankete!\n");
            Environment.Exit(0);
        }

        private static Tuple<int, ShortGuid> showMenu(
            List<Tuple<int, string, ShortGuid>> selectionList,
            int level, 
            Boolean getId = false)
        {
            int optionsCount = selectionList.Count;
            int selected = Math.Min(optionsCount-1,1);
            bool done = false;
            
            levelHeader[level] = string.Empty;
            printHeader();

            while (!done)
            {
                foreach (var select in selectionList)
                {
                    if (selected == select.Item1)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(new string(' ',level * 2) + "> ");
                    }
                    else
                    {
                        Console.Write(new string(' ',(level * 2) + 2));
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
            if (selected != CLOSE & level < 3)
            {
                levelHeader[level]= new string (' ',level * 2)+"> " + selectionList.Find(selection => selection.Item1 == selected).Item2+"\n";                    
            }

            return Tuple.Create(selected, selectionList.Find(ship => ship.Item1 == selected).Item3);
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
