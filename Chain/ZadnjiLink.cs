using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using marvertus_zadaca_3.Composite_Raspored;

namespace marvertus_zadaca_3.Chain
{
    class ZadnjiLink : Handler
    {
        public override string HandleRequest(EmisijaRasporeda request)
        {
            string povratna = "Unlucky(Kraj lanca)";
            return povratna;
        }
    }
}
