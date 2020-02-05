using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using marvertus_zadaca_3.Modeli;
using marvertus_zadaca_3.Prototype_Emisija;

namespace marvertus_zadaca_3.Emisija_Builder
{
    class EmisijeBuilderDirector
    {
        IEmisijeBuilder _builder;
        public EmisijeBuilderDirector(IEmisijeBuilder builder)
        {
            _builder = builder;
        }
        public void KreirajEmisiju(int id, VrstaEmisije vrsta, string naziv, TimeSpan trajanje, string osobaUloga)
        {
            _builder.DodajId(id);
            _builder.DodajNaziv(naziv);
            _builder.DodajVrsta(vrsta);
            _builder.DodajTrajanje(trajanje);
            _builder.DodajOsobaUloga(osobaUloga);
        }
        public Emisija IzgradiEmisija()
        {
            return _builder.IzgradiEmisija();
        }

    }
}
