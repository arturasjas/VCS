using CSharpVitamins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GIT_paskaita_2024_02_07
{
    internal class ModelShip
    {
        public ShortGuid Id {  get; }
        public int Length {  get; set; }
        public int Height {  get; set; }
        public string Name { get; set; }
        public int HistoricYear { get; set; }
        public Boolean CanEdit {  get; set; }

        public ModelShip(string name, int length, int height, int year)
        {
            Id = ShortGuid.NewGuid();
            CanEdit = true;
            Name = name;
            Length = length;
            Height = height;
            HistoricYear = year;
        }

        public ModelShip() {
            CanEdit = true;
            Id = ShortGuid.NewGuid();
            Name = "N/A";
            Length = 0;
            Height = 0;
            HistoricYear = 0;
        }
    }
}
