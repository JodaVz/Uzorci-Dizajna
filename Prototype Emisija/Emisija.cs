using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using marvertus_zadaca_3.Composite;
using marvertus_zadaca_3.Composite_Raspored;
using marvertus_zadaca_3.Modeli;
using marvertus_zadaca_3.Observer;
using marvertus_zadaca_3.PomocneKlase;

namespace marvertus_zadaca_3.Prototype_Emisija
{
    [Serializable]
    public class Emisija:EmisijaProto
    {
        public List<Dan> Dani = new List<Dan>();
        public DateTime? PocetakEmitiranjaEmisije { get; set; }

        public override Emisija Clone()
        {
            return new Emisija
            {
                Id = Id,
                NazivEmisije = NazivEmisije,
                TrajanjeEmisije = TrajanjeEmisije,
                Dani = Dani.ToList(),
                PocetakEmitiranjaEmisije = PocetakEmitiranjaEmisije,
                UlogeOsoba = UlogeOsoba.ToList()
            };
        }

        public static void Ispis()
        {
            foreach (var VARIABLE in UcitaniPodaci.UcitaneEmisije)
            {
                Console.WriteLine(VARIABLE.Id+" "+VARIABLE.NazivEmisije+" "+VARIABLE.TrajanjeEmisije.TotalMinutes+" ");
                if (VARIABLE.UlogeOsoba.Count!=0)
                {
                    Console.WriteLine("Postoje osobe koje rade na emisiji");
                }
                foreach (var osoba in VARIABLE.UlogeOsoba)
                {
                    string Ime = "";
                    string Uloga = "";
                    Ime = UcitaniPodaci.UcitaneOsobe.Find(o => o.Id == osoba.OsobaId).ImePrezime;
                    
                    try
                    {
                        Uloga = UcitaniPodaci.UcitaneUloge.Find(u => u.Id == osoba.UlogaId).Opis;


                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        

                    }
                    
                    Console.WriteLine(Ime+" - "+Uloga);
                }
            }
        }

        public static bool DodajEmisijuDnevnomRasporedu(TvProgram tvProgram, Emisija emisija, DnevniRaspored raspored,
            Dan i)
        {
            if(ProvjeriPripadnostEmisijeProgramu(tvProgram, emisija)==false)return false;
            var daniEmisije = emisija.Dani.Count > 0;
            //ako ima dane, a trenutni dan nije taj dan
            if (daniEmisije && !emisija.Dani.Contains(i))
            {
                Console.WriteLine("Emisija se ne izvodi u odabranom danu");
                return false;
            }
            //prioritet emisije 1. ( emisija ima i dan i pocetak emitiranja
            if (DodajPrioritetne(tvProgram, emisija, raspored, out var dodajEmisijuDnevnomRasporedu)) return dodajEmisijuDnevnomRasporedu;
            //za sve ostale
            if (DodajPreostale(tvProgram, emisija, raspored)) return true;

            return false;
        }

        private static bool DodajPrioritetne(TvProgram tvProgram, Emisija emisija, DnevniRaspored raspored,
            out bool dodajEmisijuDnevnomRasporedu)
        {
            if (emisija.PocetakEmitiranjaEmisije != null)
            {
                //ako emisija traje duže od samog programa
                if (emisija.PocetakEmitiranjaEmisije + emisija.TrajanjeEmisije > tvProgram.KrajPrograma)
                {
                    dodajEmisijuDnevnomRasporedu = false;
                    return true;
                }
                if (!ProvjeriPreklapanja(emisija.PocetakEmitiranjaEmisije.Value, emisija.TrajanjeEmisije,
                    raspored.DohvatiDjecu().Select(c => (EmisijaRasporeda) c).ToList()))
                {
                    dodajEmisijuDnevnomRasporedu = false;
                    return true;
                }
                var trazenaEmisija = new EmisijaRasporeda
                {
                    IdEmisije = emisija.Id,
                    PocetakEmisije = emisija.PocetakEmitiranjaEmisije.Value,
                    KrajEmisije = emisija.PocetakEmitiranjaEmisije.Value + emisija.TrajanjeEmisije,
                    NazivEmisije = emisija.NazivEmisije,
                    VrstaEmisije = emisija.VrstaEmisije,
                    UnikatniID=UcitaniPodaci.EmisijaUnikatniID,
                    OsobeUloge = DohvatiSveOsobeUloge(emisija)


                };
                DohvatiSveOsobeUloge(emisija);
                raspored.Dodaj(trazenaEmisija);
                UcitaniPodaci.EmisijaUnikatniID++;


                {
                    dodajEmisijuDnevnomRasporedu = true;
                    return true;
                }
            }
            dodajEmisijuDnevnomRasporedu = false;
            return false;
        }

        private static bool DodajPreostale(TvProgram tvProgram, Emisija emisija, DnevniRaspored raspored)
        {
            var krajPrograma = tvProgram.KrajPrograma - emisija.TrajanjeEmisije + new TimeSpan(24, 0, 0);
            for (var j = tvProgram.PocetakPrograma; j <= krajPrograma; j += new TimeSpan(0, 1, 0))
            {
                if (emisija.PocetakEmitiranjaEmisije + emisija.TrajanjeEmisije > tvProgram.KrajPrograma) continue;
                if (!ProvjeriPreklapanja(j, emisija.TrajanjeEmisije,
                    raspored.DohvatiDjecu().Select(c => (EmisijaRasporeda) c).ToList())) continue;
                var trazenaEmisija = new EmisijaRasporeda
                {
                    IdEmisije = emisija.Id,
                    PocetakEmisije = j,
                    KrajEmisije = j + emisija.TrajanjeEmisije,
                    NazivEmisije = emisija.NazivEmisije,
                    VrstaEmisije = emisija.VrstaEmisije,
                    UnikatniID = UcitaniPodaci.EmisijaUnikatniID,
                    OsobeUloge = DohvatiSveOsobeUloge(emisija)

                };
                raspored.Dodaj(trazenaEmisija);
                DohvatiSveOsobeUloge(emisija);
                UcitaniPodaci.EmisijaUnikatniID++;
                return true;
            }

            return false;
        }

        public static bool ProvjeriPripadnostEmisijeProgramu(TvProgram tvProgram, Emisija emisija)
        {
            if (tvProgram.Emisije.Count(e => e.Id == emisija.Id) < 1)
            {
                Console.WriteLine("Tražena emisija ne pripada odabranom programu");
                return false;
            }
            else return true;
        }

        public static bool ProvjeriPreklapanja(DateTime pocetakEmisije, TimeSpan trajanjeEmisije,
            IEnumerable<EmisijaRasporeda> emisijePrograma)
        {
            var krajEmisije = pocetakEmisije + trajanjeEmisije;
            foreach (var trenutnaEmisija in emisijePrograma.OrderBy(e=>e.PocetakEmisije))
            {
                if (trenutnaEmisija.PocetakEmisije <=krajEmisije && pocetakEmisije <= trenutnaEmisija.KrajEmisije)
                {
                    if (trenutnaEmisija.PocetakEmisije==krajEmisije || pocetakEmisije==trenutnaEmisija.KrajEmisije) continue;
                    return false;
                }
            }

            return true;
        }
        public static IObserver DodajOsobaUlogu(Osoba o, Uloga u)
        {
            if (UcitaniPodaci.UnikatniParovi.Count(ou => ou.Osoba == o && ou.Uloga == u) < 1)
            {
                UcitaniPodaci.UnikatniParovi.Add(new ConcreteSubject { Osoba = o, Uloga = u });
            }

            var subjekt = UcitaniPodaci.UnikatniParovi.First(ou => ou.Osoba == o && ou.Uloga == u);
            var observer = new OsobaSUlogom { Uloga = u, Osoba = o };
            subjekt.Attach(observer);
            return observer;
            
        }
        public static List<IObserver> DohvatiSveOsobeUloge(Emisija e)
        {
            List<IObserver> pomocnaLista= new List<IObserver>();
            foreach (var VARIABLE in e.UlogeOsoba)
            {
                try
                {
                    var osoba = UcitaniPodaci.UcitaneOsobe.First(o => o.Id == VARIABLE.OsobaId);
                    var uloga = UcitaniPodaci.UcitaneUloge.First(u => u.Id == VARIABLE.UlogaId);
                    pomocnaLista.Add(DodajOsobaUlogu(osoba, uloga));
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Ne postoji takav par osoba i uloga");
                    
                }
                
            }

            return pomocnaLista;

        }
    }
}
