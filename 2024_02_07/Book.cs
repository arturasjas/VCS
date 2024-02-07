using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024_02_07
{
    internal class Book
    {
        public string Title { get; set; }
        public int Pages { get; set; }
        public int ReleaseYear { get; set; }

        public Book(string title, int pages, int releaseYear)
        {
            Title = title;
            Pages = pages;
            ReleaseYear = releaseYear; 
        }

        public Book()
        {
            Title = "Nenurodyta";
            Pages =  0;
            ReleaseYear = 9999;
        }
    }
}
