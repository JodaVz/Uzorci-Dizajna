using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using marvertus_zadaca_3.Modeli;
using marvertus_zadaca_3.Composite;

namespace marvertus_zadaca_3.Memento
{
    public class TvKucaMemento
    {
        public DateTime DatumPohrane { get; set; }
        public int IdPohrane { get; set; }
        public List<TvProgram> TvProgrami { get; } = new List<TvProgram>();

        public TvKucaMemento(List<TvProgram> tvProgrami)
        {
            TvProgrami = tvProgrami;
            DatumPohrane = DateTime.Parse(DateTime.Now.ToShortTimeString());
        }
    }
}
