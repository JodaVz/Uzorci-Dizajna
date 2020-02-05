using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marvertus_zadaca_3.Modeli
{
    [Serializable]
    public class Parovi
    {
        public int OsobaId { get; set; }
        public int UlogaId { get; set; }
        public Parovi(int osoba, int uloga)
        {
            OsobaId = osoba;
            UlogaId = uloga;
        }
    }
}
