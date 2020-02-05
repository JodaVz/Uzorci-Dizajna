using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marvertus_zadaca_3.Memento
{
    public class TvKucaMemory
    {
        private TvKucaMemento _memento;

        public TvKucaMemento Memento
        {
            set { _memento = value; }
            get { return _memento; }
        }
    }
}
