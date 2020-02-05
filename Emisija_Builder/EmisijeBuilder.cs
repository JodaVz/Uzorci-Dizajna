using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using marvertus_zadaca_3.Modeli;
using marvertus_zadaca_3.Prototype_Emisija;

namespace marvertus_zadaca_3.Emisija_Builder
{
    class EmisijeBuilder : IEmisijeBuilder
    {
        Emisija emisija= new Emisija();
        public void DodajId(int id)
        {
            emisija.Id = id;
        }
        public void DodajNaziv(string naziv)
        {
            emisija.NazivEmisije = naziv;
        }
        public void DodajVrsta(VrstaEmisije vrsta)
        {
            emisija.VrstaEmisije = vrsta;
        }
        public void DodajTrajanje(TimeSpan trajanje)
        {
            emisija.TrajanjeEmisije = trajanje;
        }
        public void DodajOsobaUloga(string osobaUloga)
        {
            osobaUloga = osobaUloga.Trim();
            if (osobaUloga.Contains(','))
            {
                int count = osobaUloga.Split(',').Length - 1;
                emisija.UlogeOsoba = new List<Parovi>();
                string[] Pomocna = osobaUloga.Split(',');
                foreach (var item in Pomocna)
                {
                    if (item.Contains('-') && Regex.IsMatch(item, "[0-9]+-[0-9]+"))
                    {
                        int osoba = int.Parse(item.Split('-')[0]);
                        int uloga = int.Parse(item.Split('-')[1]);
                        emisija.UlogeOsoba.Add(new Parovi(osoba, uloga));
                    }
                }
            }
            else if (osobaUloga.Contains('-') && Regex.IsMatch(osobaUloga, "[0-9]+-[0-9]+"))
            {
                emisija.UlogeOsoba = new List<Parovi>();
                int osoba = int.Parse(osobaUloga.Split('-')[0]);
                int uloga = int.Parse(osobaUloga.Split('-')[1]);
                emisija.UlogeOsoba.Add(new Parovi(osoba, uloga));
            }
            else
            {
                emisija.UlogeOsoba = new List<Parovi>();
            }
        }
        public Emisija IzgradiEmisija()
        {
            return emisija;
        }

    }
}
