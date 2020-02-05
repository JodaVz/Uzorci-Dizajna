using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using marvertus_zadaca_3.Emisija_Builder;
using marvertus_zadaca_3.Iterator;
using marvertus_zadaca_3.Memento;
using marvertus_zadaca_3.Modeli;
using marvertus_zadaca_3.PomocneKlase;
using marvertus_zadaca_3.Prototype_Emisija;

namespace marvertus_zadaca_3.Composite
{
    [Serializable]
    public class TvProgram : Component, IteratorKolekcije
    {
        public List<Component> _rasporedi = new List<Component>();
        public int Id { get; set; }
        public string ImePrograma { get; set; } = "";
        public DateTime PocetakPrograma { get; set; }
        public DateTime KrajPrograma { get; set; }
        public string PutanjaRasporeda { get; set; } = "";
        public List<Emisija> Emisije { get; set; } = new List<Emisija>();

        public IteratorInterface DohvatiItertor()
        {
            throw new NotImplementedException();
        }

        public override void Dodaj(Component c)
        {
            _rasporedi.Add(c);
        }

        public override void Obrisi(Component c)
        {
            _rasporedi.Remove(c);
        }

        public override List<Component> DohvatiDjecu()
        {
            return _rasporedi;
        }

        public override void Ispisi()
        {
            Console.WriteLine(ImePrograma);
        }

        public override int DohvatiId()
        {
            throw new NotImplementedException();
        }

        public static void Ispis()
        {
            Console.WriteLine("ISPIS TV PROGRAMA");
            foreach (var VARIABLE in TvKuca.Instance.TvProgrami)
                Console.WriteLine(VARIABLE.Id + " " + VARIABLE.ImePrograma + " " + VARIABLE.PocetakPrograma.TimeOfDay +
                                  "-" + VARIABLE.KrajPrograma.TimeOfDay + " " + VARIABLE.PutanjaRasporeda);

            Console.WriteLine("\n");
            Console.WriteLine("ISPIS EMISIJA PO TV PROGRAMU");
            foreach (var VARIABLE in TvKuca.Instance.TvProgrami)
            {
                Console.WriteLine(VARIABLE.ImePrograma);
                foreach (var emisija in VARIABLE.Emisije)
                {
                    Console.WriteLine(emisija.Id + " " + emisija.NazivEmisije + " " + emisija.VrstaEmisije.Opis + " " +
                                      emisija.PocetakEmitiranjaEmisije + " " + emisija.TrajanjeEmisije);
                    foreach (var osoba in emisija.UlogeOsoba)
                        Console.WriteLine("ID osobe:" + osoba.OsobaId + "-ID uloge:" + osoba.UlogaId);

                    foreach (var dan in emisija.Dani) Console.WriteLine("Dan:" + dan);
                }
            }
        }

        //TODO Dodaj provjeru podataka
        public static List<string> UcitajEmisijePrograma(string putanjaDatoteke)
        {
            var emisijePrograma = new List<string>();
            emisijePrograma = File.ReadAllLines(putanjaDatoteke).ToList();
            emisijePrograma = emisijePrograma.Skip(1).Distinct().ToList();
            foreach (var VARIABLE in emisijePrograma.ToList())
            {
                var count = VARIABLE.Split(';').Length - 1;
                if (count != 3) emisijePrograma.Remove(VARIABLE);
            }

            return emisijePrograma;
        }

        public static IEnumerable<Emisija> PopuniPrograme(string putanjaRasporeda)
        {
            var emisije = new List<Emisija>();
            var ucitaneEmisije = UcitajEmisijePrograma(putanjaRasporeda);
            foreach (var VARIABLE in ucitaneEmisije.Distinct())
            {
                var pomocna = VARIABLE.Split(';');
                var id = int.Parse(pomocna[0].Trim());
                if (UcitaniPodaci.UcitaneEmisije.Count(a => a.Id == id) < 1) continue;
                var emisija = UcitaniPodaci.UcitaneEmisije.First(e => e.Id == id).Clone();
                emisija.Dani = DanPomoc.KreirajDane(pomocna[1].Trim());
                emisija.VrstaEmisije = UcitaniPodaci.UcitaneEmisije.First(v => v.Id == id).VrstaEmisije;
                //ako postoji pocetak
                if (pomocna[2].Trim() != string.Empty)
                    emisija.PocetakEmitiranjaEmisije = DateTime.Parse(pomocna[2].Trim());

                if (pomocna[3].Trim() != string.Empty)
                {
                    var direktor = new EmisijeBuilderDirector(new EmisijeBuilder());
                    direktor.KreirajEmisiju(1, null, null, new TimeSpan(0, 0, 0), pomocna[3].Trim());
                    var testna = direktor.IzgradiEmisija();
                    emisija.UlogeOsoba.AddRange(testna.UlogeOsoba);
                }
                emisije.Add(emisija);
                UcitaniPodaci.DohvatiOsobuUlogu(emisija);
            }
            return emisije;
        }
        public static void DodajPopunjenjePrograme()
        {
            foreach (var VARIABLE in TvKuca.Instance.TvProgrami)
                VARIABLE.Emisije.AddRange(PopuniPrograme(VARIABLE.PutanjaRasporeda));
        }


        public IteratorInterface DohvatiItertor(int dan)
        {
            return new EmisijePoTjednu(this, dan);
        }

        public IteratorInterface DohvatiIteratorEmisija(int idVrste)
        {
            return new VrsteEmisijaPoTjednu(this, idVrste);
        }

        //Memento
        public CompositeMemento SpremiRaspored()
        {
            Console.WriteLine("Spremam trenutni raspored");
            return new CompositeMemento(_rasporedi,Id,ImePrograma,PocetakPrograma,KrajPrograma,PutanjaRasporeda,Emisije);
        }

        public void VratiRaspored(CompositeMemento memento)
        {
            Console.WriteLine("Vraćam na prethodnu verziju");
            _rasporedi = memento._rasporedi;
            Id = memento.Id;
            ImePrograma = memento.ImePrograma;
            PocetakPrograma = memento.PocetakPrograma;
            KrajPrograma = memento.KrajPrograma;
            PutanjaRasporeda = memento.PutanjaRasporeda;
            Emisije = memento.Emisije;
        }
    }
}