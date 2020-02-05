using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marvertus_zadaca_3.Decorator
{
    class ConcreteDecoratorA:Decorator
    {
        public ConcreteDecoratorA(DComponent comp) : base(comp)
        {
        }

        public override string Ispis(string text)
        {
            string konacniString="___________________________________________________________________________\n";
            string id = text.Split(';')[0];
            konacniString += string.Format("{0,-2}", id);
            konacniString += "|";
            string naziv = text.Split(';')[1];
            konacniString += string.Format("{0,-40}", naziv);
            konacniString += "|";
            string pocetak = text.Split(';')[2];
            konacniString += string.Format("{0,-6}", pocetak);
            string kraj = text.Split(';')[3];
            konacniString += "- ";
            konacniString += string.Format("{0,-6}", kraj);
            string opis = text.Split(';')[4];
            konacniString += "|";
            konacniString += string.Format("{0,-15}", opis);
            konacniString += string.Format("{0,-1}", "|");
            string unikatniID = text.Split(';')[5];
            konacniString += string.Format("{0,-2}", unikatniID);
            konacniString += "|";
            string osobeUloge = text.Split(';')[6];
            konacniString += string.Format("{0,-50}", osobeUloge);
            return $"{base.Ispis(konacniString)}";

        }
    }
}
