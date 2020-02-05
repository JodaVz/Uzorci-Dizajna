using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using marvertus_zadaca_3.PomocneKlase;

namespace marvertus_zadaca_3.Modeli
{
    [Serializable]
     public class Osoba
    {
        public int Id { get; set; }
        public string ImePrezime { get; set; } = "";
        public Osoba(int id, string ime)
        {
            Id = id;
            ImePrezime = ime;
        }

        public static void Ispis()
        {
            Console.WriteLine("ISPIS OSOBA");
            foreach (var VARIABLE in UcitaniPodaci.UcitaneOsobe)
            {
                Console.WriteLine(VARIABLE.Id+" "+VARIABLE.ImePrezime);
            }
            Console.WriteLine("\n \n");
        }
    }
}
