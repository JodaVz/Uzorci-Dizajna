using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using marvertus_zadaca_3.Composite;
using marvertus_zadaca_3.Modeli;
using marvertus_zadaca_3.PomocneKlase;

namespace marvertus_zadaca_3.Factory_Method_Datoteke
{
    internal class UcitajProgrameFactory : IUcitajDatotekeFactory
    {
        public void UcitajDatoteku()
        {
            string[] lines;
            if (System.IO.File.Exists(UcitaniPodaci.TvKucaPutanja))
            {
                var test = System.IO.Path.GetFullPath(UcitaniPodaci.TvKucaPutanja);
                var root = new DirectoryInfo(System.IO.Path.GetDirectoryName(test)).FullName;
                Console.WriteLine(test);
                Console.WriteLine(root);
                lines = System.IO.File.ReadAllLines(UcitaniPodaci.TvKucaPutanja);
                for (int i = 1; i < lines.Length; i++)
                {
                    int id = 0;
                    string naziv = "";
                    DateTime pocetak;
                    DateTime kraj;
                    string raspored = "";
                    int count = lines[i].Split(';').Length - 1;
                    if (!lines[i].Contains(';') || count != 4)
                    {
                        Console.WriteLine("Red je u krivom formatu, molim vas koristite ; kao delimiter");
                    }
                    else if(Regex.IsMatch(lines[i].Split(';')[0], @"^\d+$") &&
                            Regex.IsMatch(lines[i].Split(';')[2].Trim(), @"^([0-1]?[0-9]|[2][0-3]):([0-5][0-9])(:[0-5][0-9])?$") &&
                            Regex.IsMatch(lines[i].Split(';')[3].Trim(), @"^([0-1]?[0-9]|[2][0-3]):([0-5][0-9])(:[0-5][0-9])?$"))
                    {
                        DodajProgramTvKuci(lines, i, root);
                    }
                }
            }
            else
            {
                Console.WriteLine("Putanja datoteke s TvKucom/Programima nije dobra");
            }
        }

        private static void DodajProgramTvKuci(string[] lines, int i, string root)
        {
            int id;
            string naziv;
            DateTime pocetak;
            DateTime kraj;
            string raspored;
            id = int.Parse(lines[i].Split(';')[0]);
            naziv = lines[i].Split(';')[1];
            if (lines[i].Split(';')[2] == "")
            {
                pocetak = DateTime.Parse("00:00");
            }
            else
            {
                pocetak = DateTime.Parse(lines[i].Split(';')[2]);
            }

            if (lines[i].Split(';')[3] == "")
            {
                kraj = DateTime.ParseExact("23:59", "HH:mm", null);
            }
            else
            {
                kraj = DateTime.Parse(lines[i].Split(';')[3]);
            }

            raspored = lines[i].Split(';')[4];
            TvKuca.Instance.TvProgrami.Add(new TvProgram
            {
                Id = id,
                ImePrograma = naziv,
                PocetakPrograma = pocetak,
                KrajPrograma = kraj,
                PutanjaRasporeda = root + "\\" + raspored
            });
        }
    }
}