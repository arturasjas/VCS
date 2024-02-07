using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Sukurti klasę Book.
//Properties: title, pages, releaseYear
//visi properties turi get; set;
//sukurti 3 objektus su reikšmėmis naudojantis tuščiu konstruktoriu, ir tris naudojantis pilnu konstuktoriu.
//sudėti juos į knygų masyvą.
//prasukti ciklą per masyvą ir atspausdinti knygas (naudojam getterius)
//----------------------------
//Sukurti klasę Plant
//Visi laukai turi turėti getterius ir setterius. 

//------------------------
//RAŠOM RANKA PATYS!
//________________

//Klasės laukai:
//Pavadinimas
//lotyniskas pavadinimas
//boolean vienmetis
//kokiam zemyne auga
//suaugusio augalo aukstis metrais. 
//ar valgomas?

//Program.cs susikuriam masyvą saugoti augalams. sukuriame 2 augalus su tuščiu, ir 2 su pilnu konsturktorium.

//prasukti ciklą ir atspausdinti augalus (naudoti toString metodą)

namespace _2024_02_07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>();

            books.Add(new Book());
            books.Add(new Book());
            books.Add(new Book());
            books.Add(new Book("Pepe ilgakojine", 215, 2005));
            books.Add(new Book("Tarzanas", 200, 1997));
            books.Add(new Book("Delfinas", 145, 2021));

            foreach (var book in books)
            {
                Console.WriteLine($"Knyga {book.Title} išleista {book.ReleaseYear} metais ir turi {book.Pages} puslapių");
            }

            Console.WriteLine("----------------------");
            List<Plant> augaliukai = new List<Plant>();
            augaliukai.Add(new Plant());
            augaliukai.Add(new Plant());
            augaliukai.Add(new Plant("Lijana","Lianum",false,"Afrika",1.789,false));
            augaliukai.Add(new Plant("Gelyte","Bellum Lucerum",true,"Azija",0.1231, true));
            foreach (var augaliukas in augaliukai)
            {
                Console.WriteLine(augaliukas);
            }

        }
    }
}
