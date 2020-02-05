using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using marvertus_zadaca_3.Emisija_Builder;
using marvertus_zadaca_3.Modeli;
using marvertus_zadaca_3.PomocneKlase;

namespace marvertus_zadaca_3.Factory_Method_Datoteke
{
    internal class UcitajEmisijeFactory : IUcitajDatotekeFactory
    {
        public void UcitajDatoteku()
        {
            string[] lines;
            if (File.Exists(UcitaniPodaci.EmisijaPutanja))
            {
                lines = File.ReadAllLines(UcitaniPodaci.EmisijaPutanja);
                for (var i = 1; i < lines.Length; i++)
                {
                    var id = 0;
                    var nazivEmisije = "";
                    VrstaEmisije vrstaEmsije;
                    int trajanjeEmisijeMinute;
                    TimeSpan trajaneEmisije;
                    var osobaUloga = "";
                    var count = lines[i].Split(';').Length - 1;
                    if (!lines[i].Contains(';') || count != 4)
                    {
                        Console.WriteLine("Red je krivom formatu, molim vas koristite ; kao delimiter");
                    }
                    else if(Regex.IsMatch(lines[i].Split(';')[0], @"^\d+$") && 
                            Regex.IsMatch(lines[i].Split(';')[3], @"^\d+$"))
                    {
                        id = int.Parse(lines[i].Split(';')[0]);
                        nazivEmisije = lines[i].Split(';')[1];
                        var IdVrste = int.Parse(lines[i].Split(';')[2]);
                        vrstaEmsije = UcitaniPodaci.UcitaneVrsteEmisija.First(v => v.Id == IdVrste);
                        trajanjeEmisijeMinute = int.Parse(lines[i].Split(';')[3]);
                        trajaneEmisije = new TimeSpan(0, trajanjeEmisijeMinute, 0);
                        osobaUloga = lines[i].Split(';')[4];
                        var direktor = new EmisijeBuilderDirector(new EmisijeBuilder());
                        direktor.KreirajEmisiju(id, vrstaEmsije, nazivEmisije, trajaneEmisije, osobaUloga);
                        var testna = direktor.IzgradiEmisija();
                        UcitaniPodaci.DohvatiOsobuUlogu(testna);
                        UcitaniPodaci.UcitaneEmisije.Add(testna);
                    }
                }
            }
            else
            {
                Console.WriteLine("Putanja datoteke s emisijama nije dobra");
            }
        }
    }
}