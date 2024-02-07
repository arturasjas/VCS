using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024_02_07
{
    internal class Plant
    {
        const string NA = "N/A";
        string Name { get; set; }
        string LatinName {  get; set; }
        Boolean OneYear {  get; set; }
        String Continent{ get; set; }
        double Height { get; set; }
        Boolean Edible { get; set; }
        
        public override string ToString()
        {
            return $"{Name} ({LatinName}) yra " + (OneYear ? "vienmetis ":" ") + $"augalas, augantis {Continent} zemyne ({Height} m. aukscio)." + (Edible ? " Gali drasiai jo paragauti" : "Tik nemegink jo valgyti!");
        }
        public Plant() {
            Name = NA;
            LatinName = NA;
            OneYear = false;
            Continent = NA;
            Height = 0;
            Edible = false;
        }

        public Plant(string name, string latinName, Boolean oneYear, String continent, double height, Boolean edible) { 
            Name = name;
            LatinName = latinName;
            OneYear = oneYear;
            Continent = continent;
            Height = Math.Round(height,2);
            Edible = edible;
        }

    }
}
