using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using marvertus_zadaca_3.Modeli;

namespace marvertus_zadaca_3.Prototype_Emisija
{
    [Serializable]
    public abstract class EmisijaProto
    {
        public int Id { get; set; }
        public string NazivEmisije { get; set; } = "";
        public TimeSpan TrajanjeEmisije { get; set; }
        public List<Parovi> UlogeOsoba = new List<Parovi>();
        public VrstaEmisije VrstaEmisije { get; set; }

        public abstract Emisija Clone();
    }
}
