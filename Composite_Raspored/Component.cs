using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marvertus_zadaca_3.Composite
{
    [Serializable]
    public abstract class Component
    {
        public abstract void Dodaj(Component c);
        public abstract void Obrisi(Component c);
        public abstract List<Component> DohvatiDjecu();
        public abstract void Ispisi();
        public abstract int DohvatiId();
    }
}
