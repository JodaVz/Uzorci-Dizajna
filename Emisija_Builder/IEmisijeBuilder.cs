using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using marvertus_zadaca_3.Modeli;
using marvertus_zadaca_3.Prototype_Emisija;

namespace marvertus_zadaca_3.Emisija_Builder
{
    interface IEmisijeBuilder
    {
        void DodajId(int id);
        void DodajNaziv(string naziv);
        void DodajVrsta(VrstaEmisije vrsta);
        void DodajTrajanje(TimeSpan trajanje);
        void DodajOsobaUloga(string osobaUloga);
        Emisija IzgradiEmisija();
    }
}
