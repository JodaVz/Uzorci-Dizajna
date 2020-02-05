using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using marvertus_zadaca_3.Modeli;

namespace marvertus_zadaca_3.Observer
{
    public class ConcreteSubject : ISubject
    {
        public Osoba Osoba { get; set; }
        public Uloga Uloga { get; set; }
        private List<IObserver> _observers = new List<IObserver>();
        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }
        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }
        public void Notify()
        {
            foreach (var o in _observers)
            {
                o.Update(this);
            }
        }
    }
}
