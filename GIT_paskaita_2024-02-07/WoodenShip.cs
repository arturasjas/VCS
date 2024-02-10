using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIT_paskaita_2024_02_07
{
    internal class WoodenShip : ModelShip
    {
        public Boolean IsPrecut { get; set; }
        public Boolean Floats { get; set; } 
        public Boolean HasSails {  get; set; }

        public WoodenShip(string name, int length, int height, int year, Boolean precut, Boolean floats, Boolean sails) : base(name, length, height, year) { 
            IsPrecut = precut;
            Floats = floats;
            HasSails = sails;
        }

        public WoodenShip() : base()
        {
            IsPrecut = true;
            Floats = false;
            HasSails = true;
        }
        override public string ToString()
        {
            return "Pavadinimas: " + Name + " (" + Length + "x" + Height + ") " + HistoricYear + " m. (" + (IsPrecut ? "pjaustytos detales;" : "") + (HasSails ? "yra bures;" : "") + (Floats ? "gali plaukti;" : "")+")";
        }
    }
}
