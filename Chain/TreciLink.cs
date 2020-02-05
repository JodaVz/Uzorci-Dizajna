using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using marvertus_zadaca_3.Composite_Raspored;

namespace marvertus_zadaca_3.Chain
{
    class TreciLink:Handler
    {
        public override string HandleRequest(EmisijaRasporeda request)
        {
            string povratna = "treci";
            if (request.UnikatniID % 5 == 2)
            {
                povratna = (request.IspisiMVC() + "TRECI");
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
