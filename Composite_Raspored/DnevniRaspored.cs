using System;
using System.Collections.Generic;
using System.Linq;
using marvertus_zadaca_3.Composite;
using marvertus_zadaca_3.Modeli;
using marvertus_zadaca_3.PomocneKlase;
using marvertus_zadaca_3.Prototype_Emisija;
using marvertus_zadaca_3.Visitor;

namespace marvertus_zadaca_3.Composite_Raspored
{
    [Serializable]
    public class DnevniRaspored : Component
    {
        //component dio
        private readonly List<Component> _emisije = new List<Component>();
        public Dan Dan { get; set; }
        public int IdPrograma { get; set; }
        public string NazivPrograma { get; set; }

        public override void Dodaj(Component c)
        {
            _emisije.Add(c);
        }

        public override void Obrisi(Component c)
        {
            _emisije.Remove(c);
        }

        public override List<Component> DohvatiDjecu()
        {
            return _emisije.OrderBy(e => ((EmisijaRasporeda) e).PocetakEmisije).ToList();
        }

        public override void Ispisi()
        {
            Console.WriteLine("Raspored za " + Dan);
            foreach (var VARIABLE in _emisije.OrderBy(e => ((EmisijaRasporeda) e).PocetakEmisije)) VARIABLE.Ispisi();
        }

        public override int DohvatiId()
        {
            throw new NotImplementedException();
        }

        //TODO REFACTOR
        public static void KreirajRaspored()
        {
            foreach (var tvProgram in TvKuca.Instance.TvProgrami)
            {
                var preostaleEmisije = new List<Emisija>();
                var emisijeBezdana = tvProgram.Emisije.ToList().Where(e => e.Dani.Count < 1).ToList();
                for (var i = Dan.Ponedjeljak; i <= Dan.Nedjelja; i++)
                {
                    var raspored = new DnevniRaspored
                        {Dan = i, IdPrograma = tvProgram.Id, NazivPrograma = tvProgram.ImePrograma};
                    var emisije = new List<Emisija>();
                    //dodaj emisije u raspored
                    //TODO Provjeri dal radi OrderBy
                    DodajPrioritetne(emisije, tvProgram, i);
                    //koji nisu upali u raspored dodaj u preostale
                    preostaleEmisije.AddRange(emisije.Distinct().Where(emisija =>
                        !Emisija.DodajEmisijuDnevnomRasporedu(tvProgram, emisija, raspored, i)));
                    //makni dane gdje se emisija dodala
                    foreach (var emisija in preostaleEmisije.Where(a => a.Dani.Contains(i)))
                        if (Emisija.DodajEmisijuDnevnomRasporedu(tvProgram, emisija, raspored, i))
                            preostaleEmisije.Remove(emisija);
                    foreach (var emisija in preostaleEmisije.Distinct())
                    foreach (var progr in TvKuca.Instance.TvProgrami.Where(pr =>
                        pr.Emisije.Count(e => e.Id == emisija.Id) > 0))
                    foreach (var rasporedPrograma in progr.DohvatiDjecu().Cast<DnevniRaspored>()
                        .Where(rasporedPrograma =>
                            rasporedPrograma.DohvatiDjecu().Count(c => ((EmisijaRasporeda) c).IdEmisije == emisija.Id) >
                            0))
                        emisija.Dani.Remove(rasporedPrograma.Dan);
                    tvProgram.Dodaj(raspored);
                }

                foreach (DnevniRaspored raspored in tvProgram.DohvatiDjecu())
                foreach (var emisija in emisijeBezdana.ToList())
                    if (Emisija.DodajEmisijuDnevnomRasporedu(tvProgram, emisija, raspored, raspored.Dan))
                        emisijeBezdana.Remove(emisija);
            }
        }

        private static void DodajPrioritetne(List<Emisija> emisije, TvProgram tvProgram, Dan i)
        {
            emisije.AddRange(tvProgram.Emisije.Where(e =>
                    e.Dani.Count >= 1 && e.Dani.Contains(i) && e.PocetakEmitiranjaEmisije != null)
                .OrderBy(a => a.PocetakEmitiranjaEmisije)
                .OrderBy(d => d.Dani.Count)
                .ThenBy(p => p.PocetakEmitiranjaEmisije));
            emisije.AddRange(tvProgram.Emisije.Where(e =>
                e.Dani.Count >= 1 && e.Dani.Contains(i) && e.PocetakEmitiranjaEmisije == null));
        }
        //Visitor
        public void Accept(IVisitor visitor)
        {
            foreach (EmisijaRasporeda e in _emisije)
            {
                e.Accept(visitor);
            }
            Console.WriteLine();
        }
    }
}