using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using marvertus_zadaca_3.Composite;
using marvertus_zadaca_3.Prototype_Emisija;

namespace marvertus_zadaca_3.Memento
{
    public class CompositeMemento
    {
        public   List<Component> _rasporedi = new List<Component>();
        public int Id { get; set; }
        public string ImePrograma { get; set; } = "";
        public DateTime PocetakPrograma { get; set; }
        public DateTime KrajPrograma { get; set; }
        public string PutanjaRasporeda { get; set; } = "";
        public List<Emisija> Emisije { get; } = new List<Emisija>();

        public CompositeMemento(List<Component> raspored, int id, string imePrograma, DateTime pocetakPrograma,
            DateTime krajPrograma, string putanjaRasporeda, List<Emisija> listaEmisija)
        {
            _rasporedi = raspored;
            Id = id;
            ImePrograma = imePrograma;
            PocetakPrograma = pocetakPrograma;
            KrajPrograma = krajPrograma;
            PutanjaRasporeda = putanjaRasporeda;
            Emisije = listaEmisija;

        }

    }
}
