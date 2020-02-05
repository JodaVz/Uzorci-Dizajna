using System;
using System.IO;
using System.Text.RegularExpressions;
using marvertus_zadaca_3.Modeli;
using marvertus_zadaca_3.PomocneKlase;

namespace marvertus_zadaca_3.Factory_Method_Datoteke
{
    internal class UcitajOsobeFactory : IUcitajDatotekeFactory
    {
        public void UcitajDatoteku()
        {
            string[] lines;
            if (File.Exists(UcitaniPodaci.OsobaPutanja))
            {
                lines = File.ReadAllLines(UcitaniPodaci.OsobaPutanja);
                for (var i = 1; i < lines.Length; i++)
                {
                    var count = lines[i].Split(';').Length - 1;
                    if (lines[i].Contains(";") || count == 1)
                    {
                        var id = 0;
                        var imePrezime = "";
                        id = int.Parse(lines[i].Trim().Split(';')[0]);
                        imePrezime = lines[i].Trim().Split(';')[1];
                        if (imePrezime == "")
                        {
                            Console.WriteLine("Red nije u dobrom formatu");
                        }
                        else if(Regex.IsMatch(lines[i].Split(';')[0], @"^\d+$"))
                        {
                            UcitaniPodaci.UcitaneOsobe.Add(new Osoba(id, imePrezime));
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Putanja datoteke s osobama nije dobra");
            }
        }
    }
}