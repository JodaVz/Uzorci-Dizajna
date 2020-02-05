using marvertus_zadaca_3.Composite;

namespace marvertus_zadaca_3.Iterator
{
    internal class EmisijePoTjednu : IteratorInterface
    {
        private readonly int OdabraniDan;
        private int PozicijaDana;
        private int PozicijaUDanu;
        private readonly TvProgram Program = new TvProgram();

        public EmisijePoTjednu(TvProgram program, int dan)
        {
            Program = program;
            OdabraniDan = dan;
        }

        public bool ImaSljedeci()
        {
            var pozicijaDana = PozicijaDana;
            var pozicijaUDanu = PozicijaUDanu;
            while (Program.DohvatiDjecu().Count > pozicijaDana)
                if (Program.DohvatiDjecu()[pozicijaDana].DohvatiDjecu().Count > pozicijaUDanu)
                {
                    return true;
                }

                else if (Program.DohvatiDjecu()[pozicijaDana].DohvatiDjecu().Count == pozicijaUDanu)
                {
                    pozicijaDana++;
                    pozicijaUDanu = 0;
                }
                else
                {
                    return false;
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
                    if (PozicijaDana == OdabraniDan)
                        pomocna = Program.DohvatiDjecu()[PozicijaDana].DohvatiDjecu()[PozicijaUDanu];

                var test = Program.DohvatiDjecu()[PozicijaDana].DohvatiDjecu().Count;
                if (Program.DohvatiDjecu()[PozicijaDana].DohvatiDjecu().Count == PozicijaUDanu)
                {
                    PozicijaDana++;
                    PozicijaUDanu = 0;
                }
                else
                {
                    PozicijaUDanu++;
                }

                return pomocna;
            }


            return pomocna;
        }
    }
}