using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using marvertus_zadaca_3.Composite;
using marvertus_zadaca_3.Memento;

namespace marvertus_zadaca_3.Modeli
{
    [Serializable]
    public  class TvKuca
    {
        private TvKuca() { }
        public static TvKuca Instance { get; } = new TvKuca();
        public List<TvProgram> TvProgrami { get; set; } = new List<TvProgram>();

        //Memento
        public TvKucaMemento SpremiRaspored(List<TvProgram> lista)
        {
            Console.WriteLine("Spremam trenutni raspored");
            return new TvKucaMemento(new List<TvProgram>(lista).ToList());
        }

        public void VratiRaspored(TvKucaMemento memento)
        {
            Console.WriteLine("Vraćam na prethodnu verziju");
            TvProgrami = memento.TvProgrami;
        }
    }
}
