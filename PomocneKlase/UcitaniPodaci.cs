using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using marvertus_zadaca_3.Factory_Method_Datoteke;
using marvertus_zadaca_3.Memento;
using marvertus_zadaca_3.Modeli;
using marvertus_zadaca_3.Observer;
using marvertus_zadaca_3.Prototype_Emisija;

namespace marvertus_zadaca_3.PomocneKlase
{
    public static class UcitaniPodaci
    {
        public static List<Osoba> UcitaneOsobe { get; } = new List<Osoba>();
        public static List<Uloga> UcitaneUloge { get; } = new List<Uloga>();

        public static List<VrstaEmisije> UcitaneVrsteEmisija { get; } = new List<VrstaEmisije>();
        public static List<ConcreteSubject> UnikatniParovi { get; }= new List<ConcreteSubject>();
        public static int EmisijaUnikatniID { get; set; }
        public static List<TvKucaMemory> ListaPohranjivanja { get; set; }=new List<TvKucaMemory>();

        public static List<Emisija> UcitaneEmisije { get; } = new List<Emisija>();

        public static string OsobaPutanja = "";
        public static string UlogePutanja = "";
        public static string VrstePutanja = "";
        public static string TvKucaPutanja = "";
        public static string EmisijaPutanja = "";

        public static void UcitajOsobe(List<string> argumentList)
        {
            int index = argumentList.FindIndex(a => a.Contains("-o"));
            Console.WriteLine("-o se nalazi na " + index);
            OsobaPutanja = argumentList.ElementAt(index + 1);
            Console.WriteLine(OsobaPutanja);
            UcitajDatotekeFactory tvornica = new UcitajDatotekeFactory();
            IUcitajDatotekeFactory ucitajOsobe = tvornica.Ucitaj("osoba");
            ucitajOsobe.UcitajDatoteku();
        }

        public static void UcitajUloge(List<string> argumentList)
        {
            int index = argumentList.FindIndex(a => a.Contains("-u"));
            Console.WriteLine("-u se nalazi na " + index);
            UlogePutanja = argumentList.ElementAt(index + 1);
            Console.WriteLine(UlogePutanja);
            UcitajDatotekeFactory tvornica = new UcitajDatotekeFactory();
            IUcitajDatotekeFactory ucitajUloge = tvornica.Ucitaj("uloga");
            ucitajUloge.UcitajDatoteku();
        }

        public static void UcitajVrste(List<string> argumentList)
        {
            int index = argumentList.FindIndex(a => a.Contains("-v"));
            Console.WriteLine("-v se nalazi na " + index);
            VrstePutanja = argumentList.ElementAt(index + 1);
            Console.WriteLine(VrstePutanja);
            UcitajDatotekeFactory tvornica = new UcitajDatotekeFactory();
            IUcitajDatotekeFactory ucitajVrste = tvornica.Ucitaj("vrsta");
            ucitajVrste.UcitajDatoteku();
        }

        public static void UcitajPrograme(List<string> argumentList)
        {
            int index = argumentList.FindIndex(a => a.Contains("-t"));
            Console.WriteLine("-t se nalazi na " + index);
            TvKucaPutanja = argumentList.ElementAt(index + 1);
            Console.WriteLine(TvKucaPutanja);
            UcitajDatotekeFactory tvornica = new UcitajDatotekeFactory();
            IUcitajDatotekeFactory ucitajPrograme = tvornica.Ucitaj("programi");
            ucitajPrograme.UcitajDatoteku();
        }

        public static void UcitajEmisije(List<string> argumentList)
        {
            int index = argumentList.FindIndex(a => a.Contains("-e"));
            Console.WriteLine("-e se nalazi na " + index);
            EmisijaPutanja = argumentList.ElementAt(index + 1);
            Console.WriteLine(EmisijaPutanja);
            UcitajDatotekeFactory tvornica = new UcitajDatotekeFactory();
            IUcitajDatotekeFactory ucitajEmisije = tvornica.Ucitaj("emisija");
            ucitajEmisije.UcitajDatoteku();
            EmisijaUnikatniID = 1;
        }

        public static void AzurirajOsobuUlugu(Osoba o, Uloga u)
        {
            if (UcitaniPodaci.UnikatniParovi.Count(ou => ou.Osoba == o && ou.Uloga == u) < 1)
            {
                UcitaniPodaci.UnikatniParovi.Add(new ConcreteSubject { Osoba = o, Uloga = u });
            }

            
        }

        public static void DohvatiOsobuUlogu(Emisija e)
        {
            foreach (var VARIABLE in e.UlogeOsoba)
            {
                try
                {
                    var osoba = UcitaniPodaci.UcitaneOsobe.First(o => o.Id == VARIABLE.OsobaId);
                    var uloga = UcitaniPodaci.UcitaneUloge.First(u => u.Id == VARIABLE.UlogaId);
                    AzurirajOsobuUlugu(osoba, uloga);
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Ne postoji takav par osoba");
                    
                }
                
            }

        }
    }
}
