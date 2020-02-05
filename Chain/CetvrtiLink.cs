using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using marvertus_zadaca_3.Composite_Raspored;

namespace marvertus_zadaca_3.Chain
{
    class CetvrtiLink:Handler
    {
        public override string HandleRequest(EmisijaRasporeda request)
        {
            string povratna = "cetvrti";
            if (request.UnikatniID % 5 == 3)
            {
                povratna = (request.IspisiMVC() + "CETVRTI");
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
