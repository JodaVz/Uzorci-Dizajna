using System;
using System.Collections.Generic;
using System.Linq;
using marvertus_zadaca_3.Prototype_Emisija;
using marvertus_zadaca_3.Composite;
using marvertus_zadaca_3.Composite_Raspored;
using marvertus_zadaca_3.Decorator;
using marvertus_zadaca_3.Memento;
using marvertus_zadaca_3.Modeli;
using marvertus_zadaca_3.Visitor;

namespace marvertus_zadaca_3.PomocneKlase
{
    public static class Izbornik
    {
        public static void OdabirOpcija()
        {
            int odabir;
            do
            {
                odabir = 0;
                Console.WriteLine("Izbornik rasporeda sati");
                Console.WriteLine("1. Ispis rasporeda sati (kompletan)");
                Console.WriteLine("2. Ispis emisija programa i dana (iteratorom)");
                Console.WriteLine("3. Ispis vrsta emisija");
                Console.WriteLine("4. Promjeni ulogu osobe");
                Console.WriteLine("5. Ispis prihoda po danu");
                Console.WriteLine("6. Ispis prihoda po danu (visitor)");
                Console.WriteLine("7. Brisanje emisije");
                Console.WriteLine("8. Ispis svih ucitanih podataka ");
                Console.WriteLine("10. Vraćanje prethodnih verzija");
                Console.Write("ODABERITE: ");
                
                odabir = int.Parse(Console.ReadLine());
                if (odabir == 1)
                {
                    IspisRasporedaUDanu();
                    Console.ReadKey();
                }

                if (odabir == 2)
                {
                    IspisEmisijaIteratorom();
                    Console.ReadKey();
                }

                if (odabir == 3)
                {
                    IspisVrstaEmisija();
                    Console.ReadKey();
                }

                if (odabir == 4)
                {
                    PromjenaUloge();
                    Console.ReadKey();
                }

                if (odabir == 5)
                {
                    IspisPrihodaUDanu();
                    Console.ReadKey();
                }

                if (odabir == 6)
                {
                    IspisPrihoda();
                    Console.ReadKey();
                }

                if (odabir==7)
                {
                    BrisanjeEmisije();
                    Console.ReadKey();
                }

                if (odabir == 10)
                {
                    PrethodneVerzije();
                    Console.ReadKey();
                }


                if (odabir == 8)
                {
                    Console.Clear();
                    IspisiSve();
                }
            } while (odabir != 9);
        }

        public static void IspisRasporedaUDanu()
        {
            Console.WriteLine("SVI RASPOREDI");
            TvKuca.Instance.TvProgrami.ForEach(p => p.DohvatiDjecu().ForEach(s => ((DnevniRaspored) s).Ispisi()));
        }

        public static void IspisPrihodaUDanu()
        {
            var odabirPrograma = 0;
            var odabirDana = 0;
            var suma = 0;
            Console.WriteLine("Unesite traženi program");
            odabirPrograma = int.Parse(Console.ReadLine()) - 1;
            Console.WriteLine("Unesite traženi dan ");
            odabirDana = int.Parse(Console.ReadLine()) - 1;
            var program = TvKuca.Instance.TvProgrami[odabirPrograma];
            Console.WriteLine("Emisije u: " + program.ImePrograma);
            Console.WriteLine("Dan:" + (Dan) (odabirDana + 1));
            for (var i = program.DohvatiItertor(odabirDana); i.ImaSljedeci();)
            {
                var emisija = (EmisijaRasporeda) i.DohvatiSljedeci();
                try
                {
                    if (emisija.VrstaEmisije.ImaReklamu)
                    {
                        emisija.Ispisi();
                        var komponenta = new ConcreteDComponent();
                        var decorator1 = new ConcreteDecoratorPrihoda(komponenta);
                        string pomocna = "";
                        pomocna = emisija.VrstaEmisije.MaksTrajanjeReklame.ToString() + ";" + suma;
                        Console.WriteLine(decorator1.Ispis(pomocna));
                        suma = suma + emisija.VrstaEmisije.MaksTrajanjeReklame;
                    }
                }
                catch (Exception)
                {
                }
            }

            Console.WriteLine("Maksimalni prihodi za odabran program i dan su: " + suma + " kuna");
        }

        public static void IspisVrstaEmisija()
        {
            Console.WriteLine("Mogući tipovi su");
            VrstaEmisije.Ispis();
            Console.Write("Unesite traženi tip emisije:");
            var tipEmisije = int.Parse(Console.ReadLine());
            foreach (var program in TvKuca.Instance.TvProgrami)
            {
                Console.WriteLine("Emisije u: " + program.ImePrograma);
                for (var i = program.DohvatiIteratorEmisija(tipEmisije); i.ImaSljedeci();)
                {
                    var emisija = (EmisijaRasporeda) i.DohvatiSljedeci();

                    try
                    {
                        emisija.Ispisi();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Došli smo do kraja rasporeda");
                    }
                }
            }
        }

        

        public static void IspisEmisijaIteratorom()
        {
            var odabirPrograma = 0;
            var odabirDana = 0;
            Console.WriteLine("Unesite traženi program");
            odabirPrograma = int.Parse(Console.ReadLine()) - 1;
            Console.WriteLine("Unesite traženi dan ");
            odabirDana = int.Parse(Console.ReadLine()) - 1;
            var program = TvKuca.Instance.TvProgrami[odabirPrograma];
            Console.WriteLine("Emisije u: " + program.ImePrograma);
            Console.WriteLine("Dan:" + (Dan) (odabirDana + 1));
            for (var i = program.DohvatiItertor(odabirDana); i.ImaSljedeci();)
            {
                var emisija = (EmisijaRasporeda) i.DohvatiSljedeci();
                try
                {
                    emisija.Ispisi();
                }
                catch (Exception)
                {
                }
            }
        }

        public static bool UcitajDatoteke(string[] args)
        {
            Console.WriteLine("Započinjem s učitavanjem podataka...");
            var pocetnaProvjeraDatoteka = ProvjeraDatotekeSingleton.GetInstance.ProvjeriDatoteke(args.ToList());
            Console.WriteLine();
            if (pocetnaProvjeraDatoteka)
            {
                var listaArgumenata = args.ToList();
                UcitaniPodaci.UcitajOsobe(listaArgumenata);
                UcitaniPodaci.UcitajUloge(listaArgumenata);
                UcitaniPodaci.UcitajVrste(listaArgumenata);
                UcitaniPodaci.UcitajPrograme(listaArgumenata);
                UcitaniPodaci.UcitajEmisije(listaArgumenata);
                TvProgram.DodajPopunjenjePrograme();
                DnevniRaspored.KreirajRaspored();
            }

            return pocetnaProvjeraDatoteka;
        }

        public static void IspisiSve()
        {
            Osoba.Ispis();
            VrstaEmisije.Ispis();
            Uloga.Ispis();
            TvProgram.Ispis();
            //Emisija.Ispis();
        }

        public static void PromjenaUloge()
        {
            foreach (var VARIABLE in UcitaniPodaci.UnikatniParovi)
                Console.WriteLine(VARIABLE.Osoba.Id + "," + VARIABLE.Osoba.ImePrezime + "-" + VARIABLE.Uloga.Opis + "" +
                                  VARIABLE.Uloga.Id);
            Console.WriteLine("Odaberite ID osobe za promjenu:");
            var odabir = int.Parse(Console.ReadLine());
            foreach (var VARIABLE in UcitaniPodaci.UnikatniParovi)
                if (VARIABLE.Osoba.Id == odabir)
                    Console.WriteLine(VARIABLE.Osoba.ImePrezime + "" + VARIABLE.Uloga.Opis + " " + VARIABLE.Uloga.Id);
            Console.WriteLine("Odaberite ulogu za promjenu");
            var staraUloga = int.Parse(Console.ReadLine());
            Console.WriteLine("Odaberite novu ulogu");
            var novaUloga = int.Parse(Console.ReadLine());
            var lokacija = UcitaniPodaci.UnikatniParovi.Find(o => o.Osoba.Id == odabir && o.Uloga.Id == staraUloga);
            lokacija.Uloga = UcitaniPodaci.UnikatniParovi.First(u => u.Uloga.Id == novaUloga).Uloga;
            lokacija.Notify();
            foreach (var VARIABLE in UcitaniPodaci.UnikatniParovi)
                Console.WriteLine(VARIABLE.Osoba.Id + "," + VARIABLE.Osoba.ImePrezime + "-" + VARIABLE.Uloga.Opis);
        }
        //Visitor
        public static void IspisPrihoda()
        {
            var odabirPrograma = 0;
            var odabirDana = 0;
            Console.WriteLine("Unesite traženi program");
            odabirPrograma = int.Parse(Console.ReadLine()) - 1;
            Console.WriteLine("Unesite traženi dan ");
            odabirDana = int.Parse(Console.ReadLine()) ;
            var program = TvKuca.Instance.TvProgrami[odabirPrograma];
            foreach (var VARIABLE in program.DohvatiDjecu())
            {
                DnevniRaspored dan=VARIABLE as DnevniRaspored;
                if ((int) dan.Dan == odabirDana)
                {
                    foreach (var emisija in dan.DohvatiDjecu())
                    {
                        EmisijaRasporeda eRasporeda=emisija as EmisijaRasporeda;
                        eRasporeda.Accept(new PrihodOdReklame());
                    }
                }
            }
        }

        public static void BrisanjeEmisije()
        {
            List<TvProgram> secondList= new List<TvProgram>();
            using (var stream = new System.IO.MemoryStream())
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, TvKuca.Instance.TvProgrami); //serialize to stream
                stream.Position = 0;
                //deserialize from stream.
                secondList = binaryFormatter.Deserialize(stream) as List<TvProgram>;
            }
            Console.WriteLine(secondList.Count);
            var odabirEmisije = 0;
            Console.WriteLine("Unesite traženi id emisije");
            odabirEmisije = int.Parse(Console.ReadLine());
            TvKucaMemory m= new TvKucaMemory();
            m.Memento = TvKuca.Instance.SpremiRaspored(secondList);
            m.Memento.DatumPohrane = DateTime.Now;
            m.Memento.IdPohrane = UcitaniPodaci.ListaPohranjivanja.Count+1;
            UcitaniPodaci.ListaPohranjivanja.Add(m);
            foreach (var program in TvKuca.Instance.TvProgrami)
            {
                foreach (var VARIABLE in program.DohvatiDjecu())
                {
                    DnevniRaspored dan = VARIABLE as DnevniRaspored;
                    var odabranaEmisija =
                        dan.DohvatiDjecu().Find(c => ((EmisijaRasporeda) c).UnikatniID == odabirEmisije);
                    dan.Obrisi(odabranaEmisija);
                }
            }
            Console.WriteLine(UcitaniPodaci.ListaPohranjivanja.Count);

            
           
        }

        public static void PrethodneVerzije()
        {
            Console.WriteLine("Popis prethodnih verzija");
            foreach (var VARIABLE in UcitaniPodaci.ListaPohranjivanja)
            {
                Console.WriteLine(VARIABLE.Memento.IdPohrane+". "+VARIABLE.Memento.DatumPohrane.ToShortTimeString());
            }

            Console.WriteLine("Odaberite ID prethodne verzije");
            var odabir = int.Parse(Console.ReadLine());
            TvKuca.Instance.VratiRaspored(UcitaniPodaci.ListaPohranjivanja[odabir-1].Memento);

        }
    }
}