using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using marvertus_zadaca_3.Composite_Raspored;

namespace marvertus_zadaca_3.Chain
{
    abstract class Handler

    {
        protected Handler successor;

        public void SetSuccessor(Handler successor)
        {
            this.successor = successor;
        }

        public abstract string HandleRequest(EmisijaRasporeda request);
    }
}
