using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using marvertus_zadaca_3.Composite_Raspored;

namespace marvertus_zadaca_3.Chain
{
    class PrviLink:Handler
    {
        public override string HandleRequest(EmisijaRasporeda request)
        {
            string povratna = "prvi";
            if (request.UnikatniID%5==0)
            {
                povratna = (request.IspisiMVC()+ "PRVI");
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
