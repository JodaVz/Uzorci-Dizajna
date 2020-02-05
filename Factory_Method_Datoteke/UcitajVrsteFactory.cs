using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using marvertus_zadaca_3.Modeli;
using marvertus_zadaca_3.PomocneKlase;

namespace marvertus_zadaca_3.Factory_Method_Datoteke
{
    internal class UcitajVrsteFactory : IUcitajDatotekeFactory
    {
        public void UcitajDatoteku()
        {
            string[] lines;
            if (File.Exists(UcitaniPodaci.VrstePutanja))
            {
                lines = File.ReadAllLines(UcitaniPodaci.VrstePutanja);
                for (var i = 1; i < lines.Length; i++)
                {
                    var id = 0;
                    var vrstaEmisije = "";
                    var imaReklame = false;
                    var trajanjeReklame = 0;
                    var count = lines[i].Split(';').Length - 1;
                    if (!lines[i].Contains(';') || count != 3)
                    {
                        Console.WriteLine("Red je krivom formatu, molim vas koristite ; kao delimiter");
                    }
                    else if(Regex.IsMatch(lines[i].Split(';')[0], @"^\d+$"))
                    {
                        id = int.Parse(lines[i].Split(';')[0].Trim());
                        vrstaEmisije = lines[i].Split(';')[1].Trim();

                        if (int.Parse(lines[i].Split(';')[2].Trim()) == 0) imaReklame = false;
                        if (int.Parse(lines[i].Split(';')[2]) == 1) imaReklame = true;
                        trajanjeReklame = int.Parse(lines[i].Split(';')[3].Trim());
                        UcitaniPodaci.UcitaneVrsteEmisija.Add(new VrstaEmisije
                        {
                            Id = id,
                            ImaReklamu = imaReklame,
                            MaksTrajanjeReklame = trajanjeReklame,
                            Opis = vrstaEmisije
                        });
                    }
                }
            }
            else
            {
                Console.WriteLine("Putanja datoteke s vrstama ne valja");
            }
        }
    }
}