using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marvertus_zadaca_3.Factory_Method_Datoteke
{
    public class UcitajDatotekeFactory
    {
        public IUcitajDatotekeFactory Ucitaj(string vrstaDatoteke)
        {
            switch (vrstaDatoteke)
            {
                case null:
                    return null;
                case "osoba":
                    return new UcitajOsobeFactory();
                case "uloga":
                    return new UcitajUlogeFactory();
                case "programi":
                    return new UcitajProgrameFactory();
                case "emisija":
                    return new UcitajEmisijeFactory();
                case "vrsta":
                    return new UcitajVrsteFactory();
                default:
                    return null;
            }
        }
    }
}
