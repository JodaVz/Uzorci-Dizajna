using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marvertus_zadaca_3.Decorator
{
    class ConcreteDComponent:DComponent
    {
        public override string Ispis(string text)
        {
            string test = text;
           
            return test;
            
        }
    }
}
