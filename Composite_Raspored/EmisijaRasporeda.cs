using System;
using System.Collections.Generic;
using marvertus_zadaca_3.Composite;
using marvertus_zadaca_3.Decorator;
using marvertus_zadaca_3.Modeli;
using marvertus_zadaca_3.Observer;
using marvertus_zadaca_3.Visitor;

namespace marvertus_zadaca_3.Composite_Raspored
{
    [Serializable]
    public class EmisijaRasporeda : Component,Element
    {
        public int IdEmisije { get; set; }
        public string NazivEmisije { get; set; }
        public DateTime PocetakEmisije { get; set; }
        public DateTime KrajEmisije { get; set; }
        public VrstaEmisije VrstaEmisije { get; set; }
        public int UnikatniID { get; set; }
        public List<IObserver> OsobeUloge { get; set; } = new List<IObserver>();

        public override void Dodaj(Component c)
        {
            Console.WriteLine("Emisija nema podklase");
        }

        public override void Obrisi(Component c)
        {
            Console.WriteLine("Emisija nema podklase");
        }

        public override List<Component> DohvatiDjecu()
        {
            throw new NotImplementedException();
        }

        public override void Ispisi()
        {
            var ispisEmisije = IdEmisije + ";" + NazivEmisije + ";" + PocetakEmisije.ToShortTimeString() + ";" +
                               KrajEmisije.ToShortTimeString() + ";" + VrstaEmisije.Opis + ";" +UnikatniID+";"+
                               PretvoriOsobeUloge(OsobeUloge);
            var simple = new ConcreteDComponent();
            var decorator1 = new ConcreteDecoratorA(simple);
            Console.WriteLine(decorator1.Ispis(ispisEmisije));
        }
        public  string IspisiMVC()
        {
            var ispisEmisije = IdEmisije + ";" + NazivEmisije + ";" + PocetakEmisije.ToShortTimeString() + ";" +
                               KrajEmisije.ToShortTimeString() + ";" + VrstaEmisije.Opis + ";" + UnikatniID + ";" +
                               PretvoriOsobeUloge(OsobeUloge);
            var simple = new ConcreteDComponent();
            var decorator1 = new ConcreteDecoratorA(simple);
            //Console.WriteLine(decorator1.Ispis(ispisEmisije));
            return decorator1.Ispis(ispisEmisije);
        }
        public override int DohvatiId()
        {
            return VrstaEmisije.Id;
        }

        public string PretvoriOsobeUloge(List<IObserver> osobeUloge)
        {
            var pomocna = "";
            foreach (var osobaUloga in OsobeUloge)
            {
                var osoba = (OsobaSUlogom) osobaUloga;
                pomocna += osoba.Osoba.ImePrezime;
                pomocna += "(" + osoba.Osoba.Id + ")";
                pomocna += "-";
                pomocna += osoba.Uloga.Opis;
                pomocna += "(" + osoba.Uloga.Id + ")";
            }

            return pomocna;
        }

        //Visitor
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}