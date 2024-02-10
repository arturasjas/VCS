using System;
using CSharpVitamins;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIT_paskaita_2024_02_07
{
    internal class Program
    {
        const int WOODEN = 1;
        const int PLASTIC = 2;
        private static List<PlasticShip> plasticShips = new List<PlasticShip>();
        private static List<WoodenShip> woodenShips = new List<WoodenShip>();

        private static List<Tuple<int, string>> CRUDmenu = new List<Tuple<int, string>>{
            Tuple.Create( 1, "Itraukti nauja irasa" ),
            Tuple.Create( 2, "Spausdinti sarasa" ),
            Tuple.Create( 3, "Redaguoti irasa"),
            Tuple.Create( 4, "Istrinti irasa"),
            Tuple.Create( 5, "## Uzdaryti programa") };

        private static List<Tuple<int, string>> shipType = new List<Tuple<int, string>>{
            Tuple.Create( WOODEN, "Mediniai laivai" ),
            Tuple.Create( PLASTIC, "Plastikiniai laivai" ),
            Tuple.Create( 3, "## Uzdaryti programa") };
        static void Main(string[] args)
        {
            int selection = showMenu(shipType);
            switch (selection)
            {
                case 3:
                    closeProgram();
                    break;
                default:
                    shipCRUD(selection);
                    break;
            }
        }

        private static void shipCRUD(int shipType)
        {
            int selection = showMenu(CRUDmenu);

            switch (selection)
            {
                case 1:
                    insertNewRecord(shipType);
                    break;
            }
        }

        private static void insertNewRecord(int shipType)
        {
            switch(shipType){
                case WOODEN:
                    woodenShips.Add(new WoodenShip());
                    break;
                case PLASTIC:
                    plasticShips.Add(new PlasticShip());
                    break;
            }
        }
        private static void closeProgram()
        {
            Console.WriteLine("\nAciu, kad apsilankete!\n");
            Environment.Exit(0);
        }

        private static int showMenu(List<Tuple<int, string>> selectionList)
        {
            int optionsCount = selectionList.Count;
            int selected = 1;
            bool done = false;

            while (!done)
            {
                foreach (var select in selectionList)
                {
                    if (selected == select.Item1)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("> ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                    Console.WriteLine(select.Item2);
                    Console.ResetColor();
                }

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        selected = Math.Max(1, selected-1);
                        break;
                    case ConsoleKey.DownArrow:
                        selected = Math.Min(optionsCount, selected + 1);
                        break;
                    case ConsoleKey.Enter:
                        done = true;
                        break;
                }
                if (!done)
                    Console.CursorTop = Console.CursorTop - optionsCount;
            }
            
            return selected;
        }
    }
}
