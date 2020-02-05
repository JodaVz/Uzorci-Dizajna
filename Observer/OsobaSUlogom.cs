using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using marvertus_zadaca_3.Modeli;

namespace marvertus_zadaca_3.Observer
{
    [Serializable]
    public class OsobaSUlogom : IObserver
    {
        public Osoba Osoba { get; set; }
        public Uloga Uloga { get; set; }

        public void Update(ISubject s)
        {
            var novaUloga = ((ConcreteSubject)s).Uloga;
            Uloga = novaUloga;
        }

    }
}
