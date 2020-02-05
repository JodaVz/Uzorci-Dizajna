using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using marvertus_zadaca_3.Composite_Raspored;

namespace marvertus_zadaca_3.Chain
{
    class DrugiLink : Handler
    {
        public override string HandleRequest(EmisijaRasporeda request)
        {
            string povratna = "drugi";
            if (request.UnikatniID % 5 == 1)
            {
                povratna = (request.IspisiMVC() + "DRUGI");
                return povratna;

            }
            else if (successor != null)
            {

                successor.HandleRequest(request);
                povratna = successor.HandleRequest(request);
            }

            return povratna;

        }
    }
}
