using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marvertus_zadaca_3.Decorator
{
    class ConcreteDecoratorPrihoda:Decorator
    {
        public ConcreteDecoratorPrihoda(DComponent comp) : base(comp)
        {
        }

        public override string Ispis(string text)
        {
            string konacniString = "_________________________________\n";
            string suma= text.Split(';')[1];
            string trenutna = text.Split(';')[0];
            konacniString += string.Format("{0,-6}", "Reklame emisije");
            konacniString += "|";
            konacniString += string.Format("{0,-3}", trenutna);
            konacniString += "|";
            konacniString += string.Format("{0,-7}", "Ukupna suma");
            konacniString += "|";
            konacniString += string.Format("{0,-3}", suma);
            konacniString += "|";
            return konacniString;

        }
        
    }
}
