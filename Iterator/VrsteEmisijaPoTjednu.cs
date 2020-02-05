using System;
using marvertus_zadaca_3.Composite;
using marvertus_zadaca_3.PomocneKlase;

namespace marvertus_zadaca_3.Iterator
{
    internal class VrsteEmisijaPoTjednu : IteratorInterface
    {
        private int PozicijaDana;
        private int PozicijaUDanu;
        private readonly TvProgram Program = new TvProgram();
        private readonly int VrstaEmisije;
        public int Dan;

        public VrsteEmisijaPoTjednu(TvProgram program, int vrstaEmisije)
        {
            Program = program;
            VrstaEmisije = vrstaEmisije;
        }

        public bool ImaSljedeci()
        {
            var pomocniDan = PozicijaDana;
            var pomocnaEmisija = PozicijaUDanu;
            while (pomocniDan < Program.DohvatiDjecu().Count)
            {
                while (pomocnaEmisija < Program.DohvatiDjecu()[pomocniDan].DohvatiDjecu().Count)
                {
                    var vrsta = Program.DohvatiDjecu()[pomocniDan].DohvatiDjecu()[pomocnaEmisija]
                        .DohvatiId();
                    if (vrsta == VrstaEmisije)
                    {
                        PozicijaDana = pomocniDan;
                        PozicijaUDanu = pomocnaEmisija;
                        return true;
                    }

                    pomocnaEmisija++;
                }

                pomocniDan++;
                pomocnaEmisija = 0;
            }

            return false;
        }

        public object DohvatiSljedeci()
        {
            Component pomocna = null;
            if (ImaSljedeci())
            {
                if (Program.DohvatiDjecu().Count > PozicijaDana &&
                    Program.DohvatiDjecu()[PozicijaDana].DohvatiDjecu().Count > PozicijaUDanu)
                    Console.WriteLine((Dan)PozicijaDana+1);
                pomocna = Program.DohvatiDjecu()[PozicijaDana].DohvatiDjecu()[PozicijaUDanu];
                var test = Program.DohvatiDjecu()[PozicijaDana].DohvatiDjecu().Count;
                if (Program.DohvatiDjecu()[PozicijaDana].DohvatiDjecu().Count == PozicijaUDanu)
                {
                    PozicijaDana++;
                    PozicijaUDanu = 0;
                }

                PozicijaUDanu++;
                return pomocna;
            }


            return pomocna;
        }
    }
}