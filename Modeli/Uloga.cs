using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using marvertus_zadaca_3.PomocneKlase;

namespace marvertus_zadaca_3.Modeli
{
    [Serializable]
    public class Uloga
    {
        public int Id { get; set; }
        public string Opis { get; set; } = "";

        public static void Ispis() 
            {
                Console.WriteLine("ISPIS ULOGA");
                foreach (var VARIABLE in UcitaniPodaci.UcitaneUloge)
                {
                    Console.WriteLine(VARIABLE.Id+" "+VARIABLE.Opis);
                }
            }
    }
}
