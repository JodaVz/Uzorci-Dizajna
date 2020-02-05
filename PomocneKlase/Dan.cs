using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marvertus_zadaca_3.PomocneKlase
{
    public enum Dan
    {
        Ponedjeljak = 1,
        Utorak = 2,
        Srijeda = 3,
        Četvrtak = 4,
        Petak = 5,
        Subota = 6,
        Nedjelja = 7
    }

    public static class DanPomoc
    {
        public static List<Dan> KreirajDane(string dani)
        {
            var finalna = new List<Dan>();
            List<string> pomocna;
            if (dani.Contains("-"))
            {
                pomocna = dani.Split('-').ToList();
                if (pomocna.Count == 2) finalna = RasponDana(pomocna);
            }

            if (dani.Contains(','))
            {
                pomocna = dani.Split(',').ToList();
                if (pomocna.Count > 0) finalna = PojedinacniDani(pomocna);
            }
            else if (int.TryParse(dani.Trim(), out _))
            {
                finalna.Add((Dan)int.Parse(dani.Trim()));
            }

            return finalna;
        }

        //Od X-Y
        private static List<Dan> RasponDana(List<string> pomocna)
        {
            var rezultat = new List<Dan>();

            for (var i = int.Parse(pomocna[0].Trim()); i <= int.Parse(pomocna[1].Trim()); i++) rezultat.Add((Dan) i);

            return rezultat;
        }

        //X,Y,Z
        private static List<Dan> PojedinacniDani(List<string> pomocna)
        {
            var rezultat = new List<Dan>();


            foreach (var item in pomocna) rezultat.Add((Dan) int.Parse(item.Trim()));

            return rezultat;
        }

        //X
       
    }
}