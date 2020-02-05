using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marvertus_zadaca_3.Visitor
{
     public interface Element
    {
          void Accept(IVisitor visitor);
    }
}
