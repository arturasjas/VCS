using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIT_paskaita_2024_02_07
{
    internal class PlasticShip : ModelShip
    {
        public Boolean IsRC {  get; set; }
        public Boolean IsPrepainted { get; set; }
        public Boolean HasStickers {  get; set; }
        public PlasticShip(string name, int length, int height, int year, Boolean RC, Boolean painted, Boolean stickers) : base(name,length,height,year) { 
            IsRC = RC;
            IsPrepainted = painted;
            HasStickers = stickers;
        }

        public PlasticShip() : base()
        {
            IsRC = false;
            IsPrepainted = true;
            HasStickers = true;
        }

        override public string ToString()
        {
            return "Pavadinimas: " + Name + " (" + Length + "x" + Height + ") " + HistoricYear + " m. (" + (HasStickers ? "lipdukai;" : "") + (IsPrepainted ? "dazytas;" : "") + (IsRC ? "RC valdymas;":"") + ")";
        }
    }
}
