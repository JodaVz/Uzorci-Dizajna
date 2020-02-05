using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using marvertus_zadaca_3.Prototype_Emisija;
using marvertus_zadaca_3.Chain;
using marvertus_zadaca_3.Composite;
using marvertus_zadaca_3.Composite_Raspored;
using marvertus_zadaca_3.Memento;
using marvertus_zadaca_3.Modeli;
using marvertus_zadaca_3.PomocneKlase;
using marvertus_zadaca_3.Visitor;

namespace marvertus_zadaca_3.MVC
{
    public class Controller
    {
        private DefaultView defaultPogled;
        private BrojivView brojivPogled;
        public static int brojacLinija;
        public static int trenutniPogled;

        public Controller()
        {
            brojacLinija = 1;
            trenutniPogled = 1;
            PrikaziPogled();
        }

        public void PrikaziPogled()
        {
            defaultPogled = new DefaultView();
            brojivPogled = new BrojivView();
            int odabir=300;
            do
            {
                try
                {
                    if (trenutniPogled == 1)
                    {
                  
                        defaultPogled.PrikaziIzbornik();
                    }

                    if (trenutniPogled == 2)
                    {
                    
                        brojivPogled.PrikaziIzbornik();
                    }


                    //izbornik

                    odabir = int.Parse(Console.ReadLine());
                    if (odabir == 0)
                    {
                        PromjeniPogled();
                        //Console.ReadKey();
                    }

                    if (odabir == 1)
                    {
                        IspisRasporedaUDanu();
                        Console.ReadKey();
                    }

                    if (odabir == 2)
                    {
                        int program=1;
                        int dan=1;
                        if (trenutniPogled == 1)
                        {
                            program = defaultPogled.OdabirPrograma();
                            dan = defaultPogled.OdabirDana();
                        }

                        if (trenutniPogled == 2)
                        {
                            program = brojivPogled.OdabirPrograma();
                            dan = brojivPogled.OdabirDana();
                        }
                        IspisEmisijaIteratorom(program, dan);
                        Console.ReadKey();
                    }
                    if (odabir == 3)
                    {
                        if (trenutniPogled == 1)
                        {
                            IspisVrstaEmisija();
                        }

                        if (trenutniPogled == 2)
                        {
                            IspisVrstaEmisija();

                        }

                        Console.ReadKey();
                    }
                    if (odabir == 4)
                    {
                    
                        if (trenutniPogled == 1)
                        {
                            PromjenaUloge();
                        }

                        if (trenutniPogled == 2)
                        {
                            PromjenaUloge();

                        }

                        Console.ReadKey();
                    }
                    if (odabir == 5)
                    {

                        if (trenutniPogled == 1)
                        {
                            IspisPrihoda();
                        }

                        if (trenutniPogled == 2)
                        {
                            IspisPrihoda();

                        }

                        Console.ReadKey();
                    }
                    if (odabir == 6)
                    {

                        if (trenutniPogled == 1)
                        {
                            BrisanjeEmisije();
                        }

                        if (trenutniPogled == 2)
                        {
                            BrisanjeEmisije();

                        }

                        Console.ReadKey();
                    }
                    if (odabir == 7)
                    {

                        if (trenutniPogled == 1)
                        {
                            PrethodneVerzije();
                        }

                        if (trenutniPogled == 2)
                        {
                            PrethodneVerzije();

                        }

                        Console.ReadKey();
                    }
                    if (odabir == 8)
                    {

                        if (trenutniPogled == 1)
                        {
                            KoristiChain();
                        }

                        if (trenutniPogled == 2)
                        {
                            KoristiChain();

                        }

                        Console.ReadKey();
                    }




                    //if (odabir == 10)
                    //{
                    //    PrethodneVerzije();
                    //    Console.ReadKey();
                    //}


                    //if (odabir == 8)
                    //{
                    //    Console.Clear();
                    //    IspisiSve();
                    //}
                }
                catch (Exception)
                {
                    Console.WriteLine("Greška, unesite broj");
                    
                }
            } while (odabir != 9);

        }
        
        //opcija 0
        public static void PromjeniPogled()
        {
            if (trenutniPogled == 1)
            {
                trenutniPogled ++;
            }

            else if (trenutniPogled == 2)
            {
                trenutniPogled --;
            }

        }
        //opcija 1
        public static void IspisRasporedaUDanu()
        {
            DefaultView pogled = new DefaultView();
            BrojivView brojiviPogled = new BrojivView();
            Console.WriteLine("SVI RASPOREDI");
            foreach (var VARIABLE in TvKuca.Instance.TvProgrami)
            {
                var program = VARIABLE.DohvatiDjecu();
                foreach (var DnevniRaspored in program)
                {
                    var dnevni = DnevniRaspored.DohvatiDjecu();
                    DnevniRaspored dnevniRaspored = (DnevniRaspored) DnevniRaspored;
                    try
                    {
                        // emisija.Ispisi();
                        if (trenutniPogled == 1)
                        {
                            pogled.IspisiDan(dnevniRaspored.Dan);
                        }

                        if (trenutniPogled == 2)
                        {
                            brojiviPogled.IspisiDan(dnevniRaspored.Dan);
                        }

                    }
                    catch (Exception)
                    {
                    }
                    foreach (var emisija in dnevni)
                    {
                        
                        EmisijaRasporeda odabranaEmisija = (EmisijaRasporeda) emisija;
                        try
                        {
                            // emisija.Ispisi();
                            if (trenutniPogled == 1)
                            {
                                pogled.IspisiEmisije(odabranaEmisija.IspisiMVC());
                            }

                            if (trenutniPogled == 2)
                            {
                                brojiviPogled.IspisiEmisije(odabranaEmisija.IspisiMVC());
                            }

                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
        }
        //opcija 2
        public static void IspisEmisijaIteratorom(int odabirPrograma, int odabirDana)
        {
            DefaultView pogled = new DefaultView();
            BrojivView brojiviPogled = new BrojivView();
           
           
            int odabranDan = odabirDana;
            try
            {
                var program = TvKuca.Instance.TvProgrami[odabirPrograma];
                for (var i = program.DohvatiItertor(odabirDana); i.ImaSljedeci();)
                {
                    var emisija = (EmisijaRasporeda)i.DohvatiSljedeci();
                    try
                    {
                        // emisija.Ispisi();
                        if (trenutniPogled == 1)
                        {
                            pogled.IspisiEmisije(emisija.IspisiMVC());
                        }

                        if (trenutniPogled == 2)
                        {
                            brojiviPogled.IspisiEmisije(emisija.IspisiMVC());
                        }

                    }
                    catch (Exception)
                    {
                    }

                }
            }
            catch (Exception )
            {
                Console.WriteLine("Greska");
                
            }
            
        }
        //opcija 3
        public static void IspisVrstaEmisija()
        {
            DefaultView pogled = new DefaultView();
            BrojivView brojiviPogled = new BrojivView();
            IspisPonudjenihVrsta();
            var tipEmisije = int.Parse(Console.ReadLine());
            foreach (var program in TvKuca.Instance.TvProgrami)
            {
                if (trenutniPogled == 1)
                {
                    pogled.IspisiImePrograma("Emisije u: " + program.ImePrograma);
                }

                if (trenutniPogled == 2)
                {
                    brojiviPogled.IspisiImePrograma("Emisije u: " + program.ImePrograma);
                }
                for (var i = program.DohvatiIteratorEmisija(tipEmisije); i.ImaSljedeci();)
                {
                    var emisija = (EmisijaRasporeda)i.DohvatiSljedeci();
                   
                    try
                    {
                        // emisija.Ispisi();
                        if (trenutniPogled == 1)
                        {
                            pogled.IspisiEmisije(emisija.IspisiMVC());
                        }

                        if (trenutniPogled == 2)
                        {
                            brojiviPogled.IspisiEmisije(emisija.IspisiMVC());
                        }

                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }
        //pomocna za opciju 3
        public static void IspisPonudjenihVrsta()
        {
            DefaultView pogled = new DefaultView();
            BrojivView brojiviPogled = new BrojivView();
            if (trenutniPogled == 1)
            {
                pogled.IspisiVrsteHeader();
            }

            if (trenutniPogled == 2)
            {
                brojiviPogled.IspisiVrsteHeader();
            }
            foreach (var VARIABLE in UcitaniPodaci.UcitaneVrsteEmisija)
            {
                 string vrsta=(VARIABLE.Id + " " + VARIABLE.Opis + " " + VARIABLE.ImaReklamu + " " +
                                  VARIABLE.MaksTrajanjeReklame);
                 try
                 { 
                     if (trenutniPogled == 1)
                     {
                         pogled.IspisVrste(vrsta);
                     }

                     if (trenutniPogled == 2)
                     {
                         brojiviPogled.IspisVrste(vrsta);
                     }

                 }
                 catch (Exception)
                 {
                 }
            }

        }
        //opcija 4.
        public static void PromjenaUloge()
        {
            DefaultView pogled = new DefaultView();
            BrojivView brojiviPogled = new BrojivView();
            try
            {
                foreach (var VARIABLE in UcitaniPodaci.UnikatniParovi)
                {
                    string osobeUloge=(VARIABLE.Osoba.Id + "," + VARIABLE.Osoba.ImePrezime + "-" + VARIABLE.Uloga.Opis + "" +
                                       VARIABLE.Uloga.Id);
                    if (trenutniPogled == 1)
                    {
                        pogled.IspisiSveOsobeUloge(osobeUloge);
                    }

                    if (trenutniPogled == 2)
                    {
                        brojiviPogled.IspisiSveOsobeUloge(osobeUloge);
                    }
                }

                if (trenutniPogled == 1)
                {
                    pogled.IspisiOdabirOsobe();
                }

                if (trenutniPogled == 2)
                {
                    brojiviPogled.IspisiOdabirOsobe();
                }
                var odabir = int.Parse(Console.ReadLine());
                foreach (var VARIABLE in UcitaniPodaci.UnikatniParovi)
                {
                    if (VARIABLE.Osoba.Id == odabir)
                    {
                        string osobe=(VARIABLE.Osoba.ImePrezime + "" + VARIABLE.Uloga.Opis + " " + VARIABLE.Uloga.Id);
                        if (trenutniPogled == 1)
                        {
                            pogled.IspisiSveOsobeUloge(osobe);
                        }

                        if (trenutniPogled == 2)
                        {
                            brojiviPogled.IspisiSveOsobeUloge(osobe);
                        }
                    }
                }
                if (trenutniPogled == 1)
                {
                    pogled.IspisOdabirStareUloge();
                }

                if (trenutniPogled == 2)
                {
                    brojiviPogled.IspisOdabirStareUloge();
                }
                var staraUloga = int.Parse(Console.ReadLine());
                if (trenutniPogled == 1)
                {
                    pogled.IspisOdabirNoveUloge();
                }

                if (trenutniPogled == 2)
                {
                    brojiviPogled.IspisOdabirNoveUloge();
                }
                var novaUloga = int.Parse(Console.ReadLine());
                var lokacija = UcitaniPodaci.UnikatniParovi.Find(o => o.Osoba.Id == odabir && o.Uloga.Id == staraUloga);
                lokacija.Uloga = UcitaniPodaci.UnikatniParovi.First(u => u.Uloga.Id == novaUloga).Uloga;
                lokacija.Notify();
                foreach (var VARIABLE in UcitaniPodaci.UnikatniParovi)
                {
                    string noveOsobe=(VARIABLE.Osoba.Id + "," + VARIABLE.Osoba.ImePrezime + "-" + VARIABLE.Uloga.Opis);
                    if (trenutniPogled == 1)
                    {
                        pogled.IspisiSveOsobeUloge(noveOsobe);
                    }

                    if (trenutniPogled == 2)
                    {
                        brojiviPogled.IspisiSveOsobeUloge(noveOsobe);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Greška");
                
            }
        }
        //opcija 5
        public static void IspisPrihoda()
        {
            try
            {
                DefaultView pogled = new DefaultView();
                BrojivView brojiviPogled = new BrojivView();
                PrihodOdReklame.ResetirajSumu();
                var odabirPrograma = 0;
                var odabirDana = 0;
                if (trenutniPogled == 1)
                {
                    pogled.OdabirProgramaPrihod();
                }

                if (trenutniPogled == 2)
                {
                    brojiviPogled.OdabirProgramaPrihod();
                }
                odabirPrograma = int.Parse(Console.ReadLine()) - 1;
                if (trenutniPogled == 1)
                {
                    pogled.OdabirDanaPrihod();
                }

                if (trenutniPogled == 2)
                {
                    brojiviPogled.OdabirDanaPrihod();
                }
            
                odabirDana = int.Parse(Console.ReadLine());
                var program = TvKuca.Instance.TvProgrami[odabirPrograma];
                foreach (var VARIABLE in program.DohvatiDjecu())
                {
                    DnevniRaspored dan = VARIABLE as DnevniRaspored;
                    if ((int)dan.Dan == odabirDana)
                    {
                        foreach (var emisija in dan.DohvatiDjecu())
                        {
                            EmisijaRasporeda eRasporeda = emisija as EmisijaRasporeda;
                        
                            eRasporeda.Accept(new PrihodOdReklame());
                        }
                    }
                }
            }
            catch (Exception )
            {
                Console.WriteLine("Greška");
                
            }
        }
        //opcija 6
        public static void BrisanjeEmisije()
        {
            try
            {
                DefaultView pogled = new DefaultView();
                BrojivView brojiviPogled = new BrojivView();
                List<TvProgram> secondList = new List<TvProgram>();
                using (var stream = new MemoryStream())
                {
                    var binaryFormatter = new BinaryFormatter();
                    binaryFormatter.Serialize(stream, TvKuca.Instance.TvProgrami); 
                    stream.Position = 0;
                    secondList = binaryFormatter.Deserialize(stream) as List<TvProgram>;
                }
                Console.WriteLine(secondList.Count);
                var odabirEmisije = 0;
                if (trenutniPogled == 1)
                {
                    pogled.IspisOdabiraIDEmisije();
                }

                if (trenutniPogled == 2)
                {
                    brojiviPogled.IspisOdabiraIDEmisije();
                }
                odabirEmisije = int.Parse(Console.ReadLine());
                TvKucaMemory m = new TvKucaMemory();
                m.Memento = TvKuca.Instance.SpremiRaspored(secondList);
                m.Memento.DatumPohrane = DateTime.Now;
                m.Memento.IdPohrane = UcitaniPodaci.ListaPohranjivanja.Count + 1;
                UcitaniPodaci.ListaPohranjivanja.Add(m);
                foreach (var program in TvKuca.Instance.TvProgrami)
                {
                    foreach (var VARIABLE in program.DohvatiDjecu())
                    {
                        DnevniRaspored dan = VARIABLE as DnevniRaspored;
                        var odabranaEmisija =
                            dan.DohvatiDjecu().Find(c => ((EmisijaRasporeda)c).UnikatniID == odabirEmisije);
                        dan.Obrisi(odabranaEmisija);
                    }
                }
                Console.WriteLine(UcitaniPodaci.ListaPohranjivanja.Count);
            }
            catch (Exception )
            {
                Console.WriteLine("Greška");
                
            }
        }
        //opcija 7 
        public static void PrethodneVerzije()
        {
            try
            {
                DefaultView pogled = new DefaultView();
                BrojivView brojiviPogled = new BrojivView();
                if (trenutniPogled == 1)
                {
                    pogled.IspisPrethodnihVerzijaHeader();
                }

                if (trenutniPogled == 2)
                {
                    brojiviPogled.IspisPrethodnihVerzijaHeader();
                }
           
                foreach (var VARIABLE in UcitaniPodaci.ListaPohranjivanja)
                {
                    string prethodnaVerzija=(VARIABLE.Memento.IdPohrane + ". " + VARIABLE.Memento.DatumPohrane.ToShortTimeString());
                    if (trenutniPogled == 1)
                    {
                        pogled.IspisPrethodnihVerzija(prethodnaVerzija);
                    }

                    if (trenutniPogled == 2)
                    {
                        brojiviPogled.IspisPrethodnihVerzija(prethodnaVerzija);
                    }
                }

                if (trenutniPogled == 1)
                {
                    pogled.IspisPrethodnihVerzijaFooter();
                }

                if (trenutniPogled == 2)
                {
                    brojiviPogled.IspisPrethodnihVerzijaFooter();
                }
                var odabir = int.Parse(Console.ReadLine());
                TvKuca.Instance.VratiRaspored(UcitaniPodaci.ListaPohranjivanja[odabir - 1].Memento);
            }
            catch (Exception )
            {
                Console.WriteLine("Greška");
            }

        }
        //opcija 8 
        public static void KoristiChain()
        {
            DefaultView pogled = new DefaultView();
            BrojivView brojiviPogled = new BrojivView();
            Handler h1 = new PrviLink();
            Handler h2 = new DrugiLink();
            Handler h3 = new TreciLink();
            Handler h4 = new CetvrtiLink();
            Handler h5 = new PetiLink();
            Handler h6 = new ZadnjiLink();
            h1.SetSuccessor(h2);
            h2.SetSuccessor(h3);
            h3.SetSuccessor(h4);
            h4.SetSuccessor(h5);
            h5.SetSuccessor(h6);
            Console.WriteLine("SVI RASPOREDI");
            foreach (var VARIABLE in TvKuca.Instance.TvProgrami)
            {
                var program = VARIABLE.DohvatiDjecu();
                foreach (var DnevniRaspored in program)
                {
                    var dnevni = DnevniRaspored.DohvatiDjecu();
                    DnevniRaspored dnevniRaspored = (DnevniRaspored)DnevniRaspored;
                    try
                    {
                        
                        // emisija.Ispisi();
                        if (trenutniPogled == 1)
                        {
                            pogled.IspisiDan(dnevniRaspored.Dan);
                        }

                        if (trenutniPogled == 2)
                        {
                            brojiviPogled.IspisiDan(dnevniRaspored.Dan);
                        }

                    }
                    catch (Exception)
                    {
                    }
                    foreach (var emisija in dnevni)
                    {

                        EmisijaRasporeda odabranaEmisija = (EmisijaRasporeda)emisija;
                        try
                        {
                            // emisija.Ispisi();
                            if (trenutniPogled == 1)
                            {
                                string test = h1.HandleRequest(odabranaEmisija);
                                pogled.IspisiEmisije(h1.HandleRequest(odabranaEmisija));
                                //pogled.IspisiEmisije(odabranaEmisija.IspisiMVC());
                            }

                            if (trenutniPogled == 2)
                            {
                                brojiviPogled.IspisiEmisije(h1.HandleRequest(odabranaEmisija));
                            }

                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
        }

    }
}
