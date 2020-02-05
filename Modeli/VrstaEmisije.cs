using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using marvertus_zadaca_3.PomocneKlase;

namespace marvertus_zadaca_3.Modeli
{
    [Serializable]
    public class VrstaEmisije
    {
        public int Id { get; set; }
        public string Opis { get; set; } = "";
        public bool ImaReklamu { get; set; }
        public int MaksTrajanjeReklame { get; set; }

        public static void Ispis()
        {
            Console.WriteLine("ISPIS VRSTE EMISIJA");
            foreach (var VARIABLE in UcitaniPodaci.UcitaneVrsteEmisija)
            {
                Console.WriteLine(VARIABLE.Id + " " + VARIABLE.Opis + " " + VARIABLE.ImaReklamu + " " +
                                  VARIABLE.MaksTrajanjeReklame);

            }

            Console.WriteLine("\n \n");
        }
    }
   
}
