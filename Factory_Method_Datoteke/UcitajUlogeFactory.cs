using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using marvertus_zadaca_3.Modeli;
using marvertus_zadaca_3.PomocneKlase;

namespace marvertus_zadaca_3.Factory_Method_Datoteke
{
    class UcitajUlogeFactory:IUcitajDatotekeFactory
    {
        public void UcitajDatoteku()
        {
            string[] lines;
            if (System.IO.File.Exists(UcitaniPodaci.UlogePutanja))
            {
                lines = System.IO.File.ReadAllLines(UcitaniPodaci.UlogePutanja);
                for (int i = 1; i < lines.Length; i++)
                {

                    int id = 0;
                    string opisUloge = "";
                    var count = lines[i].Split(';').Length - 1;
                    if (!lines[i].Contains(';') || count!=1)
                    {
                        Console.WriteLine("Red je u krivom formatu, molim vas koristite ; kao delimiter");
                    }
                    else if(Regex.IsMatch(lines[i].Split(';')[0], @"^\d+$"))
                    {
                        id = int.Parse(lines[i].Split(';')[0]);
                        opisUloge = lines[i].Split(';')[1];
                        UcitaniPodaci.UcitaneUloge.Add(new Uloga {Id = id,Opis = opisUloge});
                    }

                }
            }
            else
            {
                Console.WriteLine("Putanja datoteke s ulogama nije dobra");
               
            }
        }
    }
}
