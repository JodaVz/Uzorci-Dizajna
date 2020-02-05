using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marvertus_zadaca_3.PomocneKlase
{
    public sealed class ProvjeraDatotekeSingleton
    {
        private static ProvjeraDatotekeSingleton instance = null;
        public static ProvjeraDatotekeSingleton GetInstance
        {
            get
            {
                if (instance != null) return instance;
                instance = new ProvjeraDatotekeSingleton();
                return instance;
            }

        }
        public bool ProvjeriDatoteke(List<string> argumenti)
        {
            int suma = 0;
            int lokacijaPutanje = 0;
            bool ispravnostDatoteka = false;
            string putanja = "";
            if (argumenti.Count == 0)
            {
                ispravnostDatoteka = false;
                Console.WriteLine("Niste zadali argumente!");
            }
            if (argumenti.Count != 0)
            {
                if (argumenti.Contains("-o") )
                {
                    lokacijaPutanje = argumenti.FindIndex(a => a.Contains("-o"))+1;
                    putanja = argumenti.ElementAt(lokacijaPutanje);
                    if (File.Exists(putanja))
                    {
                        suma++;
                        Console.WriteLine("Postoji datoteka s osobama "+suma+"/5");
                        ispravnostDatoteka = true;
                    }

                }
                if (argumenti.Contains("-t"))
                {
                    lokacijaPutanje = argumenti.FindIndex(a => a.Contains("-t")) + 1;
                    putanja = argumenti.ElementAt(lokacijaPutanje);
                    if (File.Exists(putanja))
                    {
                        suma++;
                        Console.WriteLine("Postoji datoteka s TvKucama " + suma + "/5");
                        ispravnostDatoteka = true;
                    }
                }
                if (argumenti.Contains("-u"))
                {
                    lokacijaPutanje = argumenti.FindIndex(a => a.Contains("-u")) + 1;
                    putanja = argumenti.ElementAt(lokacijaPutanje);
                    if (File.Exists(putanja))
                    {
                        suma++;
                        Console.WriteLine("Postoji datoteka s ulogama " + suma + "/5");
                        ispravnostDatoteka = true;
                    }
                }
                if (argumenti.Contains("-e"))
                {
                    lokacijaPutanje = argumenti.FindIndex(a => a.Contains("-e")) + 1;
                    putanja = argumenti.ElementAt(lokacijaPutanje);
                    if (File.Exists(putanja))
                    {
                        suma++;
                        Console.WriteLine("Postoji datoteka s emisijama " + suma + "/5");
                        ispravnostDatoteka = true;
                    }
                }
                if (argumenti.Contains("-v"))
                {
                    lokacijaPutanje = argumenti.FindIndex(a => a.Contains("-v")) + 1;
                    putanja = argumenti.ElementAt(lokacijaPutanje);
                    if (File.Exists(putanja))
                    {
                        suma++;
                        Console.WriteLine("Postoji datoteka s vrstama " + suma + "/5");
                        ispravnostDatoteka = true;
                    }
                }
            }
            return ispravnostDatoteka;
        }
    }
}
